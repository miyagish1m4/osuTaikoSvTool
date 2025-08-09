using System.Text;
using osuTaikoSvTool.Models;
using osuTaikoSvTool.Properties;

namespace osuTaikoSvTool.Utils.Helper
{
    class BeatmapHelper
    {
        /// <summary>
        /// BGを取得して、フォームの背景に設定する
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>BGデータ</returns>
        internal static Bitmap SetBgOnForm(string path)
        {
            string imageName = string.Empty;
            const double DARKNESS_FACTOR = 0.5;
            Bitmap canvas = new Bitmap(384, 216);
            try
            {
                if (path == "")
                {
                    throw new Exception("背景画像が見つかりませんでした。");
                }
                Bitmap image = new Bitmap(path);
                float width = 0;
                float height = 0;
                float diffWidth = 0;
                float diffHeight = 0;
                float zoomRatio = 0;
                if (((float)image.Height / (float)image.Width) < 0.5625f)
                {
                    zoomRatio = ((float)image.Height / 216f);
                    height = image.Height;
                    float heightRatio = (float)image.Height / 9f;
                    width = heightRatio * 16;
                    diffWidth = ((float)image.Width - width) / 2;
                    //横長画像
                }
                else if (((float)image.Height / (float)image.Width) > 0.5625f)
                {
                    zoomRatio = ((float)image.Width / 384f);
                    width = image.Width;
                    float widthRatio = (float)image.Width / 16f;
                    height = widthRatio * 9;
                    diffHeight = ((float)image.Height - height) / 2;

                    //縦長画像
                }
                else
                {
                    zoomRatio = ((float)image.Width / 384f);
                    width = image.Width;
                    height = image.Height;
                }
                RectangleF destinationRect = new RectangleF(0, 0, width / zoomRatio, height / zoomRatio);
                RectangleF sourceRect = new RectangleF(diffWidth, diffHeight, width, height);
                Graphics graphic = Graphics.FromImage(canvas);
                graphic.InterpolationMode =
                    System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphic.DrawImage(image, destinationRect, sourceRect, GraphicsUnit.Pixel);
                image.Dispose();
                graphic.Dispose();
                for (int y = 0; y < 216; y++)
                {
                    for (int x = 0; x < 384; x++)
                    {
                        Color pixel = canvas.GetPixel(x, y);
                        int r = (int)(pixel.R * DARKNESS_FACTOR);
                        int g = (int)(pixel.G * DARKNESS_FACTOR);
                        int b = (int)(pixel.B * DARKNESS_FACTOR);
                        Color darkPixel = Color.FromArgb(r, g, b);
                        canvas.SetPixel(x, y, darkPixel);
                    }
                }

                return canvas;
            }
            catch (Exception ex)
            {
                Common.WriteWarningMessage("LOG_W-GET-BG");
                Common.WriteExceptionMessage(ex);
                return canvas;
            }
        }
        /// <summary>
        /// beatmapのデータを取得する
        /// </summary>
        /// <param name="path">beatmapのパス</param>
        /// <returns>取得したデータ</returns>
        internal static Beatmap GetBeatmapData(string path)
        {
            var version = string.Empty;
            var generalList = new List<string>();
            var editorList = new List<string>();
            var metadataList = new List<string>();
            var difficultyList = new List<string>();
            var eventsList = new List<string>();
            var timingPointList = new List<TimingPoint>();
            var coloursList = new List<string>();
            var uninheritedTimingPointList = new List<TimingPoint>();
            var hitObjectList = new List<HitObject>();
            List<Bookmarks> bookmarkList = new List<Bookmarks>();
            try
            {
                var lines = File.ReadAllLines(path);
                // 譜面情報をセクションに区切り全取得
                if (!GetBeatmapInfoBySection(lines,
                                             ref version,
                                             ref generalList,
                                             ref editorList,
                                             ref metadataList,
                                             ref difficultyList,
                                             ref eventsList,
                                             ref timingPointList,
                                             ref coloursList,
                                             ref hitObjectList,
                                             ref bookmarkList))
                {
                    throw new Exception();
                }
                // 赤線と小節線を取得する
                if (!GetRedLineAndBarlineAndBookmark(ref timingPointList,
                                                     ref hitObjectList,
                                                     ref uninheritedTimingPointList,
                                                     ref bookmarkList))
                {
                    throw new Exception();
                }
                // HitObject に SVとBPMを適用(ソート後)
                if (!SetSvAndBpmOnHitObjects(timingPointList,
                                             ref hitObjectList))
                {
                    throw new Exception();
                }
                // BeatmapInfo に渡す
                return new Beatmap(version,
                                   generalList,
                                   editorList,
                                   metadataList,
                                   difficultyList,
                                   eventsList,
                                   timingPointList,
                                   coloursList,
                                   hitObjectList,
                                   bookmarkList);
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-GET-BEATMAP");
                Common.WriteExceptionMessage(ex);
                return new Beatmap("",
                                   generalList,
                                   editorList,
                                   metadataList,
                                   difficultyList,
                                   eventsList,
                                   timingPointList,
                                   coloursList,
                                   hitObjectList,
                                   bookmarkList);
            }
        }
        /// <summary>
        /// 譜面情報をセクションに区切りに変換する
        /// </summary>
        /// <param name="lines">osuファイルの中身</param>
        /// <param name="generalList">Generalの格納先</param>
        /// <param name="editorList">Editorの格納先</param>
        /// <param name="metadataList">Metadataの格納先</param>
        /// <param name="difficultyList">Difficultyの格納先</param>
        /// <param name="eventsList">EventsListの格納先</param>
        /// <param name="timingPointList">TimingPointの格納先</param>
        /// <param name="coloursList">Coloursの格納先</param>
        /// <param name="hitObjectList">HitObjectの格納先</param>
        /// <param name="bookmarks">Bookmarkの格納先</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool GetBeatmapInfoBySection(string[] lines,
                                                    ref string version,
                                                    ref List<string> generalList,
                                                    ref List<string> editorList,
                                                    ref List<string> metadataList,
                                                    ref List<string> difficultyList,
                                                    ref List<string> eventsList,
                                                    ref List<TimingPoint> timingPointList,
                                                    ref List<string> coloursList,
                                                    ref List<HitObject> hitObjectList,
                                                    ref List<Bookmarks> bookmarks)
        {
            int structureCode = Constants.VERSION_CODE;
            try
            {
                foreach (var line in lines)
                {
                    if (line == "")
                    {
                        continue;
                    }
                    if (line.Length >= 9)
                    {
                        if (line.Substring(0, 9) == "Bookmarks")
                        {
                            string[] bookmarkParts = line.Split(':');
                            List<string> stringBookmarks = new List<string>(bookmarkParts[1].Replace(" ", "").Split(","));
                            foreach (var timing in stringBookmarks)
                            {
                                bookmarks.Add(new Bookmarks(int.Parse(timing)));
                            }
                        }
                    }
                    switch (line)
                    {
                        case Constants.GENERAL:
                            structureCode = Constants.GENERAL_CODE;
                            continue;
                        case Constants.EDITOR:
                            structureCode = Constants.EDITOR_CODE;
                            continue;
                        case Constants.METADATA:
                            structureCode = Constants.METADATA_CODE;
                            continue;
                        case Constants.DIFFICULTY:
                            structureCode = Constants.DIFFICULTY_CODE;
                            continue;
                        case Constants.EVENTS:
                            structureCode = Constants.EVENTS_CODE;
                            continue;
                        case Constants.TIMING_POINTS:
                            structureCode = Constants.TIMING_POINTS_CODE;
                            continue;
                        case Constants.COLOURS:
                            structureCode = Constants.COLOURS_CODE;
                            continue;
                        case Constants.HIT_OBJECTS:
                            structureCode = Constants.HIT_OBJECTS_CODE;
                            continue;
                        default:
                            break;
                    }
                    switch (structureCode)
                    {
                        case Constants.VERSION_CODE:
                            version = line;
                            break;
                        case Constants.GENERAL_CODE:
                            generalList.Add(line);
                            break;
                        case Constants.EDITOR_CODE:
                            editorList.Add(line);
                            break;
                        case Constants.METADATA_CODE:
                            metadataList.Add(line);
                            break;
                        case Constants.DIFFICULTY_CODE:
                            difficultyList.Add(line);
                            break;
                        case Constants.EVENTS_CODE:
                            eventsList.Add(line);
                            break;
                        case Constants.TIMING_POINTS_CODE:
                            timingPointList.Add(new TimingPoint(line));
                            break;
                        case Constants.COLOURS_CODE:
                            coloursList.Add(line);
                            break;
                        case Constants.HIT_OBJECTS_CODE:
                            hitObjectList.Add(new HitObject(line));
                            break;
                        default:
                            break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }

        /// <summary>
        /// 赤線と小節線とブックマークを取得する
        /// </summary>
        /// <param name="timingPointList">赤線のリスト</param>
        /// <param name="hitObjectList">小節線の格納先(小節線はHitObjectとしてカウントする)</param>
        /// <param name="uninheritedTimingPointList">赤線の格納先</param>
        /// <param name="bookmarkList">ブックマークの格納先</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool GetRedLineAndBarlineAndBookmark(ref List<TimingPoint> timingPointList,
                                                            ref List<HitObject> hitObjectList,
                                                            ref List<TimingPoint> uninheritedTimingPointList,
                                                            ref List<Bookmarks> bookmarkList)
        {
            try
            {
                // 最終ノーツを取る(これ以上は見ない)
                hitObjectList.Sort((a, b) => a.time.CompareTo(b.time));
                HitObject lastHitObject = hitObjectList.Last();

                foreach (var timingPoint in timingPointList)
                {
                    if (timingPoint.isRedLine)
                    {
                        uninheritedTimingPointList.Add(timingPoint);
                        uninheritedTimingPointList.Last().sv = 1;
                    }
                }
                for (int i = 0; i < uninheritedTimingPointList.Count; i++)
                {
                    decimal time = uninheritedTimingPointList[i].time;
                    int timeEnd = lastHitObject.time;

                    if (i + 1 < uninheritedTimingPointList.Count) timeEnd = uninheritedTimingPointList[i + 1].time;
                    decimal timeBar = uninheritedTimingPointList[i].barLength;
                    for (; time < timeEnd; time += timeBar)
                    {
                        int timeBarline = (int)Math.Floor(time);

                        // すでに同じ time の HitObject が存在するかをチェック
                        var hitObjectOnBarLine = hitObjectList.FirstOrDefault(h => h.time == timeBarline);
                        if (hitObjectOnBarLine == null)
                        {
                            // 赤線を HitObject として追加
                            hitObjectList.Add(new HitObject(timeBarline));
                        }
                        else
                        {
                            hitObjectOnBarLine.isOnBarline = true;
                        }
                    }
                }
                // ソートする
                timingPointList = timingPointList.OrderBy(a => a.time).
                                                  ThenByDescending(b => b.isRedLine ? 1 : 0).
                                                  ToList();
                hitObjectList = hitObjectList.OrderBy(a => a.time).
                                              ToList();

                for (int i = 0; i < bookmarkList.Count; i++)
                {
                    for (global::System.Int32 j = (timingPointList.Count) - (1); j >= 0; j--)
                    {
                        if ((timingPointList[j].time <= bookmarkList[i].time) && bookmarkList[i].sv == -1)
                        {
                            bookmarkList[i].sv = timingPointList[j].isRedLine ? 1 : timingPointList[j].sv;
                            bookmarkList[i].meter = timingPointList[j].meter;
                            bookmarkList[i].sampleSet = timingPointList[j].sampleSet;
                            bookmarkList[i].sampleIndex = timingPointList[j].sampleIndex;
                            bookmarkList[i].volume = timingPointList[j].volume;
                            bookmarkList[i].isRedLine = false;
                            bookmarkList[i].effect = timingPointList[j].effect;
                        }
                        if (timingPointList[j].time <= bookmarkList[i].time && timingPointList[j].isRedLine)
                        {
                            bookmarkList[i].bpm = timingPointList[j].bpm;
                            bookmarkList[i].barLength = timingPointList[j].barLength;
                            break;
                        }
                    }
                }


                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }

        }
        /// <summary>
        /// HitObjectにSVとBPMを適用
        /// </summary>
        /// <param name="timingPointList">赤線のリスト</param>
        /// <param name="hitObjectList">適用対象のHitObject</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool SetSvAndBpmOnHitObjects(List<TimingPoint> timingPointList,
                                                    ref List<HitObject> hitObjectList)
        {
            int timingIndex = 0;
            decimal currentBpm = 0;
            decimal currentSv = 1.0m;
            int svApplyTime = 0;
            try
            {
                foreach (var hitObject in hitObjectList)
                {
                    // timingPoint を進める
                    while (timingIndex + 1 < timingPointList.Count &&
                           timingPointList[timingIndex + 1].time <= hitObject.time)
                    {
                        timingIndex++;
                    }

                    // 赤線と緑線が同じ time に複数ある可能性があるため、
                    // その time の中で緑線があれば優先的に使う
                    var timeGroup = timingPointList
                        .Where(tp => tp.time == timingPointList[timingIndex].time)
                        .ToList();

                    var green = timeGroup.FirstOrDefault(tp => !tp.isRedLine);
                    var red = timeGroup.FirstOrDefault(tp => tp.isRedLine);

                    if (red != null)
                    {
                        currentBpm = red.bpm;
                    }
                    if (green != null)
                    {
                        currentSv = green.sv;
                        svApplyTime = green.time;
                    }
                    else if (red != null)
                    {
                        // 赤線のみある場合、SVは1.0
                        currentSv = 1.0m;
                        svApplyTime = red.time;
                    }

                    hitObject.bpm = currentBpm;
                    hitObject.sv = currentSv;
                    hitObject.svApplyTime = svApplyTime;
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }


        internal static bool CreateBackup(string path, string backupDirectory)
        {
            try
            {
                string backupPath = Directory.GetCurrentDirectory() + Constants.BACKUP_DIRECTORY + "\\" + backupDirectory;
                DateTime now = DateTime.Now;
                string backupFileName = $"{now:yyyy_MM_dd_HH_mm_ss_fff}.osu";
                if(!Directory.Exists(backupPath))
                {
                    Directory.CreateDirectory(backupPath);
                }
                File.Copy(path, Path.Combine(backupPath, backupFileName), true);
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteWarningMessage("LOG_E-CREATE-BACKUP");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// osuファイルを作成する
        /// </summary>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="beatmapPath">ファイル名</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        internal static bool ExportToOsuFile(Beatmap beatmap, string beatmapPath)
        {
            StreamWriter file = new StreamWriter(beatmapPath, false, Encoding.GetEncoding("utf-8"));
            try
            {
                file.WriteLine(beatmap.version);
                file.WriteLine("");
                file.WriteLine(Constants.GENERAL);
                beatmap.general.ForEach(line => file.WriteLine(line));
                file.WriteLine("");
                file.WriteLine(Constants.EDITOR);
                beatmap.editor.ForEach(line => file.WriteLine(line));
                file.WriteLine("");
                file.WriteLine(Constants.METADATA);
                beatmap.metadata.ForEach(line => file.WriteLine(line));
                file.WriteLine("");
                file.WriteLine(Constants.DIFFICULTY);
                beatmap.difficulty.ForEach(line => file.WriteLine(line));
                file.WriteLine("");
                file.WriteLine(Constants.EVENTS);
                beatmap.events.ForEach(line => file.WriteLine(line));
                file.WriteLine("");
                file.WriteLine(Constants.TIMING_POINTS);
                foreach (var timingPoint in beatmap.timingPoints)
                {
                    string beatLength = (timingPoint.isRedLine ?
                                        (60000 / timingPoint.bpm).ToString($"F12").TrimEnd('0') :
                                        (-100 / timingPoint.sv).ToString($"F12").TrimEnd('0'));
                    if (beatLength.Substring(beatLength.Length - 1, 1) == ".")
                    {
                        beatLength = beatLength.TrimEnd('.');
                    }
                    string timingPointLine = timingPoint.time + "," +
                                             beatLength + "," +
                                             timingPoint.meter + "," +
                                             timingPoint.sampleSet + "," +
                                             timingPoint.sampleIndex + "," +
                                             timingPoint.volume + "," +
                                             (timingPoint.isRedLine ? "1" : "0") + "," +
                                             timingPoint.effect;
                    file.WriteLine(timingPointLine);
                }
                file.WriteLine("");
                if (beatmap.colours.Count != 0)
                {
                    file.WriteLine(Constants.COLOURS);
                    beatmap.colours.ForEach(line => file.WriteLine(line));
                }
                file.WriteLine("");
                file.WriteLine(Constants.HIT_OBJECTS);
                foreach (var hitObject in beatmap.hitObjects)
                {
                    if (hitObject.noteType != Constants.NoteType.BARLINE)
                    {
                        string hitObjectLine = CreateHitObjectLine(hitObject);
                        file.WriteLine(hitObjectLine);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXPORT-OSU");
                Common.WriteExceptionMessage(ex);
                return false;
            }
            finally
            {
                file.Close();
            }
            return true;
        }
        /// <summary>
        /// osuファイルのヒットオブジェクトの行を作成する
        /// </summary>
        /// <param name="hitObject">ヒットオブジェクトデータ</param>
        /// <returns>ヒットオブジェクトの行</returns>
        private static string CreateHitObjectLine(HitObject hitObject)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(hitObject.positionX + ",");
            sb.Append(hitObject.positionY + ",");
            sb.Append(hitObject.time + ",");
            sb.Append(hitObject.type + ",");
            sb.Append(hitObject.hitSound + ",");
            if (hitObject.noteType == Constants.NoteType.SLIDER)
            {
                string sliderLength = hitObject.sliderLength.ToString($"F13").TrimEnd('0');
                if (sliderLength.Substring(sliderLength.Length - 1, 1) == ".")
                {
                    sliderLength = sliderLength.TrimEnd('.');
                }
                sb.Append(hitObject.curveSetting + ",");
                sb.Append(hitObject.slides + ",");
                sb.Append(sliderLength);
                if ((hitObject.edgeSounds != null) && (hitObject.edgeSets) != null && (hitObject.hitSample != null))
                {
                    sb.Append(",");
                    sb.Append(hitObject.edgeSounds + ",");
                    sb.Append(hitObject.edgeSets + ",");
                    sb.Append(hitObject.hitSample);
                }
                else
                {
                    sb.Append("");
                }
            }
            else if (hitObject.noteType == Constants.NoteType.SPINNER)
            {
                sb.Append(hitObject.endTime + ",");
                sb.Append(hitObject.hitSample);
            }
            else
            {
                sb.Append(hitObject.hitSample);
            }
            return sb.ToString();
        }
    }
}


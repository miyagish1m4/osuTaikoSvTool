using System.Text;
using osuTaikoSvTool.Models;
using osuTaikoSvTool.Properties;

namespace osuTaikoSvTool.Utils.Helper
{
    class BeatmapHelper
    {
        /// <summary>
        /// "ファイル開く"ボタン押下時のダイアログ処理
        /// </summary>
        /// <param name="initialDirectory">初期ディレクトリ</param>
        /// <returns>osuファイルのパス</returns>
        internal static string SelectFile(string initialDirectory)
        {
            string ret = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "ファイル選択ダイアログ";
                openFileDialog.Filter = "osuファイル(*.osu)|*.osu";
                openFileDialog.InitialDirectory = initialDirectory;

                //ファイル選択ダイアログを開く
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ret = openFileDialog.FileName;
                }
            }
            return ret;
        }
        /// <summary>
        /// BGを取得して、フォームの背景に設定する
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>BGデータ</returns>
        internal static Bitmap SetBgOnForm(string path, List<string> eventsList)
        {
            string imageName = string.Empty;
            bool isGetBG = false;
            try
            {
                for (global::System.Int32 i = 0; i < eventsList.Count; i++)
                {
                    if (eventsList[i] == "//Background and Video events")
                    {
                        while (true)
                        {
                            string[] buff = eventsList[i + 1].Split(",");
                            if (buff[0] == "Video")
                            {
                                i++;
                                continue;
                            }
                            imageName = buff[2].Replace("\"", "");
                            isGetBG = true;
                            break;
                        }
                        break;
                    }
                }
                if (isGetBG)
                {
                    Bitmap canvas = new Bitmap(384, 216);
                    Graphics g = Graphics.FromImage(canvas);
                    Bitmap image = new Bitmap(Path.GetDirectoryName(path) + "\\" + imageName);
                    g.InterpolationMode =
                        System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.DrawImage(image, 0, 0, 384, 216);
                    g.InterpolationMode =
                        System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    image.Dispose();
                    g.Dispose();
                    return canvas;
                }
                else
                {
                    throw new Exception("背景画像が見つかりませんでした。");
                }
            } catch (Exception ex)
            {
                Common.WriteWarningMessage("LOG_W-GET-BG");
                Common.WriteExceptionMessage(ex);
                return null;
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
            List<int> bookmarks = new List<int>();
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
                                             ref bookmarks))
                {
                    throw new Exception();
                }
                // 赤線と小節線を取得する
                if (!GetRedLineAndBarline(ref timingPointList,
                                          ref hitObjectList,
                                          ref uninheritedTimingPointList))
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
                return new Beatmap(path,
                                   version,
                                   generalList,
                                   editorList,
                                   metadataList,
                                   difficultyList,
                                   eventsList,
                                   timingPointList,
                                   coloursList,
                                   hitObjectList,
                                   bookmarks);
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-GET-BEATMAP");
                Common.WriteExceptionMessage(ex);
                return null;
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
                                                    ref List<int> bookmarks)
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
                                bookmarks.Add(int.Parse(timing));
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
        /// 赤線と小節線を取得する
        /// </summary>
        /// <param name="timingPointList">赤線のリスト</param>
        /// <param name="hitObjectList">小節線の格納先(小節線はHitObjectとしてカウントする)</param>
        /// <param name="uninheritedTimingPointList">赤線の格納先</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool GetRedLineAndBarline(ref List<TimingPoint> timingPointList,
                                                 ref List<HitObject> hitObjectList,
                                                 ref List<TimingPoint> uninheritedTimingPointList)
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
                            hitObjectOnBarLine.isBarline = true;
                        }
                    }
                }

                // ソートする
                timingPointList.Sort((a, b) => b.isRedLine.CompareTo(a.isRedLine));
                timingPointList.Sort((a, b) => a.time.CompareTo(b.time));
                hitObjectList.Sort((a, b) => a.time.CompareTo(b.time));
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
                    }
                    else if (red != null)
                    {
                        // 赤線のみある場合、SVは1.0
                        currentSv = 1.0m;
                    }

                    hitObject.bpm = currentBpm;
                    hitObject.sv = currentSv;
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
        /// osuファイルを作成する
        /// </summary>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="path">ファイル名</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        internal static bool ExportToOsuFile(Beatmap beatmap)
        {
            string workPath = Directory.GetCurrentDirectory() + Constants.WORK_DIRECTORY + "\\" + Path.GetFileName(beatmap.path);
            StreamWriter file = new StreamWriter(workPath, true, Encoding.GetEncoding("utf-8"));
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
                    string timingPointLine = timingPoint.time + "," +
                          (timingPoint.isRedLine ? (60000 / timingPoint.bpm).ToString("0.000000000000") : (-100 / timingPoint.sv).ToString("0.000000000000")) + "," +
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
                sb.Append(hitObject.curveSetting + ",");
                sb.Append(hitObject.slides + ",");
                sb.Append(hitObject.sliderLength);
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


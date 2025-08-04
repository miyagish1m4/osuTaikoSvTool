using osuTaikoSvTool.Models;

namespace osuTaikoSvTool.Utils.Helper
{
    class BeatmapHelper
    {
        /// <summary>
        /// "ファイル開く"ボタン押下時のダイアログ処理
        /// </summary>
        /// <returns>ファイルパス</returns>
        internal static string SelectFile()
        {
            string ret = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "ファイル選択ダイアログ";
                openFileDialog.Filter = "osuファイル(*.osu)|*.osu";
                openFileDialog.InitialDirectory = @"D:\osu!\Songs\";

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
        /// <returns>BG</returns>
        internal static Bitmap SetBgOnForm(string path)
        {
            try
            {
                var lines = File.ReadAllLines(path);
                string imageName = string.Empty;
                bool isGetBG = false;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == "//Background and Video events")
                    {
                        try
                        {
                            while (true)
                            {
                                string[] buff = lines[i + 1].Split(",");
                                if (buff[0] == "Video")
                                {
                                    i++;
                                    continue;
                                }
                                imageName = buff[2].Replace("\"", "");
                                isGetBG = true;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
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
                    Common.WriteInfoMessage("LOG-BG-FAIL");
                }
                return null;
            }
            catch (Exception ex)
            {
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
            var timingPointList = new List<TimingPoint>();
            var uninheritedTimingPointList = new List<TimingPoint>();
            var hitObjectList = new List<HitObject>();
            List<int> bookmarks = new List<int>();
            bool ret = true;
            try
            {
                var lines = File.ReadAllLines(path);
                // HitObject, TimingPoint を全取得
                if (!GetHitObjectsAndTimingPoints(lines,
                                                  ref timingPointList,
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
                return new Beatmap(timingPointList, hitObjectList, bookmarks);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// HitObjects と TimingPoints を取得する
        /// </summary>
        /// <param name="lines">osuファイルの中身</param>
        /// <param name="timingPointList">TimingPointの格納先</param>
        /// <param name="hitObjectList">HitObjectの格納先</param>
        /// <param name="bookmarks">Bookmarkの格納先</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool GetHitObjectsAndTimingPoints(string[] lines, ref List<TimingPoint> timingPointList, ref List<HitObject> hitObjectList, ref List<int> bookmarks)
        {
            bool isHitObjects = false;
            bool isTimingPoints = false;
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
                    if (line == "[HitObjects]")
                    {
                        isTimingPoints = false;
                    }

                    if (isTimingPoints)
                    {
                        timingPointList.Add(new TimingPoint(line));
                    }
                    if (isHitObjects)
                    {
                        hitObjectList.Add(new HitObject(line));
                    }
                    if (line == "[HitObjects]")
                    {
                        isHitObjects = true;
                    }
                    if (line == "[TimingPoints]")
                    {
                        isTimingPoints = true;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
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
        private static bool GetRedLineAndBarline(ref List<TimingPoint> timingPointList, ref List<HitObject> hitObjectList, ref List<TimingPoint> uninheritedTimingPointList)
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
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// HitObjectにSVとBPMを適用
        /// </summary>
        /// <param name="timingPointList">赤線のリスト</param>
        /// <param name="hitObjectList">適用対象のHitObject</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool SetSvAndBpmOnHitObjects(List<TimingPoint> timingPointList, ref List<HitObject> hitObjectList)
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
            catch
            {
                return false;
            }
        }
    }
}

using osuTaikoSvTool.Models;
using osuTaikoSvTool.Properties;
using osuTaikoSvTool.Utils;
using osuTaikoSvTool.Utils.Helper;

namespace osuTaikoSvTool
{
    public partial class osuTaikoSVTool : Form
    {
        #region クラス変数
        string path = "";
        bool isDSelected = false;
        bool isKSelected = false;
        bool isBigDSelected = false;
        bool isBigKSelected = false;
        bool isSliderSelected = false;
        bool isBigSliderSelected = false;
        bool isBarlineSelected = false;
        bool isBookMarkSelected = false;
        bool isCertainObject = false;
        bool isSV = false;
        bool isVolume = false;
        bool isBarline = false;
        bool isOffset = true;
        bool isKiai = false;
        bool isStartKiai = false;
        bool isEndKiai = false;
        int calculationCode = 0;
        int offsetValue = 0;
        #endregion
        public osuTaikoSVTool()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面ロード時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void osuTaikoSVTool_Load(object sender, EventArgs e)
        {
            Common.WriteInfoMessage("LOG-START");
            pictureBox5.Controls.Add(label1);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Common.InitializeLogDirectory();
            isStartKialButton.Enabled = false;
            isEndKialButton.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        /// <summary>
        /// アプリケーション終了時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            //ApplicationExitイベントハンドラを削除
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
            Common.WriteInfoMessage("LOG-END");
        }

        /// <summary>
        /// "ファイルを開く"ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileButton_Click(object sender, EventArgs e)
        {
            this.path = BeatmapHelper.SelectFile();
            if (this.path == null || this.path == "" || this.path == string.Empty)
            {
                return;
            }
            pictureBox5.Image = BeatmapHelper.SetBgOnForm(this.path);
            string fileName = Path.GetFileName(this.path);
            label1.Text = fileName;
        }

        /// <summary>
        /// 追加ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.path == null || this.path == "" || this.path == string.Empty)
                {
                    //ここにエラーメッセージを入れる miyagi
                    return;
                }
                #region beatmapInfo取得処理分割前バックアップ
                //var lines = File.ReadAllLines(path);
                //bool isHitObjects = false;
                //bool isTimingPoints = false;
                //var timingPointList = new List<TimingPoint>();
                //var uninheritedTimingPointList = new List<TimingPoint>();
                //var hitObjectList = new List<HitObject>();
                //List<int> bookmarks = new List<int>();

                //// HitObject, TimingPoint を全取得
                //foreach (var line in lines)
                //{
                //    if (line == "")
                //    {
                //        continue;
                //    }
                //    if (line.Length >= 9)
                //    {
                //        if (line.Substring(0, 9) == "Bookmarks")
                //        {
                //            string[] bookmarkParts = line.Split(':');
                //            List<string> stringBookmarks = new List<string>(bookmarkParts[1].Replace(" ", "").Split(","));
                //            foreach (var timing in stringBookmarks)
                //            {
                //                bookmarks.Add(int.Parse(timing));
                //            }
                //        }
                //    }
                //    if (line == "[HitObjects]")
                //    {
                //        isTimingPoints = false;
                //    }

                //    if (isTimingPoints)
                //    {
                //        timingPointList.Add(new TimingPoint(line));
                //    }
                //    if (isHitObjects)
                //    {
                //        hitObjectList.Add(new HitObject(line));
                //    }
                //    if (line == "[HitObjects]")
                //    {
                //        isHitObjects = true;
                //    }
                //    if (line == "[TimingPoints]")
                //    {
                //        isTimingPoints = true;
                //    }
                //}

                //// 小節線を取得する
                //// 最終ノーツを取る(これ以上は見ない)
                //hitObjectList.Sort((a, b) => a.time.CompareTo(b.time));
                //HitObject lastHitObject = hitObjectList.Last();

                //foreach (var timingPoint in timingPointList)
                //{
                //    if (timingPoint.isRedLine)
                //    {
                //        uninheritedTimingPointList.Add(timingPoint);
                //    }
                //}
                //for (int i = 0; i < uninheritedTimingPointList.Count; i++)
                //{
                //    decimal time = uninheritedTimingPointList[i].time;
                //    int timeEnd = lastHitObject.time;

                //    if (i + 1 < uninheritedTimingPointList.Count) timeEnd = uninheritedTimingPointList[i + 1].time;
                //    decimal timeBar = uninheritedTimingPointList[i].barLength;
                //    for (; time < timeEnd; time += timeBar)
                //    {
                //        int timeBarline = (int)Math.Floor(time);

                //        // すでに同じ time の HitObject が存在するかをチェック
                //        var hitObjectOnBarLine = hitObjectList.FirstOrDefault(h => h.time == timeBarline);
                //        if (hitObjectOnBarLine == null)
                //        {
                //            // 赤線を HitObject として追加
                //            hitObjectList.Add(new HitObject(timeBarline));
                //        }
                //        else
                //        {
                //            hitObjectOnBarLine.isBarline = true;
                //        }
                //    }
                //}

                //// ソートする
                //timingPointList.Sort((a, b) => b.isRedLine.CompareTo(a.isRedLine));
                //timingPointList.Sort((a, b) => a.time.CompareTo(b.time));
                //hitObjectList.Sort((a, b) => a.time.CompareTo(b.time));


                //// HitObject に SVとBPMを適用(ソート後)
                //int timingIndex = 0;
                //decimal currentBpm = 0;
                //decimal currentSv = 1.0m;
                //foreach (var hitObject in hitObjectList)
                //{
                //    // timingPoint を進める
                //    while (timingIndex + 1 < timingPointList.Count &&
                //           timingPointList[timingIndex + 1].time <= hitObject.time)
                //    {
                //        timingIndex++;
                //    }

                //    // 赤線と緑線が同じ time に複数ある可能性があるため、
                //    // その time の中で緑線があれば優先的に使う
                //    var timeGroup = timingPointList
                //        .Where(tp => tp.time == timingPointList[timingIndex].time)
                //        .ToList();

                //    var green = timeGroup.FirstOrDefault(tp => !tp.isRedLine);
                //    var red = timeGroup.FirstOrDefault(tp => tp.isRedLine);

                //    if (red != null)
                //    {
                //        currentBpm = red.bpm;
                //    }
                //    if (green != null)
                //    {
                //        currentSv = green.sv;
                //    }
                //    else if (red != null)
                //    {
                //        // 赤線のみある場合、SVは1.0
                //        currentSv = 1.0m;
                //    }

                //    hitObject.bpm = currentBpm;
                //    hitObject.sv = currentSv;
                //}

                //// BeatmapInfo に渡す
                //Beatmap beatmapInfo = new Beatmap(timingPointList, hitObjectList, bookmarks);
                #endregion
                Beatmap beatmapInfo = BeatmapHelper.GetBeatmapData(this.path);
                return;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG-EXCEPTION");
                Common.WriteErrorMessage(ex.Message + "\n" + ex.StackTrace);
                return;
            }
        }

        /// <summary>
        /// ユーザが入力したタイミングを変換する処理
        /// </summary>
        /// <param name="baseTiming">入力したタイミング (mm:ss:fff (notes))</param>
        /// <param name="returnTiming">変換後のタイミング (mmssfff)</param>
        /// <returns>処理が正常終了した場合はtrue、異常終了した場合はfalse</returns>
        private bool ConvertTiming(string baseTiming, ref int returnTiming)
        {
            try
            {
                string[] arr = baseTiming.Split(':');
                arr[2] = arr[2].Substring(0, 3);
                returnTiming = Convert.ToInt32(arr[2]) +
                               Convert.ToInt32(arr[1]) * 1000 +
                               Convert.ToInt32(arr[0]) * 60000;
                return true;
            }
            catch (Exception e)
            {
                Common.WriteErrorMessage("LOG-EXCEPTION");
                Common.WriteErrorMessage(e.Message + "\n" + e.StackTrace);
                return false;
            }
        }

        private void disableSV_CheckedChanged(object sender, EventArgs e)
        {
            isSV = disableSV.Checked;
            if (isSV == true)
            {
                SVFrom.Enabled = true;
                SVTo.Enabled = true;
                SVFrom.BackColor = SystemColors.Window;
                SVTo.BackColor = SystemColors.Window;
                swapSVButton.Enabled = true;
                swapSVButton.ForeColor = Color.Cyan;
                swapSVButton.FlatAppearance.BorderColor = Color.Cyan;
                arithmeticButton.Enabled = true;
                geometricButton.Enabled = true;
            }
            else
            {
                SVFrom.Text = string.Empty;
                SVTo.Text = string.Empty;
                SVFrom.Enabled = false;
                SVTo.Enabled = false;
                SVFrom.BackColor = SystemColors.WindowFrame;
                SVTo.BackColor = SystemColors.WindowFrame;
                swapSVButton.Enabled = false;
                swapSVButton.ForeColor = SystemColors.WindowFrame;
                swapSVButton.FlatAppearance.BorderColor = SystemColors.WindowFrame;
                arithmeticButton.Enabled = false;
                geometricButton.Enabled = false;

            }
        }

        private void disableVolume_CheckedChanged(object sender, EventArgs e)
        {
            isVolume = disableVolume.Checked;
            if (isVolume == true)
            {
                volumeFrom.Enabled = true;
                volumeTo.Enabled = true;
                volumeFrom.BackColor = SystemColors.Window;
                volumeTo.BackColor = SystemColors.Window;
                swapVolumeButton.Enabled = true;
                swapVolumeButton.ForeColor = Color.Cyan;
                swapVolumeButton.FlatAppearance.BorderColor = Color.Cyan;
            }
            else
            {
                volumeFrom.Text = string.Empty;
                volumeTo.Text = string.Empty;
                volumeFrom.Enabled = false;
                volumeTo.Enabled = false;
                volumeFrom.BackColor = SystemColors.WindowFrame;
                volumeTo.BackColor = SystemColors.WindowFrame;
                swapVolumeButton.Enabled = false;
                swapVolumeButton.ForeColor = SystemColors.WindowFrame;
                swapVolumeButton.FlatAppearance.BorderColor = SystemColors.WindowFrame;

            }
        }

        private void includeBarline_CheckedChanged(object sender, EventArgs e)
        {
            isBarline = includeBarline.Checked;
        }

        private void arithmeticButton_CheckedChanged(object sender, EventArgs e)
        {
            calculationCode = 1;
        }

        private void geometricButton_CheckedChanged(object sender, EventArgs e)
        {
            calculationCode = 2;
        }

        private void enableOffset_CheckedChanged(object sender, EventArgs e)
        {
            isOffset = enableOffset.Checked;
            if (isOffset == true)
            {
                offsetTextbox.Text = string.Empty;
                offsetTextbox.BackColor = SystemColors.Window;
                offsetTextbox.Enabled = true;
            }
            else
            {
                offsetTextbox.BackColor = SystemColors.WindowFrame;
                offsetTextbox.Enabled = false;
            }
        }

        /// <summary>
        /// "バックアップフォルダ"ボタン押下時バックアップフォルダを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backupFolderButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("EXPLORER.EXE", Directory.GetCurrentDirectory() + Constants.BACKUP_DIRECTORY);
        }
        private void swapTimingButton_Click(object sender, EventArgs e)
        {
            string timingBuff = "";
            timingBuff = timingFrom.Text;
            timingFrom.Text = timingTo.Text;
            timingTo.Text = timingBuff;
        }
        private void swapSVButton_Click(object sender, EventArgs e)
        {
            string SVBuff = "";
            SVBuff = SVFrom.Text;
            SVFrom.Text = SVTo.Text;
            SVTo.Text = SVBuff;
        }
        private void swapVolumeButton_Click(object sender, EventArgs e)
        {
            string volumeBuff = "";
            volumeBuff = volumeFrom.Text;
            volumeFrom.Text = volumeTo.Text;
            volumeTo.Text = volumeBuff;

        }
        private void isKiaiButton_CheckedChanged(object sender, EventArgs e)
        {
            isKiai = isKiaiButton.Checked;
            if (isKiaiButton.Checked)
            {
                isStartKialButton.Enabled = true;
                isEndKialButton.Enabled = true;
            }
            else
            {
                isStartKialButton.Enabled = false;
                isEndKialButton.Enabled = false;
                isStartKialButton.Checked = false;
                isEndKialButton.Checked = false;
            }
        }
        private void isStartKialButton_CheckedChanged(object sender, EventArgs e)
        {
            isStartKiai = isStartKialButton.Checked;
        }
        private void isEndKialButton_CheckedChanged(object sender, EventArgs e)
        {
            isEndKiai = isEndKialButton.Checked;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isDSelected = !isDSelected;
            if (isDSelected)
            {
                pictureBox1.Image = Properties.Resources.d_selected;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.d;
            }
        }
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            isBigDSelected = !isBigDSelected;
            if (isBigDSelected)
            {
                pictureBox3.Image = Properties.Resources.d_selected;
            }
            else
            {
                pictureBox3.Image = Properties.Resources.d;
            }
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            isKSelected = !isKSelected;
            if (isKSelected)
            {
                pictureBox2.Image = Properties.Resources.k_selected;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.k;
            }
        }
        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            isBigKSelected = !isBigKSelected;
            if (isBigKSelected)
            {
                pictureBox4.Image = Properties.Resources.k_selected;
            }
            else
            {
                pictureBox4.Image = Properties.Resources.k;
            }
        }
        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            isSliderSelected = !isSliderSelected;
            if (isSliderSelected)
            {
                pictureBox6.Image = Properties.Resources.slider_selected;
            }
            else
            {
                pictureBox6.Image = Properties.Resources.slider;
            }

        }
        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            isBigSliderSelected = !isBigSliderSelected;
            if (isBigSliderSelected)
            {
                pictureBox7.Image = Properties.Resources.slider_selected;
            }
            else
            {
                pictureBox7.Image = Properties.Resources.slider;
            }

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            isBookMarkSelected = radioButton1.Checked;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            isBarlineSelected = radioButton2.Checked;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            isCertainObject = radioButton3.Checked;
        }
    }
}
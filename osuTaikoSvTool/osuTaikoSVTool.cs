using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Reflection.Emit;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace osuTaikoSvTool
{
    public partial class osuTaikoSVTool : Form
    {
        string infoMessagePath = "";
        string errorMessagePath = "";
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
        DateTime currentDateTime;
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
            pictureBox5.Controls.Add(label1);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            currentDateTime = DateTime.Now;
            // 新規ファイルの絶対パス
            infoMessagePath = Directory.GetCurrentDirectory() + Constants.INFO_MESSAGE_DIRECTORY + "\\Info_" + String.Format("{0:yyyyMMdd}", currentDateTime) + Constants.LOG_EXTENSION;
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.BACKUP_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.BACKUP_DIRECTORY);
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.WORK_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.WORK_DIRECTORY);
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.INFO_MESSAGE_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.INFO_MESSAGE_DIRECTORY);
            }
            if (!File.Exists(infoMessagePath))
            {
                // 新規ファイル作成
                File.Create(infoMessagePath).Close();
            }
            errorMessagePath = Directory.GetCurrentDirectory() + Constants.ERROR_MESSAGE_DIRECTORY + "\\error_" + String.Format("{0:yyyyMMdd}", currentDateTime) + Constants.LOG_EXTENSION;
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.ERROR_MESSAGE_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.ERROR_MESSAGE_DIRECTORY);
            }
            if (!File.Exists(errorMessagePath))
            {
                // 新規ファイル作成
                File.Create(errorMessagePath).Close();
            }
            WriteInfoMessage("アプリケーションを開始します。");
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
            WriteInfoMessage("アプリケーションを終了します。");

            //ApplicationExitイベントハンドラを削除
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
        }

        /// <summary>
        /// Infoメッセージの書き込み処理
        /// </summary>
        /// <param name="message"></param>
        private void WriteInfoMessage(string message)
        {
            currentDateTime = DateTime.Now;
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.INFO_MESSAGE_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.INFO_MESSAGE_DIRECTORY);
            }
            if (!File.Exists(infoMessagePath))
            {
                // 新規ファイル作成
                File.Create(infoMessagePath).Close();
            }
            using (StreamWriter writer = new StreamWriter(infoMessagePath, true, Encoding.GetEncoding("utf-8")))
            {
                writer.WriteLine(currentDateTime.ToString("[HH:mm:ss.fff]") + " " + message);
            }
        }

        /// <summary>
        /// Errorメッセージの書き込み処理
        /// </summary>
        /// <param name="message"></param>
        private void WriteErrorMessage(string message)
        {
            currentDateTime = DateTime.Now;
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.ERROR_MESSAGE_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.ERROR_MESSAGE_DIRECTORY);
            }
            if (!File.Exists(errorMessagePath))
            {
                // 新規ファイル作成
                File.Create(errorMessagePath).Close();
            }
            using (StreamWriter writer = new StreamWriter(errorMessagePath, true, Encoding.GetEncoding("utf-8")))
            {
                writer.WriteLine(currentDateTime.ToString("[HH:mm:ss.fff]") + " " + message);
            }
        }

        /// <summary>
        /// "ファイルを開く"ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileButton_Click(object sender, EventArgs e)
        {
            string pathBuff = SelectFile();
            if (pathBuff == null || pathBuff == "" || pathBuff == string.Empty)
            {
                return;
            }
            path = pathBuff;
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
                Bitmap canvas = new Bitmap(pictureBox5.Width, pictureBox5.Height);
                Graphics g = Graphics.FromImage(canvas);
                Bitmap image = new Bitmap(Path.GetDirectoryName(path) + "\\" + imageName);
                g.InterpolationMode =
                    System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(image, 0, 0, 384, 216);
                g.InterpolationMode =
                    System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                image.Dispose();
                g.Dispose();
                pictureBox5.Image = canvas;
            }
            else
            {
                WriteInfoMessage("BGの取得に失敗しました。");
            }
            string fileName = Path.GetFileName(path);
            label1.Text = fileName;

            // TimingPoint の取得
            // Note の取得
            // TimingPoint から Barline を取得 し、Note に追加
            //
        }

        /// <summary>
        /// "ファイル開く"ボタン押下時のダイアログ処理
        /// </summary>
        /// <returns>開いたファイルのパス</returns>
        private string SelectFile()
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
        /// 追加ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var lines = File.ReadAllLines(path);
                bool isHitObjects = false;
                bool isTimingPoints = false;
                var timingPointList = new List<TimingPoint>();
                var uninheritedTimingPointList = new List<TimingPoint>();
                var hitObjectList = new List<HitObject>();

                // HitObject, TimingPoint を全取得
                foreach (var line in lines)
                {
                    if (line == "")
                    {
                        continue;
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

                // 小節線を取得する
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


                // HitObject に SVとBPMを適用(ソート後)
                int timingIndex = 0;
                decimal currentBpm = 0;
                decimal currentSv = 1.0m;
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

                // BeatmapInfo に渡す
                return;
            }
            catch (Exception ex) 
            {
                WriteErrorMessage("例外エラーが発生しました。");
                WriteErrorMessage(ex.Message + "\n" + ex.StackTrace);
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
                WriteErrorMessage("例外エラーが発生しました。");
                WriteErrorMessage(e.Message + "\n" + e.StackTrace);
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
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
        Beatmap beatmapInfo = null;
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
            beatmapInfo = BeatmapHelper.GetBeatmapData(this.path);
            pictureBox5.Image = BeatmapHelper.SetBgOnForm(this.path, beatmapInfo.events);
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
                BeatmapHelper.CreateOsuFile(beatmapInfo, this.path);
                return;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG-ERROR-EXCEPTION");
                Common.WriteErrorMessage(ex.Message + "\n" + ex.StackTrace);
                return;
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
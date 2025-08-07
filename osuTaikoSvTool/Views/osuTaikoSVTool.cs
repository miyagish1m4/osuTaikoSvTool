using osuTaikoSvTool.Models;
using osuTaikoSvTool.Properties;
using osuTaikoSvTool.Utils;
using osuTaikoSvTool.Utils.Helper;
using osuTaikoSvTool.Views;
using osuTaikoSvTool.Services;

namespace osuTaikoSvTool
{
    public partial class osuTaikoSVTool : Form
    {
        #region クラス変数
        string path = "";
        string songsDirectory = "";
        int objectCode = 0;
        int calculationCode = 0;
        bool[] isOnlySpecificHitObjectArray = new bool[7] { false, false, false, false, false, false, false };
        Beatmap? beatmapInfo;
        UserInputData? userInputData;
        #endregion
        public osuTaikoSVTool()
        {
            InitializeComponent();
        }
        private void osuTaikoSVTool_Load(object sender, EventArgs e)
        {
            Common.InitializeDirectoryAndFiles();
            Common.WriteInfoMessage("LOG-I-START");
            songsDirectory = Common.InitializeConfigDirectory();
            if (songsDirectory == "")
            {
                Application.Exit();
            }
            picDisplayBg.Controls.Add(lblFileName);
            picDisplayBg.Controls.Add(pnlDragDropArea);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            chkEnableKiaiStart.Enabled = false;
            chkEnableKiaiEnd.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            //ApplicationExitイベントハンドラを削除
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
            Common.WriteInfoMessage("LOG-I-END");
        }
        /// <summary>
        /// 譜面情報取得処理
        /// </summary>
        private void GetBeatmapInfo()
        {
            beatmapInfo = BeatmapHelper.GetBeatmapData(this.path);
            if (beatmapInfo == null)
            {
                MessageBox.Show(Common.WriteDialogMessage("E_A-D-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            picDisplayBg.Image = BeatmapHelper.SetBgOnForm(this.path, beatmapInfo.events);
            string fileName = Path.GetFileName(this.path);
            lblFileName.Text = fileName;
        }
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            this.path = BeatmapHelper.SelectFile(songsDirectory);
            if (this.path == null || this.path == "" || this.path == string.Empty)
            {
                return;
            }
            GetBeatmapInfo();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.path == null || this.path == string.Empty)
                {
                    MessageBox.Show(Common.WriteDialogMessage("E_V-EM-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.userInputData = UserInputDataHelper.SetUserInputData(txtTimingFrom.Text,
                                                                          txtTimingTo.Text,
                                                                          chkSvEnable.Checked,
                                                                          txtSvFrom.Text,
                                                                          txtSvTo.Text,
                                                                          chkEnableVolume.Checked,
                                                                          txtVolumeFrom.Text,
                                                                          txtVolumeTo.Text,
                                                                          calculationCode,
                                                                          chkEnableIncludeBarline.Checked,
                                                                          chkEnableOffset.Checked,
                                                                          txtOffset.Text,
                                                                          chkEnableBeatSnap.Checked,
                                                                          txtBeatSnap.Text,
                                                                          chkEnableKiai.Checked,
                                                                          chkEnableKiaiStart.Checked,
                                                                          chkEnableKiaiEnd.Checked,
                                                                          rdoOnlyBarline.Checked,
                                                                          rdoOnlyBookMark.Checked,
                                                                          rdoOnlySpecificHitObject.Checked,
                                                                          objectCode,
                                                                          Constants.EXCECUTE_ADD);
                if (userInputData == null)
                {
                    return;
                }
                if (!SVCalculatorSevice.Add(userInputData, beatmapInfo))
                {
                    beatmapInfo = null;
                    return;
                }
                if (BeatmapHelper.ExportToOsuFile(beatmapInfo))
                {
                    beatmapInfo = null;
                    if (!UserInputDataHelper.SerializeUserInputData(userInputData))
                    {
                        userInputData = null;
                        MessageBox.Show(Common.WriteDialogMessage("E_A-P-001"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    userInputData = null;
                    MessageBox.Show(Common.WriteDialogMessage("I_A-P-001"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    beatmapInfo = null;
                    userInputData = null;
                    MessageBox.Show(Common.WriteDialogMessage("E_A-P-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                beatmapInfo = null;
                userInputData = null;
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return;
            }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.path == null || this.path == string.Empty)
                {
                    MessageBox.Show(Common.WriteDialogMessage("E_V-EM-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.userInputData = UserInputDataHelper.SetUserInputData(txtTimingFrom.Text,
                                                                          txtTimingTo.Text,
                                                                          chkSvEnable.Checked,
                                                                          txtSvFrom.Text,
                                                                          txtSvTo.Text,
                                                                          chkEnableVolume.Checked,
                                                                          txtVolumeFrom.Text,
                                                                          txtVolumeTo.Text,
                                                                          calculationCode,
                                                                          chkEnableIncludeBarline.Checked,
                                                                          chkEnableOffset.Checked,
                                                                          txtOffset.Text,
                                                                          chkEnableBeatSnap.Checked,
                                                                          txtBeatSnap.Text,
                                                                          chkEnableKiai.Checked,
                                                                          chkEnableKiaiStart.Checked,
                                                                          chkEnableKiaiEnd.Checked,
                                                                          rdoOnlyBarline.Checked,
                                                                          rdoOnlyBookMark.Checked,
                                                                          rdoOnlySpecificHitObject.Checked,
                                                                          objectCode,
                                                                          Constants.EXCECUTE_REMOVE);
                if (userInputData == null)
                {
                    return;
                }
                if (SVCalculatorSevice.Remove(userInputData, ref beatmapInfo))
                {
                    if (BeatmapHelper.ExportToOsuFile(beatmapInfo))
                    {
                        if (!UserInputDataHelper.SerializeUserInputData(userInputData))
                        {
                            MessageBox.Show(Common.WriteDialogMessage("E_A-P-001"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        MessageBox.Show(Common.WriteDialogMessage("I_A-P-001"), "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(Common.WriteDialogMessage("E_A-P-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return;
            }
        }
        private void btnBackup_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("EXPLORER.EXE", Directory.GetCurrentDirectory() + Constants.BACKUP_DIRECTORY);
        }
        private void btnSwapTiming_Click(object sender, EventArgs e)
        {
            string timingBuff = "";
            timingBuff = txtTimingFrom.Text;
            txtTimingFrom.Text = txtTimingTo.Text;
            txtTimingTo.Text = timingBuff;
        }
        private void btnSwapSv_Click(object sender, EventArgs e)
        {
            string SVBuff = "";
            SVBuff = txtSvFrom.Text;
            txtSvFrom.Text = txtSvTo.Text;
            txtSvTo.Text = SVBuff;
        }
        private void btnSwapVolume_Click(object sender, EventArgs e)
        {
            string volumeBuff = "";
            volumeBuff = txtVolumeFrom.Text;
            txtVolumeFrom.Text = txtVolumeTo.Text;
            txtVolumeTo.Text = volumeBuff;

        }
        private void chkSvEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSvEnable.Checked)
            {
                txtSvFrom.Enabled = true;
                txtSvTo.Enabled = true;
                txtSvFrom.BackColor = SystemColors.Window;
                txtSvTo.BackColor = SystemColors.Window;
                btnSwapSv.Enabled = true;
                btnSwapSv.ForeColor = Color.Cyan;
                btnSwapSv.FlatAppearance.BorderColor = Color.Cyan;
                rdoArithmetic.Enabled = true;
                rdoGeometric.Enabled = true;
            }
            else
            {
                txtSvFrom.Text = string.Empty;
                txtSvTo.Text = string.Empty;
                txtSvFrom.Enabled = false;
                txtSvTo.Enabled = false;
                txtSvFrom.BackColor = SystemColors.WindowFrame;
                txtSvTo.BackColor = SystemColors.WindowFrame;
                btnSwapSv.Enabled = false;
                btnSwapSv.ForeColor = SystemColors.WindowFrame;
                btnSwapSv.FlatAppearance.BorderColor = SystemColors.WindowFrame;
                rdoArithmetic.Enabled = false;
                rdoGeometric.Enabled = false;

            }
        }
        private void chkEnableVolume_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableVolume.Checked == true)
            {
                txtVolumeFrom.Enabled = true;
                txtVolumeTo.Enabled = true;
                txtVolumeFrom.BackColor = SystemColors.Window;
                txtVolumeTo.BackColor = SystemColors.Window;
                btnSwapVolume.Enabled = true;
                btnSwapVolume.ForeColor = Color.Cyan;
                btnSwapVolume.FlatAppearance.BorderColor = Color.Cyan;
            }
            else
            {
                txtVolumeFrom.Text = string.Empty;
                txtVolumeTo.Text = string.Empty;
                txtVolumeFrom.Enabled = false;
                txtVolumeTo.Enabled = false;
                txtVolumeFrom.BackColor = SystemColors.WindowFrame;
                txtVolumeTo.BackColor = SystemColors.WindowFrame;
                btnSwapVolume.Enabled = false;
                btnSwapVolume.ForeColor = SystemColors.WindowFrame;
                btnSwapVolume.FlatAppearance.BorderColor = SystemColors.WindowFrame;

            }
        }
        private void chkEnableOffset_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableOffset.Checked)
            {
                txtOffset.Text = string.Empty;
                txtOffset.BackColor = SystemColors.Window;
                txtOffset.Enabled = true;
            }
            else
            {
                txtOffset.BackColor = SystemColors.WindowFrame;
                txtOffset.Enabled = false;
            }
        }
        private void chkEnableBeatSnap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableBeatSnap.Checked)
            {
                txtBeatSnap.Text = string.Empty;
                txtBeatSnap.BackColor = SystemColors.Window;
                txtBeatSnap.Enabled = true;
            }
            else
            {
                txtBeatSnap.BackColor = SystemColors.WindowFrame;
                txtBeatSnap.Enabled = false;
            }

        }
        private void chkEnableKiai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableKiai.Checked)
            {
                chkEnableKiaiStart.Enabled = true;
                chkEnableKiaiEnd.Enabled = true;
            }
            else
            {
                chkEnableKiaiStart.Enabled = false;
                chkEnableKiaiEnd.Enabled = false;
                chkEnableKiaiStart.Checked = false;
                chkEnableKiaiEnd.Checked = false;
            }
        }
        private void picSpecificNormalDong_MouseDown(object sender, MouseEventArgs e)
        {
            if (isOnlySpecificHitObjectArray[0] = !isOnlySpecificHitObjectArray[0])
            {
                picSpecificNormalDong.Image = Properties.Resources.d_selected;
                objectCode += 1;
            }
            else
            {
                picSpecificNormalDong.Image = Properties.Resources.d;
                objectCode -= 1;
            }
        }
        private void picSpecificFinisherDong_MouseDown(object sender, MouseEventArgs e)
        {
            if (isOnlySpecificHitObjectArray[1] = !isOnlySpecificHitObjectArray[1])
            {
                picSpecificFinisherDong.Image = Properties.Resources.d_selected;
                objectCode += 2;
            }
            else
            {
                picSpecificFinisherDong.Image = Properties.Resources.d;
                objectCode -= 2;
            }
        }
        private void picSpecificNormalKa_MouseDown(object sender, MouseEventArgs e)
        {
            if (isOnlySpecificHitObjectArray[2] = !isOnlySpecificHitObjectArray[2])
            {
                picSpecificNormalKa.Image = Properties.Resources.k_selected;
                objectCode += 4;
            }
            else
            {
                picSpecificNormalKa.Image = Properties.Resources.k;
                objectCode -= 4;
            }
        }
        private void picSpecificFinisherKa_MouseDown(object sender, MouseEventArgs e)
        {
            if (isOnlySpecificHitObjectArray[3] = !isOnlySpecificHitObjectArray[3])
            {
                picSpecificFinisherKa.Image = Properties.Resources.k_selected;
                objectCode += 8;
            }
            else
            {
                picSpecificFinisherKa.Image = Properties.Resources.k;
                objectCode -= 8;
            }
        }
        private void picSpecificNormalSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if (isOnlySpecificHitObjectArray[4] = !isOnlySpecificHitObjectArray[4])
            {
                picSpecificNormalSlider.Image = Properties.Resources.slider_selected;
                objectCode += 16;
            }
            else
            {
                picSpecificNormalSlider.Image = Properties.Resources.slider;
                objectCode -= 16;
            }
        }
        private void picSpecificFinisherSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if (isOnlySpecificHitObjectArray[5] = !isOnlySpecificHitObjectArray[5])
            {
                picSpecificFinisherSlider.Image = Properties.Resources.slider_selected;
                objectCode += 32;
            }
            else
            {
                picSpecificFinisherSlider.Image = Properties.Resources.slider;
                objectCode -= 32;
            }
        }
        private void picSpecificNormalSpinner_MouseDown(object sender, MouseEventArgs e)
        {
            {
                if (isOnlySpecificHitObjectArray[6] = !isOnlySpecificHitObjectArray[6])
                {
                    picSpecificNormalSpinner.Image = Properties.Resources.spinner_selected;
                    objectCode += 64;
                }
                else
                {
                    picSpecificNormalSpinner.Image = Properties.Resources.spinner;
                    objectCode -= 64;
                }
            }
        }
        private void rdoArithmetic_CheckedChanged(object sender, EventArgs e)
        {
            calculationCode = 1;
        }
        private void rdoGeometric_CheckedChanged(object sender, EventArgs e)
        {
            calculationCode = 2;
        }
        private void rdoOnlySpecificHitObject_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnlySpecificHitObject.Checked)
            {
                // pictureBoxに設定されているMouseDownイベントを設定する
                picSpecificNormalDong.MouseDown += picSpecificNormalDong_MouseDown;
                picSpecificFinisherDong.MouseDown += picSpecificFinisherDong_MouseDown;
                picSpecificNormalKa.MouseDown += picSpecificNormalKa_MouseDown;
                picSpecificFinisherKa.MouseDown += picSpecificFinisherKa_MouseDown;
                picSpecificNormalSlider.MouseDown += picSpecificNormalSlider_MouseDown;
                picSpecificFinisherSlider.MouseDown += picSpecificFinisherSlider_MouseDown;
                picSpecificNormalSpinner.MouseDown += picSpecificNormalSpinner_MouseDown;
                // rdoOnlyBookMarkとrdoOnlyBarlineに設定されているCheckedChangedイベントを外す
                // 事前に外さないと次の行のfalseを代入する処理でイベントが走る為
                rdoOnlyBookMark.CheckedChanged -= rdoOnlyBookMark_CheckedChanged;
                rdoOnlyBarline.CheckedChanged -= rdoOnlyBarline_CheckedChanged;
                rdoOnlyBookMark.Checked = false;
                rdoOnlyBarline.Checked = false;
                // CheckedChangedイベントを設定しなおす
                rdoOnlyBookMark.CheckedChanged += rdoOnlyBookMark_CheckedChanged;
                rdoOnlyBarline.CheckedChanged += rdoOnlyBarline_CheckedChanged;

            }
            else
            {
                // pictureBoxに設定されているMouseDownイベントを外す
                picSpecificNormalDong.MouseDown -= picSpecificNormalDong_MouseDown;
                picSpecificFinisherDong.MouseDown -= picSpecificFinisherDong_MouseDown;
                picSpecificNormalKa.MouseDown -= picSpecificNormalKa_MouseDown;
                picSpecificFinisherKa.MouseDown -= picSpecificFinisherKa_MouseDown;
                picSpecificNormalSlider.MouseDown -= picSpecificNormalSlider_MouseDown;
                picSpecificFinisherSlider.MouseDown -= picSpecificFinisherSlider_MouseDown;
                picSpecificNormalSpinner.MouseDown -= picSpecificNormalSpinner_MouseDown;
                // 画像を元に戻す
                picSpecificNormalDong.Image = Properties.Resources.d;
                picSpecificFinisherDong.Image = Properties.Resources.d;
                picSpecificNormalKa.Image = Properties.Resources.k;
                picSpecificFinisherKa.Image = Properties.Resources.k;
                picSpecificNormalSlider.Image = Properties.Resources.slider;
                picSpecificFinisherSlider.Image = Properties.Resources.slider;
                picSpecificNormalSpinner.Image = Properties.Resources.spinner;
                // 選択肢とコードの初期化
                isOnlySpecificHitObjectArray = new bool[6] { false, false, false, false, false, false };
                objectCode = 0;
            }
        }
        /// <summary>
        /// DragDropの共通イベントハンドラー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonDragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            // 譜面を2個以上ドラッグ&ドロップした場合は、最初の1つだけを読み込む
            path = files[0];
            if (path.LastIndexOf(Constants.OSU_EXTENSION) != -1)
            {
                GetBeatmapInfo();
            }
            else
            {
                MessageBox.Show(Common.WriteDialogMessage("W_A-EXT-001"), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// DragEnterの共通イベントハンドラー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonDragEnter(object sender, DragEventArgs e)
        {
            // マウスポインター形状変更
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void rdoOnlyBookMark_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnlySpecificHitObject.Checked)
            {
                rdoOnlySpecificHitObject.Checked = false;
            }
        }

        private void rdoOnlyBarline_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnlySpecificHitObject.Checked)
            {
                rdoOnlySpecificHitObject.Checked = false;
            }
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            Form historyForm = new HistoryForm();
            historyForm.ShowDialog();

        }
    }
}
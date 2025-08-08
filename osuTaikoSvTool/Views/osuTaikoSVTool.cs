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
        int beforeSelectedTabIndex = 0;
        #endregion
        #region メソッド
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public osuTaikoSVTool()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 処理項目タブが"追加"の時のコントロールの初期化処理
        /// </summary>
        private void InitializeAddControls()
        {
            tabSetType.SelectedIndex = 0;
            InitializeHitObjectsControls();
            InitializeBeatSnapControls();
        }
        /// <summary>
        /// 実行項目タブが"変更"の時のコントロールの初期化処理
        /// </summary>
        private void InitializeModifyControls()
        {
            rdoAllHitObjectsModify.Checked = true;
            picSpecificNormalDongModify.Visible = false;
            picSpecificFinisherDongModify.Visible = false;
            picSpecificNormalKaModify.Visible = false;
            picSpecificFinisherKaModify.Visible = false;
            picSpecificNormalSliderModify.Visible = false;
            picSpecificFinisherSliderModify.Visible = false;
            picSpecificNormalSpinnerModify.Visible = false;
            lblSpecificNormalModify.Visible = false;
            lblSpecificFinisherModify.Visible = false;
            lblSpecificGridLineModify.Visible = false;
            lblSpecificGridLine2Modify.Visible = false;
            chkEnableKiaiModify.Checked = false;
            chkEnableKiaiStartModify.Visible = false;
            chkEnableKiaiEndModify.Visible = false;
            lblKiaiStartModify.Visible = false;
            lblKiaiEndModify.Visible = false;
        }
        /// <summary>
        /// 実行項目タブが"削除"の時のコントロールの初期化処理
        /// </summary>
        private void InitializeRemoveControls()
        {
            chkEnableSv.Checked = false;
            chkEnableVolume.Checked = false;
            chkEnableSv.Enabled = false;
            chkEnableVolume.Enabled = false;
            chkEnableSv.Visible = false;
            chkEnableVolume.Visible = false;
        }
        /// <summary>
        /// 実行項目タブが"削除"から変更された時のコントロールの初期化処理
        /// </summary>
        private void ReturnRemoveControls()
        {
            chkEnableSv.Checked = true;
            chkEnableVolume.Checked = true;
            chkEnableSv.Enabled = true;
            chkEnableVolume.Enabled = true;
            chkEnableSv.Visible = true;
            chkEnableVolume.Visible = true;
        }
        /// <summary>
        /// 処理項目タブが"Objectsのみ"の時のコントロールの初期化処理
        /// </summary>
        private void InitializeHitObjectsControls()
        {
            rdoAllHitObjects.Checked = true;
            picSpecificNormalDong.Visible = false;
            picSpecificFinisherDong.Visible = false;
            picSpecificNormalKa.Visible = false;
            picSpecificFinisherKa.Visible = false;
            picSpecificNormalSlider.Visible = false;
            picSpecificFinisherSlider.Visible = false;
            picSpecificNormalSpinner.Visible = false;
            lblSpecificNormal.Visible = false;
            lblSpecificFinisher.Visible = false;
            lblSpecificGridLine.Visible = false;
            lblSpecificGridLine2.Visible = false;
            chkEnableKiai.Checked = false;
            chkEnableKiaiStart.Visible = false;
            chkEnableKiaiEnd.Visible = false;
            lblKiaiStart.Visible = false;
            lblKiaiEnd.Visible = false;
            chkEnableOffset.Checked = true;
            chkEnableIncludeBarline.Checked = false;
        }
        /// <summary>
        /// 処理項目タブが"ビートスナップ間隔"の時のコントロールの初期化処理
        /// </summary>
        private void InitializeBeatSnapControls()
        {
            chkEnableBeatSnap.Checked = false;
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
        #endregion
        #region イベントハンドラ
        private void osuTaikoSVTool_Load(object sender, EventArgs e)
        {
            Common.InitializeDirectoryAndFiles();
            Common.WriteInfoMessage("LOG_I-START");
            songsDirectory = Common.InitializeConfigDirectory();
            if (songsDirectory == "")
            {
                Application.Exit();
            }
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            InitializeAddControls();
            InitializeModifyControls();
            picDisplayBg.Controls.Add(lblFileName);
            picDisplayBg.Controls.Add(pnlDragDropArea);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        private void osuTaikoSVTool_Shown(object sender, EventArgs e)
        {
            // 画面がタスクバーと被らないように位置の変更をする
            if (this.WindowState == System.Windows.Forms.FormWindowState.Normal)
            {
                var rect = System.Windows.Forms.Screen.GetWorkingArea(this);
                this.Left = (rect.Left + rect.Width > this.Left + this.Width) ? this.Left : rect.Left + rect.Width - this.Width;
                this.Left = (rect.Left < this.Left) ? this.Left : rect.Left;
                this.Top = (rect.Top + rect.Height > this.Top + this.Height) ? this.Top : rect.Top + rect.Height - this.Height;
                this.Top = (rect.Top < this.Top) ? this.Top : rect.Top;
            }
        }
        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            //ApplicationExitイベントハンドラを削除
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
            Common.WriteInfoMessage("LOG_I-END");
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
                                                                          chkEnableSv.Checked,
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
                                                                          rdoAllHitObjects.Checked,
                                                                          rdoOnlyBarline.Checked,
                                                                          rdoOnlyBookMark.Checked,
                                                                          rdoOnlySpecificHitObject.Checked,
                                                                          objectCode,
                                                                          Constants.EXCECUTE_ADD);
                if (userInputData == null)
                {
                    return;
                }
                if (!SVCalculatorService.Add(userInputData, beatmapInfo))
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
            this.userInputData = UserInputDataHelper.SetUserInputData(txtTimingFrom.Text,
                                                                      txtTimingTo.Text,
                                                                      chkEnableSv.Checked,
                                                                      txtSvFrom.Text,
                                                                      txtSvTo.Text,
                                                                      chkEnableVolume.Checked,
                                                                      txtVolumeFrom.Text,
                                                                      txtVolumeTo.Text,
                                                                      calculationCode,
                                                                      chkEnableIncludeBarlineModify.Checked,
                                                                      chkEnableOffset.Checked,
                                                                      txtOffset.Text,
                                                                      chkEnableBeatSnap.Checked,
                                                                      txtBeatSnap.Text,
                                                                      chkEnableKiaiModify.Checked,
                                                                      chkEnableKiaiStartModify.Checked,
                                                                      chkEnableKiaiEndModify.Checked,
                                                                      rdoAllHitObjectsModify.Checked,
                                                                      rdoOnlyBarlineModify.Checked,
                                                                      rdoOnlyBookMarkModify.Checked,
                                                                      rdoOnlySpecificHitObjectModify.Checked,
                                                                      objectCode,
                                                                      Constants.EXCECUTE_MODIFY);
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
                                                                          chkEnableSv.Checked,
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
                                                                          rdoAllHitObjects.Checked,
                                                                          rdoOnlyBarline.Checked,
                                                                          rdoOnlyBookMark.Checked,
                                                                          rdoOnlySpecificHitObject.Checked,
                                                                          objectCode,
                                                                          Constants.EXCECUTE_REMOVE);
                if (userInputData == null)
                {
                    return;
                }
                if (SVCalculatorService.Remove(userInputData, ref beatmapInfo))
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
        private void chkEnableSv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableSv.Checked)
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
                lblKiaiStart.Visible = true;
                lblKiaiEnd.Visible = true;
                chkEnableKiaiStart.Visible = true;
                chkEnableKiaiEnd.Visible = true;
            }
            else
            {
                lblKiaiStart.Visible = false;
                lblKiaiEnd.Visible = false;
                chkEnableKiaiStart.Visible = false;
                chkEnableKiaiEnd.Visible = false;
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
            if(rdoArithmetic.Checked)
            {
                calculationCode = 1;
            } else if (!rdoGeometric.Checked)
            {
                calculationCode = 0;
            }
        }
        private void rdoGeometric_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGeometric.Checked)
            {
                calculationCode = 2;
            }
            else if (!rdoArithmetic.Checked)
            {
                calculationCode = 0;
            }
        }
        private void rdoOnlySpecificHitObject_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnlySpecificHitObject.Checked)
            {
                picSpecificNormalDong.Visible = true;
                picSpecificFinisherDong.Visible = true;
                picSpecificNormalKa.Visible = true;
                picSpecificFinisherKa.Visible = true;
                picSpecificNormalSlider.Visible = true;
                picSpecificFinisherSlider.Visible = true;
                picSpecificNormalSpinner.Visible = true;
                lblSpecificNormal.Visible = true;
                lblSpecificFinisher.Visible = true;
                lblSpecificGridLine.Visible = true;
                lblSpecificGridLine2.Visible = true;
                // pictureBoxに設定されているMouseDownイベントを設定する
                picSpecificNormalDong.MouseDown += picSpecificNormalDong_MouseDown;
                picSpecificFinisherDong.MouseDown += picSpecificFinisherDong_MouseDown;
                picSpecificNormalKa.MouseDown += picSpecificNormalKa_MouseDown;
                picSpecificFinisherKa.MouseDown += picSpecificFinisherKa_MouseDown;
                picSpecificNormalSlider.MouseDown += picSpecificNormalSlider_MouseDown;
                picSpecificFinisherSlider.MouseDown += picSpecificFinisherSlider_MouseDown;
                picSpecificNormalSpinner.MouseDown += picSpecificNormalSpinner_MouseDown;
            }
            else
            {
                picSpecificNormalDong.Visible = false;
                picSpecificFinisherDong.Visible = false;
                picSpecificNormalKa.Visible = false;
                picSpecificFinisherKa.Visible = false;
                picSpecificNormalSlider.Visible = false;
                picSpecificFinisherSlider.Visible = false;
                picSpecificNormalSpinner.Visible = false;
                lblSpecificNormal.Visible = false;
                lblSpecificFinisher.Visible = false;
                lblSpecificGridLine.Visible = false;
                lblSpecificGridLine2.Visible = false;
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
                isOnlySpecificHitObjectArray = new bool[7] { false, false, false, false, false, false, false };
                objectCode = 0;
            }
        }
        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            Form historyForm = new HistoryForm();
            historyForm.ShowDialog();

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void rdoAllHitObjects_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAllHitObjects.Checked)
            {
                chkEnableIncludeBarline.Visible = true;
            }
            else
            {
                chkEnableIncludeBarline.Visible = false;
                chkEnableIncludeBarline.Checked = false;
            }
        }
        private void tabExecuteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (beforeSelectedTabIndex == 2)
            {
                ReturnRemoveControls();
            }
            switch (tabExecuteType.SelectedIndex)
            {
                case 0:
                    // Add
                    InitializeModifyControls();
                    break;
                case 1:
                    // Modify
                    InitializeAddControls();
                    break;
                case 2:
                    // Remove
                    InitializeAddControls();
                    InitializeModifyControls();
                    InitializeRemoveControls();
                    break;
                default:
                    break;
            }
            beforeSelectedTabIndex = tabExecuteType.SelectedIndex;
        }
        private void tabSetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabSetType.SelectedIndex)
            {
                case 0:
                    // HitObjects
                    InitializeBeatSnapControls();
                    break;
                case 1:
                    // BeatSnap
                    InitializeHitObjectsControls();
                    break;
                default:
                    break;
            }
        }
        private void picSpecificNormalDongModify_MouseDown(object sender, MouseEventArgs e)
        {
            if (isOnlySpecificHitObjectArray[0] = !isOnlySpecificHitObjectArray[0])
            {
                picSpecificNormalDongModify.Image = Properties.Resources.d_selected;
                objectCode += 1;
            }
            else
            {
                picSpecificNormalDongModify.Image = Properties.Resources.d;
                objectCode -= 1;
            }
        }
        private void picSpecificFinisherDongModify_MouseDown(object sender, MouseEventArgs e)
        {
            if (isOnlySpecificHitObjectArray[1] = !isOnlySpecificHitObjectArray[1])
            {
                picSpecificFinisherDongModify.Image = Properties.Resources.d_selected;
                objectCode += 2;
            }
            else
            {
                picSpecificFinisherDongModify.Image = Properties.Resources.d;
                objectCode -= 2;
            }
        }
        private void picSpecificNormalKaModify_MouseDown(object sender, MouseEventArgs e)
        {
            if (isOnlySpecificHitObjectArray[2] = !isOnlySpecificHitObjectArray[2])
            {
                picSpecificNormalKaModify.Image = Properties.Resources.k_selected;
                objectCode += 4;
            }
            else
            {
                picSpecificNormalKaModify.Image = Properties.Resources.k;
                objectCode -= 4;
            }
        }
        private void picSpecificFinisherKaModify_MouseDown(object sender, MouseEventArgs e)
        {
            if (isOnlySpecificHitObjectArray[3] = !isOnlySpecificHitObjectArray[3])
            {
                picSpecificFinisherKaModify.Image = Properties.Resources.k_selected;
                objectCode += 8;
            }
            else
            {
                picSpecificFinisherKaModify.Image = Properties.Resources.k;
                objectCode -= 8;
            }
        }
        private void picSpecificNormalSliderModify_MouseDown(object sender, MouseEventArgs e)
        {
            if (isOnlySpecificHitObjectArray[4] = !isOnlySpecificHitObjectArray[4])
            {
                picSpecificNormalSliderModify.Image = Properties.Resources.slider_selected;
                objectCode += 16;
            }
            else
            {
                picSpecificNormalSliderModify.Image = Properties.Resources.slider;
                objectCode -= 16;
            }
        }
        private void picSpecificFinisherSliderModify_MouseDown(object sender, MouseEventArgs e)
        {
            if (isOnlySpecificHitObjectArray[5] = !isOnlySpecificHitObjectArray[5])
            {
                picSpecificFinisherSliderModify.Image = Properties.Resources.slider_selected;
                objectCode += 32;
            }
            else
            {
                picSpecificFinisherSliderModify.Image = Properties.Resources.slider;
                objectCode -= 32;
            }
        }
        private void picSpecificNormalSpinnerModify_MouseDown(object sender, MouseEventArgs e)
        {
            {
                if (isOnlySpecificHitObjectArray[6] = !isOnlySpecificHitObjectArray[6])
                {
                    picSpecificNormalSpinnerModify.Image = Properties.Resources.spinner_selected;
                    objectCode += 64;
                }
                else
                {
                    picSpecificNormalSpinnerModify.Image = Properties.Resources.spinner;
                    objectCode -= 64;
                }
            }
        }
        private void rdoOnlySpecificHitObjectModify_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnlySpecificHitObjectModify.Checked)
            {
                picSpecificNormalDongModify.Visible = true;
                picSpecificFinisherDongModify.Visible = true;
                picSpecificNormalKaModify.Visible = true;
                picSpecificFinisherKaModify.Visible = true;
                picSpecificNormalSliderModify.Visible = true;
                picSpecificFinisherSliderModify.Visible = true;
                picSpecificNormalSpinnerModify.Visible = true;
                lblSpecificNormalModify.Visible = true;
                lblSpecificFinisherModify.Visible = true;
                lblSpecificGridLineModify.Visible = true;
                lblSpecificGridLine2Modify.Visible = true;
                // pictureBoxに設定されているMouseDownイベントを設定する
                picSpecificNormalDongModify.MouseDown += picSpecificNormalDongModify_MouseDown;
                picSpecificFinisherDongModify.MouseDown += picSpecificFinisherDongModify_MouseDown;
                picSpecificNormalKaModify.MouseDown += picSpecificNormalKaModify_MouseDown;
                picSpecificFinisherKaModify.MouseDown += picSpecificFinisherKaModify_MouseDown;
                picSpecificNormalSliderModify.MouseDown += picSpecificNormalSliderModify_MouseDown;
                picSpecificFinisherSliderModify.MouseDown += picSpecificFinisherSliderModify_MouseDown;
                picSpecificNormalSpinnerModify.MouseDown += picSpecificNormalSpinnerModify_MouseDown;
            }
            else
            {
                picSpecificNormalDongModify.Visible = false;
                picSpecificFinisherDongModify.Visible = false;
                picSpecificNormalKaModify.Visible = false;
                picSpecificFinisherKaModify.Visible = false;
                picSpecificNormalSliderModify.Visible = false;
                picSpecificFinisherSliderModify.Visible = false;
                picSpecificNormalSpinnerModify.Visible = false;
                lblSpecificNormalModify.Visible = false;
                lblSpecificFinisherModify.Visible = false;
                lblSpecificGridLineModify.Visible = false;
                lblSpecificGridLine2Modify.Visible = false;
                // pictureBoxに設定されているMouseDownイベントを外す
                picSpecificNormalDongModify.MouseDown -= picSpecificNormalDongModify_MouseDown;
                picSpecificFinisherDongModify.MouseDown -= picSpecificFinisherDongModify_MouseDown;
                picSpecificNormalKaModify.MouseDown -= picSpecificNormalKaModify_MouseDown;
                picSpecificFinisherKaModify.MouseDown -= picSpecificFinisherKaModify_MouseDown;
                picSpecificNormalSliderModify.MouseDown -= picSpecificNormalSliderModify_MouseDown;
                picSpecificFinisherSliderModify.MouseDown -= picSpecificFinisherSliderModify_MouseDown;
                picSpecificNormalSpinnerModify.MouseDown -= picSpecificNormalSpinnerModify_MouseDown;
                // 画像を元に戻す
                picSpecificNormalDongModify.Image = Properties.Resources.d;
                picSpecificFinisherDongModify.Image = Properties.Resources.d;
                picSpecificNormalKaModify.Image = Properties.Resources.k;
                picSpecificFinisherKaModify.Image = Properties.Resources.k;
                picSpecificNormalSliderModify.Image = Properties.Resources.slider;
                picSpecificFinisherSliderModify.Image = Properties.Resources.slider;
                picSpecificNormalSpinnerModify.Image = Properties.Resources.spinner;
                // 選択肢とコードの初期化
                isOnlySpecificHitObjectArray = new bool[7] { false, false, false, false, false, false, false };
                objectCode = 0;
            }
        }
        private void rdoAllHitObjectsModify_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAllHitObjectsModify.Checked)
            {
                chkEnableIncludeBarlineModify.Visible = true;
            }
            else
            {
                chkEnableIncludeBarlineModify.Visible = false;
                chkEnableIncludeBarlineModify.Checked = false;
            }
        }
        private void chkEnableKiaiModify_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableKiaiModify.Checked)
            {
                lblKiaiStartModify.Visible = true;
                lblKiaiEndModify.Visible = true;
                chkEnableKiaiStartModify.Visible = true;
                chkEnableKiaiEndModify.Visible = true;
            }
            else
            {
                lblKiaiStartModify.Visible = false;
                lblKiaiEndModify.Visible = false;
                chkEnableKiaiStartModify.Visible = false;
                chkEnableKiaiEndModify.Visible = false;
                chkEnableKiaiStartModify.Checked = false;
                chkEnableKiaiEndModify.Checked = false;
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
        #endregion
    }
}
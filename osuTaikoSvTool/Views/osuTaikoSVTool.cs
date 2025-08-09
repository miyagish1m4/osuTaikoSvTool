using System.Diagnostics;
using OsuMemoryDataProvider;
using OsuMemoryDataProvider.OsuMemoryModels;
using OsuParsers.Decoders;
using osuTaikoSvTool.Models;
using osuTaikoSvTool.Properties;
using osuTaikoSvTool.Services;
using osuTaikoSvTool.Utils;
using osuTaikoSvTool.Utils.Helper;
using osuTaikoSvTool.Views;

namespace osuTaikoSvTool
{
    public partial class osuTaikoSVTool : Form
    {
        #region クラス変数
        private readonly StructuredOsuMemoryReader sreader = StructuredOsuMemoryReader.GetInstance(new("osu!"));
        private readonly OsuBaseAddresses baseAddresses = new OsuBaseAddresses();
        private BeatmapMetadata beatmapInfo = new();
        private BeatmapMetadata preBeatmapInfo = new();
        private Beatmap? beatmapData;
        private UserInputData? userInputData;
        private List<TimingPoint> timingPoints = new List<TimingPoint>();
        private string osuDirectory = string.Empty;
        private string songsPath = string.Empty;
        private int currentTime;
        private bool isDirectoryLoaded = false;
        private bool isUpdate = true;
        private bool[] isOnlySpecificHitObjectArray = new bool[7] { false, false, false, false, false, false, false };
        private int objectCode = 0;
        private int calculationCode = 0;
        private int beforeSelectedTabIndex = 0;
        private string backupDirectoryName = string.Empty;
        #endregion
        #region メソッド
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public osuTaikoSVTool()
        {
            InitializeComponent();
            Thread getMemoryDataThread = new Thread(UpdateMemoryData) { IsBackground = true };
            getMemoryDataThread.Start();

            UpdateBeatmapInfo();

        }
        /// <summary>
        /// osuのメモリデータを取得する
        /// </summary>
        private void UpdateMemoryData()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(15);
                    var processes = Process.GetProcessesByName("osu!");
                    if (processes.Length == 0)
                    {
                        throw new Exception("osu!が起動されていません。");
                    }
                    if (!isDirectoryLoaded)
                    {
                        Process process = processes[0];
                        string? fileName = process.MainModule?.FileName;
                        osuDirectory = Path.GetDirectoryName(fileName) ?? string.Empty;
                        if (osuDirectory != string.Empty)
                        {
                            if (!Directory.Exists(osuDirectory))
                            {
                                return;
                            }
                            songsPath = Common.GetSongsFolderLocation(osuDirectory);
                            isDirectoryLoaded = !isDirectoryLoaded;
                        }
                    }
                    sreader.TryRead(baseAddresses.Beatmap);
                    sreader.TryRead(baseAddresses.GeneralData);
                    currentTime = baseAddresses.GeneralData.AudioTime;
                    string osuBeatmapPath = Path.Combine(songsPath ?? "",
                                                         baseAddresses.Beatmap.FolderName ?? "",
                                                         baseAddresses.Beatmap.OsuFileName ?? "");
                    OsuParsers.Beatmaps.Beatmap beatmapData = BeatmapDecoder.Decode(osuBeatmapPath);
                    beatmapInfo.title = beatmapData.Version <= 9 ? beatmapData.MetadataSection.Title : beatmapData.MetadataSection.TitleUnicode;
                    beatmapInfo.artist = beatmapData.Version <= 9 ? beatmapData.MetadataSection.Artist : beatmapData.MetadataSection.ArtistUnicode;
                    beatmapInfo.version = beatmapData.MetadataSection.Version;
                    beatmapInfo.creator = beatmapData.MetadataSection.Creator;
                    beatmapInfo.beatmapPath = osuBeatmapPath;
                    string backgroundPath = Path.Combine(songsPath ?? "",
                                                         baseAddresses.Beatmap.FolderName ?? "",
                                                         beatmapData.EventsSection.BackgroundImage ?? "");
                    beatmapInfo.backgroundPath = backgroundPath ?? "";
                    if (isUpdate)
                    {
                        isUpdate = false;
                    }
                }
                catch (Exception ex)
                {
                    Common.WriteErrorMessage("メモリ取得失敗してて草");
                    Common.WriteExceptionMessage(ex);
                }
            }
        }
        /// <summary>
        /// UpdateMemoryDataで取得したosuのメモリデータを使用し、
        /// 譜面のBGやMetadataをコントロールに設定する
        /// </summary>
        private async void UpdateBeatmapInfo()
        {
            while (true)
            {
                await Task.Delay(15);

                try
                {
                    if (isUpdate)
                    {
                        continue;
                    }
                    if (preBeatmapInfo.version == beatmapInfo.version &&
                        preBeatmapInfo.beatmapPath == beatmapInfo.beatmapPath)
                    {
                        continue;
                    }
                    preBeatmapInfo.backgroundPath = beatmapInfo.backgroundPath ?? "";
                    preBeatmapInfo.artist = beatmapInfo.artist;
                    preBeatmapInfo.title = beatmapInfo.title;
                    preBeatmapInfo.version = beatmapInfo.version;
                    preBeatmapInfo.creator = beatmapInfo.creator;
                    lblFileName.Text = beatmapInfo.artist.Replace("&", "&&") + " - " +
                                       beatmapInfo.title.Replace("&", "&&") + " [" +
                                       beatmapInfo.version.Replace("&", "&&") + "]";
                    backupDirectoryName = beatmapInfo.artist + " - " +
                                          beatmapInfo.title + " (" +
                                          beatmapInfo.creator + ") [" +
                                          beatmapInfo.version + "]";
                    preBeatmapInfo.beatmapPath = beatmapInfo.beatmapPath;
                    if (beatmapInfo.backgroundPath == null || beatmapInfo.backgroundPath == string.Empty)
                    {
                        picDisplayBg.Image = null;
                        lblFileName.Text = "No Beatmap Selected";
                        Common.WriteWarningMessage("LOG_W-GET-BG");
                    }
                    else
                    {
                        picDisplayBg.Image = BeatmapHelper.SetBgOnForm(beatmapInfo.backgroundPath);
                    }

                }
                catch
                {

                }
            }
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
        }
        /// <summary>
        /// 処理項目タブが"ビートスナップ間隔"の時のコントロールの初期化処理
        /// </summary>
        private void InitializeBeatSnapControls()
        {
            chkEnableBeatSnap.Checked = false;
        }
        /// <summary>
        /// メイン処理
        /// </summary>
        /// <param name="executeCode">実行コード</param>
        private void ExecuteProcess(int executeCode)
        {
            bool isSvCalculation = false;
            if (userInputData == null || beatmapData == null)
            {
                MessageBox.Show(Common.WriteDialogMessage("E_A-D-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (executeCode)
            {
                case Constants.EXECUTE_ADD:
                    isSvCalculation = SVCalculatorService.Add(userInputData, beatmapData, ref timingPoints);
                    beatmapData.timingPoints.AddRange(timingPoints);
                    timingPoints.Clear();
                    break;
                case Constants.EXECUTE_MODIFY:
                    isSvCalculation = SVCalculatorService.Modify(userInputData, beatmapData);
                    break;
                case Constants.EXECUTE_REMOVE:
                    isSvCalculation = SVCalculatorService.Remove(userInputData, beatmapData);
                    break;
            }
            if (!isSvCalculation)
            {
                MessageBox.Show(Common.WriteDialogMessage("E_A-P-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!BeatmapHelper.CreateBackup(this.beatmapInfo.beatmapPath, this.backupDirectoryName))
            {
                MessageBox.Show(Common.WriteDialogMessage("E_A-P-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!BeatmapHelper.ExportToOsuFile(beatmapData, this.beatmapInfo.beatmapPath))
            //if (!Utils.Helper.Debug.ExportToCsvFile(beatmapData, this.beatmapInfo.beatmapPath))
            {
                MessageBox.Show(Common.WriteDialogMessage("E_A-P-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!UserInputDataHelper.SerializeUserInputData(userInputData))
            {
                MessageBox.Show(Common.WriteDialogMessage("E_A-P-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show(Common.WriteDialogMessage("I_A-P-001"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        /// <summary>
        /// 譜面情報の取得処理
        /// </summary>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private bool GetBeatmap()
        {
            if (this.beatmapInfo.beatmapPath == null || this.beatmapInfo.beatmapPath == string.Empty)
            {
                MessageBox.Show(Common.WriteDialogMessage("E_V-EM-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            beatmapData = BeatmapHelper.GetBeatmapData(this.beatmapInfo.beatmapPath);
            if (beatmapData.version == string.Empty)
            {
                MessageBox.Show(Common.WriteDialogMessage("E_A-D-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion
        #region イベントハンドラ
        private void osuTaikoSVTool_Load(object sender, EventArgs e)
        {
            Common.InitializeDirectoryAndFiles();
            Common.WriteInfoMessage("LOG_I-START");

            //songsDirectory = Common.InitializeConfigDirectory();
            //if (songsDirectory == "")
            //{
            //    Application.Exit();
            //}
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            InitializeAddControls();
            InitializeModifyControls();
            picDisplayBg.Controls.Add(lblFileName);
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
        private void Application_ApplicationExit(object? sender, EventArgs e)
        {
            //ApplicationExitイベントハンドラを削除
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
            Common.WriteInfoMessage("LOG_I-END");
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UserInputDataHelper.SetUserInputData(txtTimingFrom.Text,
                                                         txtTimingTo.Text,
                                                         chkEnableSv.Checked,
                                                         txtSvFrom.Text,
                                                         txtSvTo.Text,
                                                         chkEnableVolume.Checked,
                                                         txtVolumeFrom.Text,
                                                         txtVolumeTo.Text,
                                                         calculationCode,
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
                                                         Constants.EXECUTE_ADD,
                                                         ref userInputData))
                {
                    return;
                }
                if (!GetBeatmap())
                {
                    return;
                }
                ExecuteProcess(Constants.EXECUTE_ADD);
            }
            catch (Exception ex)
            {
                beatmapData = null;
                userInputData = null;
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return;
            }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (!UserInputDataHelper.SetUserInputData(txtTimingFrom.Text,
                                                      txtTimingTo.Text,
                                                      chkEnableSv.Checked,
                                                      txtSvFrom.Text,
                                                      txtSvTo.Text,
                                                      chkEnableVolume.Checked,
                                                      txtVolumeFrom.Text,
                                                      txtVolumeTo.Text,
                                                      calculationCode,
                                                      chkEnableOffset.Checked,
                                                      txtOffset.Text,
                                                      chkEnableBeatSnap.Checked,
                                                      txtBeatSnap.Text,
                                                      chkEnableKiaiModify.Checked,
                                                      chkEnableKiaiStart.Checked,
                                                      chkEnableKiaiEnd.Checked,
                                                      rdoAllHitObjectsModify.Checked,
                                                      rdoOnlyBarlineModify.Checked,
                                                      rdoOnlyBookMarkModify.Checked,
                                                      rdoOnlySpecificHitObjectModify.Checked,
                                                      objectCode,
                                                      Constants.EXECUTE_MODIFY,
                                                      ref userInputData))
            {
                return;
            }
            if (!GetBeatmap())
            {
                return;
            }
            ExecuteProcess(Constants.EXECUTE_MODIFY);
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UserInputDataHelper.SetUserInputData(txtTimingFrom.Text,
                                                         txtTimingTo.Text,
                                                         chkEnableSv.Checked,
                                                         txtSvFrom.Text,
                                                         txtSvTo.Text,
                                                         chkEnableVolume.Checked,
                                                         txtVolumeFrom.Text,
                                                         txtVolumeTo.Text,
                                                         calculationCode,
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
                                                         Constants.EXECUTE_REMOVE,
                                                         ref userInputData))
                {
                    return;
                }
                if (!GetBeatmap())
                {
                    return;
                }
                ExecuteProcess(Constants.EXECUTE_REMOVE);
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
        private void btnGetTimingFrom_Click(object sender, EventArgs e)
        {
            txtTimingFrom.Text = currentTime.ToString();

        }
        private void btnGetTimingTo_Click(object sender, EventArgs e)
        {
            txtTimingTo.Text = currentTime.ToString();
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
            if (chkEnableKiai.Checked && rdoAllHitObjects.Checked)
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
        private void picSpecificNormalDong_MouseDown(object? sender, MouseEventArgs e)
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
        private void picSpecificFinisherDong_MouseDown(object? sender, MouseEventArgs e)
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
        private void picSpecificNormalKa_MouseDown(object? sender, MouseEventArgs e)
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
        private void picSpecificFinisherKa_MouseDown(object? sender, MouseEventArgs e)
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
        private void picSpecificNormalSlider_MouseDown(object? sender, MouseEventArgs e)
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
        private void picSpecificFinisherSlider_MouseDown(object? sender, MouseEventArgs e)
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
        private void picSpecificNormalSpinner_MouseDown(object? sender, MouseEventArgs e)
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
            if (rdoArithmetic.Checked)
            {
                calculationCode = 1;
            }
            else if (!rdoGeometric.Checked)
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
        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            Form historyForm = new HistoryForm();
            historyForm.ShowDialog();

        }
        private void rdoAllHitObjects_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAllHitObjects.Checked)
            {
                if (chkEnableKiai.Checked)
                {
                    chkEnableKiaiStart.Visible = true;
                    chkEnableKiaiEnd.Visible = true;
                    lblKiaiStart.Visible = true;
                    lblKiaiEnd.Visible = true;
                }
            }
            else
            {
                chkEnableKiaiStart.Checked = false;
                chkEnableKiaiEnd.Checked = false;
                chkEnableKiaiStart.Visible = false;
                chkEnableKiaiEnd.Visible = false;
                lblKiaiStart.Visible = false;
                lblKiaiEnd.Visible = false;
            }
        }
        private void rdoOnlyBookMark_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnlyBookMark.Checked)
            {
                chkEnableKiaiStart.Checked = false;
                chkEnableKiaiEnd.Checked = false;
                chkEnableOffset.Checked = false;
                txtOffset.Text = string.Empty;
                chkEnableKiaiStart.Visible = false;
                chkEnableKiaiEnd.Visible = false;
                lblKiaiStart.Visible = false;
                lblKiaiEnd.Visible = false;
                chkEnableOffset.Visible = false;
                lblOffset.Visible = false;
                txtOffset.Visible = false;
                lblMiliSecond.Visible = false;
            }
            else
            {
                chkEnableOffset.Visible = true;
                lblOffset.Visible = true;
                txtOffset.Visible = true;
                lblMiliSecond.Visible = true;
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
        private void picSpecificNormalDongModify_MouseDown(object? sender, MouseEventArgs e)
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
        private void picSpecificFinisherDongModify_MouseDown(object? sender, MouseEventArgs e)
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
        private void picSpecificNormalKaModify_MouseDown(object? sender, MouseEventArgs e)
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
        private void picSpecificFinisherKaModify_MouseDown(object? sender, MouseEventArgs e)
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
        private void picSpecificNormalSliderModify_MouseDown(object? sender, MouseEventArgs e)
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
        private void picSpecificFinisherSliderModify_MouseDown(object? sender, MouseEventArgs e)
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
        private void picSpecificNormalSpinnerModify_MouseDown(object? sender, MouseEventArgs e)
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

        #endregion

    }
}
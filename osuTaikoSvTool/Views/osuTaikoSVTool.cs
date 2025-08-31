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
        #region �N���X�ϐ�
        private readonly StructuredOsuMemoryReader sreader = StructuredOsuMemoryReader.GetInstance(new("osu!"));
        private readonly OsuBaseAddresses baseAddresses = new OsuBaseAddresses();
        private BeatmapMetadata beatmapInfo = new();
        private BeatmapMetadata preBeatmapInfo = new();
        private Beatmap? beatmapData;
        private UserInputData? userInputData;
        private List<TimingPoint> timingPoints = [];
        private string osuDirectory = string.Empty;
        private string songsPath = string.Empty;
        private int currentTime;
        private bool isDirectoryLoaded = false;
        private bool isUpdate = true;
        private bool[] isOnlySpecificHitObjectArray = [false, false, false, false, false, false, false];
        private bool[] isSetMode = [true, false];
        private int objectCode = 0;
        private int calculationCode = 0;
        private int relativeCode = -1;
        private bool isExecute = false;
        private int beforeSelectedTabIndex = 0;
        private string backupDirectoryName = string.Empty;
        #endregion
        #region ���\�b�h
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public osuTaikoSVTool()
        {
            InitializeComponent();
            Thread getMemoryDataThread = new Thread(UpdateMemoryData) { IsBackground = true };
            getMemoryDataThread.Start();

            UpdateBeatmapInfo();

        }
        /// <summary>
        /// osu.exe�̃������f�[�^�擾����
        /// </summary>
        private void UpdateMemoryData()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(15);
                    // osu.exe��T��
                    var processes = Process.GetProcessesByName("osu!");
                    if (processes.Length == 0)
                    {
                        throw new Exception("osu!���N������Ă��܂���B");
                    }
                    // osu�t�H���_�擾����
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
                    // ���������畈�ʂ̏����擾����
                    sreader.TryRead(baseAddresses.Beatmap);
                    sreader.TryRead(baseAddresses.GeneralData);
                    currentTime = baseAddresses.GeneralData.AudioTime;
                    // ���ʂ̃t�H���_���擾
                    string osuBeatmapPath = Path.Combine(songsPath ?? "",
                                                         baseAddresses.Beatmap.FolderName ?? "",
                                                         baseAddresses.Beatmap.OsuFileName ?? "");
                    // ���ʂ̃f�[�^���擾
                    OsuParsers.Beatmaps.Beatmap beatmapData = BeatmapDecoder.Decode(osuBeatmapPath);
                    // �^�C�g��
                    beatmapInfo.title = beatmapData.Version <= 9 ? beatmapData.MetadataSection.Title : beatmapData.MetadataSection.TitleUnicode;
                    // �A�[�e�B�X�g
                    beatmapInfo.artist = beatmapData.Version <= 9 ? beatmapData.MetadataSection.Artist : beatmapData.MetadataSection.ArtistUnicode;
                    // Diff��
                    beatmapInfo.version = beatmapData.MetadataSection.Version;
                    // �}�b�p�[��
                    beatmapInfo.creator = beatmapData.MetadataSection.Creator;
                    // ���ʂ̃p�X
                    beatmapInfo.beatmapPath = osuBeatmapPath;
                    // BG�̃p�X
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
                    // ����Exception��Error���O�ɏ������ނƗe�ʂ��c��ɂȂ��Ă��܂����߁A
                    // Error���O�ɂ͏�����Console���O�ɏo��
                    Console.WriteLine(ex);
                }
            }
        }
        /// <summary>
        /// UpdateMemoryData�Ŏ擾����osu�̃������f�[�^���g�p���A
        /// ���ʂ�BG��Metadata���R���g���[���ɐݒ肷��
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
                    // �O��擾�����f�[�^�Ɠ����ꍇ�͏������s��Ȃ�
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
                    // �e�L�X�g���x���ɕ��ʂ̏�����������
                    lblFileName.Text = beatmapInfo.artist.Replace("&", "&&") + " - " +
                                       beatmapInfo.title.Replace("&", "&&") + " [" +
                                       beatmapInfo.version.Replace("&", "&&") + "]";
                    // �o�b�N�A�b�v�t�H���_����ݒ肷��
                    backupDirectoryName = beatmapInfo.artist + " - " +
                                          beatmapInfo.title + " (" +
                                          beatmapInfo.creator + ") [" +
                                          beatmapInfo.version + "]";
                    preBeatmapInfo.beatmapPath = beatmapInfo.beatmapPath;
                    // BG�̃p�X���擾�ł��Ă���ꍇ��BG���t�H�[���ɕ\������
                    if (beatmapInfo.backgroundPath == null || beatmapInfo.backgroundPath == string.Empty)
                    {
                        picDisplayBg.Image = null;
                        Common.WriteWarningMessage("LOG_W-GET-BG");
                    }
                    else
                    {
                        picDisplayBg.Image = BeatmapHelper.SetBgOnForm(beatmapInfo.backgroundPath);
                    }
                }
                catch (Exception ex)
                {
                    // ����Exception��Error���O�ɏ������ނƗe�ʂ��c��ɂȂ��Ă��܂����߁A
                    // Error���O�ɂ͏�����Console���O�ɏo��
                    Console.WriteLine(ex);
                }
            }
        }
        /// <summary>
        /// �������ڃ^�u��"�K��"�̎��̃R���g���[���̏���������
        /// </summary>
        private void InitializeApplyControls()
        {
            isSetMode[0] = true;
            isSetMode[1] = false;
            tabSetType.SelectedIndex = 0;
            chkRelative.Visible = true;
            chkRelative.Checked = false;
            InitializeHitObjectsControls();
            InitializeBeatSnapControls();
        }
        /// <summary>
        /// ���s���ڃ^�u��"�폜"�̎��̃R���g���[���̏���������
        /// </summary>
        private void InitializeRemoveControls()
        {
            chkEnableSv.Checked = false;
            chkEnableVolume.Checked = false;
            chkEnableSv.Enabled = false;
            chkEnableVolume.Enabled = false;
            chkRelative.Visible = false;
            chkRelative.Checked = false;
        }
        /// <summary>
        /// ���s���ڃ^�u��"�폜"����ύX���ꂽ���̃R���g���[���̏���������
        /// </summary>
        private void ReturnRemoveControls()
        {
            chkEnableSv.Checked = true;
            chkEnableVolume.Checked = true;
            chkEnableSv.Enabled = true;
            chkEnableVolume.Enabled = true;
            chkRelative.Visible = true;
            chkRelative.Checked = false;
        }
        /// <summary>
        /// �������ڃ^�u��"Objects�̂�"�̎��̃R���g���[���̏���������
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
            chkEnableOffset.Checked = true;
            chkApplyStartObject.Checked = true;
            chkApplyEndObject.Checked = true;
        }
        /// <summary>
        /// �������ڃ^�u��"�r�[�g�X�i�b�v�Ԋu"�̎��̃R���g���[���̏���������
        /// </summary>
        private void InitializeBeatSnapControls()
        {
            chkEnableBeatSnap.Checked = false;
        }
        /// <summary>
        /// ���C������(SV.Volume)
        /// </summary>
        /// <param name="executeCode">���s�R�[�h</param>
        private void ExecuteProcess(int executeCode)
        {
            bool isSvCalculation = false;
            // ���͒l�ƕ��ʏ�񂪎擾�ł��Ă��Ȃ��ꍇ�̓G���[�_�C�A���O��\������
            if (userInputData == null || beatmapData == null)
            {
                Common.ShowMessageDialog("E_A-D-001");
                return;
            }
            // ���s�R�[�h��SV�������s��
            switch (executeCode)
            {
                // �ǉ�
                case Constants.EXECUTE_APPLY:
                    isSvCalculation = SVCalculatorService.Apply(userInputData, beatmapData, ref timingPoints);
                    beatmapData.timingPoints.AddRange(timingPoints);
                    beatmapData.timingPoints = beatmapData.timingPoints.OrderBy(a => a.time).ThenByDescending(b => b.isRedLine ? 1 : 0).ToList();
                    timingPoints.Clear();
                    break;
                // �폜
                case Constants.EXECUTE_REMOVE:
                    isSvCalculation = SVCalculatorService.Remove(userInputData, beatmapData);
                    break;
            }
            if (!isSvCalculation)
            {
                // ���s�����ꍇ�̓G���[�_�C�A���O��\������
                Common.ShowMessageDialog("E_A-P-001");
                return;
            }
            // �o�b�N�A�b�v���쐬����
            if (!BeatmapHelper.CreateBackup(this.beatmapInfo.beatmapPath, this.backupDirectoryName))
            {
                // ���s�����ꍇ�̓G���[�_�C�A���O��\������
                Common.ShowMessageDialog("E_A-P-001");
                return;
            }
            // �f�o�b�O�pCSV�o��
            // ���e�m�F�ȂǂɎg���Ă�
            //if (!Utils.Helper.Debug.ExportToCsvFile(beatmapData, this.backupDirectoryName))
            // osu�t�@�C���ɏ㏑������
            if (!BeatmapHelper.ExportToOsuFile(beatmapData, this.beatmapInfo.beatmapPath))
            {
                // ���s�����ꍇ�̓G���[�_�C�A���O��\������
                Common.ShowMessageDialog("E_A-P-001");
                return;
            }
            // ���͒l��xml�t�@�C���ɃV���A���C�Y����
            if (!UserInputDataHelper.SerializeUserInputData(userInputData))
            {
                // ���s�����ꍇ�̓G���[�_�C�A���O��\������
                Common.ShowMessageDialog("E_A-P-001");
                return;
            }
            // ���������ꍇ�̓��b�Z�[�W�_�C�A���O��\������
            Common.ShowMessageDialog("I_A-P-001");
            isExecute = true;
            return;
        }
        /// <summary>
        /// ���ʏ��̎擾����
        /// </summary>
        /// <returns>������<br/>�E����I�������ꍇ��true<br/>�E�ُ�I�������ꍇ��false</returns>
        private bool GetBeatmap()
        {
            // ���ʏ�񂪃��A���^�C���Ŏ擾�ł��Ă��Ȃ��ꍇ�̓G���[�_�C�A���O��\������
            if (this.beatmapInfo.beatmapPath == null || this.beatmapInfo.beatmapPath == string.Empty)
            {
                Common.ShowMessageDialog("E_A-D-001");
                return false;
            }
            // ���ʂ̓��e���擾����
            beatmapData = BeatmapHelper.GetBeatmapData(this.beatmapInfo.beatmapPath);
            // �擾�ł��Ȃ������ꍇ�̓G���[�_�C�A���O��\������
            if (beatmapData.version == string.Empty)
            {
                Common.ShowMessageDialog("E_A-D-001");
                return false;
            }
            return true;
        }
        #endregion
        #region �C�x���g�n���h��
        private void osuTaikoSVTool_Load(object sender, EventArgs e)
        {
            Common.InitializeDirectoryAndFiles();
            Common.WriteInfoMessage("LOG_I-START");
            // ApplicationExit�C�x���g�n���h����ǉ�
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            // ���ꂼ��̃R���g���[���̏���������
            InitializeApplyControls();
            picDisplayBg.Controls.Add(lblFileName);
            pnlRelativeSvGroup.Visible = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        private void osuTaikoSVTool_Shown(object sender, EventArgs e)
        {
            // ��ʂ��^�X�N�o�[�Ɣ��Ȃ��悤�Ɉʒu�̕ύX������
            if (this.WindowState == System.Windows.Forms.FormWindowState.Normal)
            {
                var rect = System.Windows.Forms.Screen.GetWorkingArea(this);
                this.Left = (rect.Left + rect.Width > this.Left + this.Width) ? this.Left : rect.Left + rect.Width - this.Width;
                this.Left = (rect.Left < this.Left) ? this.Left : rect.Left;
                this.Top = (rect.Top + rect.Height > this.Top + this.Height) ? this.Top : rect.Top + rect.Height - this.Height;
                this.Top = (rect.Top < this.Top) ? this.Top : rect.Top;
            }
        }
        private void osuTaikoSVTool_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                //�mCtrl�n+�mS�n�������ꂽ��SV�K��/�폜�����s����
                case (Keys.S | Keys.Control):
                    switch (tabExecuteType.SelectedIndex)
                    {
                        case 0:
                            btnApply_Click(sender, e);
                            break;
                        case 1:
                            btnRemove_Click(sender, e);
                            break;
                        default:
                            break;
                    }
                    break;
                //�mCtrl�n+�mZ�n�������ꂽ����s�O�̕��ʂɂ���
                case (Keys.Z | Keys.Control):
                    if(!isExecute)
                    {
                        break;
                    }
                    if (BeatmapHelper.ExportToPreviousOsuFile(this.beatmapInfo.beatmapPath, this.backupDirectoryName))
                    {
                        // ���������ꍇ�͊������b�Z�[�W��\������
                        Common.ShowMessageDialog("I_A-P-002");
                    }
                    else
                    {
                        // ���s�����ꍇ�̓G���[�_�C�A���O��\������
                        Common.ShowMessageDialog("E_A-P-001");
                    }
                    break;
            }

        }
        private void Application_ApplicationExit(object? sender, EventArgs e)
        {
            //ApplicationExit�C�x���g�n���h�����폜
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
            Common.WriteInfoMessage("LOG_I-END");
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                // ���͒l��UserInputData�N���X�Ɋi�[
                if (!UserInputDataHelper.SetUserInputData(txtTimingFrom.Text,
                                                          txtTimingTo.Text,
                                                          chkEnableSv.Checked,
                                                          txtSvFrom.Text,
                                                          txtSvTo.Text,
                                                          chkEnableVolume.Checked,
                                                          txtVolumeFrom.Text,
                                                          txtVolumeTo.Text,
                                                          calculationCode,
                                                          chkEnableKiai.Checked,
                                                          relativeCode,
                                                          txtRelativeBaseSv.Text,
                                                          chkEnableOffset.Checked,
                                                          txtOffset.Text,
                                                          isSetMode[0],
                                                          isSetMode[1],
                                                          objectCode,
                                                          chkEnableKiaiStart.Checked,
                                                          chkEnableKiaiEnd.Checked,
                                                          chkApplyStartObject.Checked,
                                                          chkApplyEndObject.Checked,
                                                          chkEnableBeatSnap.Checked,
                                                          txtBeatSnap.Text,
                                                          Constants.EXECUTE_APPLY,
                                                          ref userInputData))
                {
                    return;
                }
                // ���ʏ��̎擾
                if (!GetBeatmap())
                {
                    return;
                }
                // �ǉ������̎��s
                ExecuteProcess(Constants.EXECUTE_APPLY);
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
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                // ���͒l��UserInputData�N���X�Ɋi�[
                if (!UserInputDataHelper.SetUserInputData(txtTimingFrom.Text,
                                                          txtTimingTo.Text,
                                                          chkEnableSv.Checked,
                                                          txtSvFrom.Text,
                                                          txtSvTo.Text,
                                                          chkEnableVolume.Checked,
                                                          txtVolumeFrom.Text,
                                                          txtVolumeTo.Text,
                                                          calculationCode,
                                                          chkEnableKiai.Checked,
                                                          relativeCode,
                                                          txtRelativeBaseSv.Text,
                                                          chkEnableOffset.Checked,
                                                          txtOffset.Text,
                                                          isSetMode[0],
                                                          isSetMode[1],
                                                          objectCode,
                                                          chkEnableKiaiStart.Checked,
                                                          chkEnableKiaiEnd.Checked,
                                                          chkApplyStartObject.Checked,
                                                          chkApplyEndObject.Checked,
                                                          chkEnableBeatSnap.Checked,
                                                          txtBeatSnap.Text,
                                                          Constants.EXECUTE_REMOVE,
                                                          ref userInputData))
                {
                    return;
                }
                // ���ʏ��̎擾
                if (!GetBeatmap())
                {
                    return;
                }
                // �폜�����̎��s
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
            // �o�b�N�A�b�v�t�H���_���G�N�X�v���[���ŊJ��
            System.Diagnostics.Process.Start("EXPLORER.EXE", Directory.GetCurrentDirectory() + Constants.BACKUP_DIRECTORY);
        }
        private void txtTimingFrom_Enter(object sender, EventArgs e)
        {
            this.txtTimingFrom.SelectAll();
        }
        private void txtTimingTo_Enter(object sender, EventArgs e)
        {
            this.txtTimingTo.SelectAll();
        }
        private void btnSetTimingFrom_Click(object sender, EventArgs e)
        {
            // osu�ŗ���Ă��錻���Ԃ�mm:ss:fff�`���ŃZ�b�g����
            txtTimingFrom.Text = Common.ConvertFormatTiming(currentTime);
        }
        private void btnSetTimingTo_Click(object sender, EventArgs e)
        {
            // osu�ŗ���Ă��錻���Ԃ�mm:ss:fff�`���ŃZ�b�g����
            txtTimingTo.Text = Common.ConvertFormatTiming(currentTime);
        }
        private void btnSwapTiming_Click(object sender, EventArgs e)
        {
            // Timing�̎n�_�ƏI�_�����ւ���
            string timingBuff = "";
            timingBuff = txtTimingFrom.Text;
            txtTimingFrom.Text = txtTimingTo.Text;
            txtTimingTo.Text = timingBuff;
        }
        private void txtSvFrom_Enter(object sender, EventArgs e)
        {
            this.txtSvFrom.SelectAll();
        }
        private void txtSvTo_Enter(object sender, EventArgs e)
        {
            this.txtSvTo.SelectAll();
        }
        private void txtVolumeFrom_Enter(object sender, EventArgs e)
        {
            this.txtVolumeFrom.SelectAll();
        }
        private void txtVolumeTo_Enter(object sender, EventArgs e)
        {
            this.txtVolumeTo.SelectAll();
        }
        private void btnSwapSv_Click(object sender, EventArgs e)
        {
            // SV�̎n�_�ƏI�_�����ւ���
            string SVBuff = "";
            SVBuff = txtSvFrom.Text;
            txtSvFrom.Text = txtSvTo.Text;
            txtSvTo.Text = SVBuff;
        }
        private void btnSwapVolume_Click(object sender, EventArgs e)
        {
            // Volume�̎n�_�ƏI�_�����ւ���
            string volumeBuff = "";
            volumeBuff = txtVolumeFrom.Text;
            txtVolumeFrom.Text = txtVolumeTo.Text;
            txtVolumeTo.Text = volumeBuff;

        }
        private void chkEnableSv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableSv.Checked)
            {
                // SV�֘A�̃R���g���[����L����
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
                // SV�֘A�̃R���g���[���𖳌���
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
            if (chkEnableVolume.Checked)
            {
                // Volume�֘A�̃R���g���[����L����
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
                // Volume�֘A�̃R���g���[���𖳌���
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
        private void chkRelative_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRelative.Checked)
            {
                pnlRelativeSvGroup.Visible = true;
                txtRelativeBaseSv.Enabled = false;
                txtRelativeBaseSv.Text = "";
                txtRelativeBaseSv.BackColor = SystemColors.WindowFrame;
            }
            else
            {
                pnlRelativeSvGroup.Visible = false;
                rdoRelativeMultiply.Checked = false;
                rdoRelativeSum.Checked = false;
                relativeCode = Constants.RELATIVE_DISABLE;
                txtRelativeBaseSv.Text = "";
            }
        }
        private void rdoRelativeMultiply_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRelativeMultiply.Checked)
            {
                relativeCode = Constants.RELATIVE_MULTIPLY;
                txtRelativeBaseSv.Enabled = true;
                txtRelativeBaseSv.Text = "0";
                txtRelativeBaseSv.BackColor = SystemColors.Window;
            }
            else
            {
                txtRelativeBaseSv.Enabled = false;
                txtRelativeBaseSv.Text = "";
                txtRelativeBaseSv.BackColor = SystemColors.WindowFrame;
            }
        }
        private void rdoRelativeSum_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRelativeSum.Checked)
            {
                relativeCode = Constants.RELATIVE_SUM;
            }
        }
        private void chkEnableOffset_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableOffset.Checked)
            {
                // offset�֘A�̃R���g���[����L����
                txtOffset.Text = string.Empty;
                txtOffset.BackColor = SystemColors.Window;
                txtOffset.Enabled = true;
            }
            else
            {
                // offset�֘A�̃R���g���[���𖳌���
                txtOffset.BackColor = SystemColors.WindowFrame;
                txtOffset.Enabled = false;
            }
        }
        private void chkEnableBeatSnap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableBeatSnap.Checked)
            {
                // beatsnap�֘A�̃R���g���[����L����
                txtBeatSnap.Text = string.Empty;
                txtBeatSnap.BackColor = SystemColors.Window;
                txtBeatSnap.Enabled = true;
            }
            else
            {
                // beatsnap�֘A�̃R���g���[���𖳌���
                txtBeatSnap.BackColor = SystemColors.WindowFrame;
                txtBeatSnap.Enabled = false;
            }

        }
        private void chkEnableKiai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableKiai.Checked && rdoAllHitObjects.Checked)
            {
                // kiai�̎n�_�I�_�̃R���g���[����L����
                chkEnableKiaiStart.Visible = true;
                chkEnableKiaiEnd.Visible = true;
            }
            else
            {
                // kiai�̎n�_�I�_�̃R���g���[���𖳌���
                chkEnableKiaiStart.Visible = false;
                chkEnableKiaiEnd.Visible = false;
                chkEnableKiaiStart.Checked = false;
                chkEnableKiaiEnd.Checked = false;
            }
        }
        private void rdoOnlyOnNotes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnlyOnNotes.Checked)
            {
                if (rdoOnlyBarline.Checked)
                {
                    objectCode = 0x00000100;
                }
                else if (rdoOnlyBookMark.Checked)
                {
                    objectCode = 0x00000400;
                }
            }
        }
        private void rdoOnlyOutNotes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnlyOutNotes.Checked)
            {
                if (rdoOnlyBarline.Checked)
                {
                    objectCode = 0x00000080;
                }
                else if (rdoOnlyBookMark.Checked)
                {
                    objectCode = 0x00000200;
                }
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
            // ������
            // ���s������ʂ�\������
            Form historyForm = new HistoryForm();
            historyForm.ShowDialog();
        }
        private void rdoAllHitObjects_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAllHitObjects.Checked)
            {
                // ���ׂĂ�object�֘A�̃R���g���[����L����
                if (chkEnableKiai.Checked)
                {
                    chkEnableKiaiStart.Visible = true;
                    chkEnableKiaiEnd.Visible = true;
                }
                chkApplyStartObject.Visible = true;
                chkApplyEndObject.Visible = true;
                rdoOnlyOnNotes.Visible = false;
                rdoOnlyOutNotes.Visible = false;
                objectCode = 0x0000017f;
            }
            else
            {
                // ���ׂĂ�object�֘A�̃R���g���[���𖳌���
                chkEnableKiaiStart.Checked = false;
                chkEnableKiaiEnd.Checked = false;
                chkEnableKiaiStart.Visible = false;
                chkEnableKiaiEnd.Visible = false;
                chkApplyStartObject.Checked = true;
                chkApplyEndObject.Checked = true;
                chkApplyStartObject.Visible = false;
                chkApplyEndObject.Visible = false;
            }
        }
        private void rdoOnlyBarline_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnlyBarline.Checked)
            {
                rdoOnlyOnNotes.Visible = true;
                rdoOnlyOutNotes.Visible = true;
                rdoOnlyOnNotes.Text = "���ߐ��̂�";
                rdoOnlyOutNotes.Text = "���ߐ��ȊO";
                objectCode = 0;
                //objectCode = 0b10000000;
            }
        }
        private void rdoOnlyBookMark_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnlyBookMark.Checked)
            {
                // Tab�R���g���[�����̃R���g���[�������ׂĖ�����
                chkEnableKiaiStart.Checked = false;
                chkEnableKiaiEnd.Checked = false;
                chkEnableOffset.Checked = false;
                txtOffset.Text = string.Empty;
                chkEnableKiaiStart.Visible = false;
                chkEnableKiaiEnd.Visible = false;
                chkEnableOffset.Visible = false;
                txtOffset.Visible = false;
                lblMiliSecond.Visible = false;
                //objectCode = int.MinValue;
                rdoOnlyOnNotes.Visible = true;
                rdoOnlyOutNotes.Visible = true;
                rdoOnlyOnNotes.Text = "Bookmark�̂�";
                rdoOnlyOutNotes.Text = "Bookmark�ȊO";
                objectCode = 0;
            }
            else
            {
                // Tab�R���g���[�����̃R���g���[����L����
                chkEnableOffset.Visible = true;
                txtOffset.Visible = true;
                lblMiliSecond.Visible = true;
            }
        }
        private void rdoOnlySpecificHitObject_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnlySpecificHitObject.Checked)
            {
                // �����object�֘A�̃R���g���[����L����
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
                // pictureBox�ɐݒ肳��Ă���MouseDown�C�x���g��ݒ肷��
                picSpecificNormalDong.MouseDown += picSpecificNormalDong_MouseDown;
                picSpecificFinisherDong.MouseDown += picSpecificFinisherDong_MouseDown;
                picSpecificNormalKa.MouseDown += picSpecificNormalKa_MouseDown;
                picSpecificFinisherKa.MouseDown += picSpecificFinisherKa_MouseDown;
                picSpecificNormalSlider.MouseDown += picSpecificNormalSlider_MouseDown;
                picSpecificFinisherSlider.MouseDown += picSpecificFinisherSlider_MouseDown;
                picSpecificNormalSpinner.MouseDown += picSpecificNormalSpinner_MouseDown;
                objectCode = 0;
                rdoOnlyOnNotes.Visible = false;
                rdoOnlyOutNotes.Visible = false;
            }
            else
            {
                // �����object�֘A�̃R���g���[���𖳌���
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
                // pictureBox�ɐݒ肳��Ă���MouseDown�C�x���g���O��
                picSpecificNormalDong.MouseDown -= picSpecificNormalDong_MouseDown;
                picSpecificFinisherDong.MouseDown -= picSpecificFinisherDong_MouseDown;
                picSpecificNormalKa.MouseDown -= picSpecificNormalKa_MouseDown;
                picSpecificFinisherKa.MouseDown -= picSpecificFinisherKa_MouseDown;
                picSpecificNormalSlider.MouseDown -= picSpecificNormalSlider_MouseDown;
                picSpecificFinisherSlider.MouseDown -= picSpecificFinisherSlider_MouseDown;
                picSpecificNormalSpinner.MouseDown -= picSpecificNormalSpinner_MouseDown;
                // �摜�����ɖ߂�
                picSpecificNormalDong.Image = Properties.Resources.d;
                picSpecificFinisherDong.Image = Properties.Resources.d;
                picSpecificNormalKa.Image = Properties.Resources.k;
                picSpecificFinisherKa.Image = Properties.Resources.k;
                picSpecificNormalSlider.Image = Properties.Resources.slider;
                picSpecificFinisherSlider.Image = Properties.Resources.slider;
                picSpecificNormalSpinner.Image = Properties.Resources.spinner;
                // �I�����ƃR�[�h�̏�����
                isOnlySpecificHitObjectArray = new bool[7] { false, false, false, false, false, false, false };
            }
        }
        private void tabExecuteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // �폜���ʂ̍��ڂɂȂ����ꍇ�̏���
            if (beforeSelectedTabIndex == 1)
            {
                ReturnRemoveControls();
            }
            switch (tabExecuteType.SelectedIndex)
            {
                case 0:
                    // Add
                    if (beforeSelectedTabIndex == 1)
                    {
                        txtOffset.Text = txtStartOffset.Text;
                    }
                    break;
                case 1:
                    // Remove
                    InitializeApplyControls();
                    InitializeRemoveControls();
                    if (beforeSelectedTabIndex == 0)
                    {
                        txtStartOffset.Text = txtOffset.Text;
                    }
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
                    isSetMode[0] = true;
                    isSetMode[1] = false;
                    InitializeBeatSnapControls();
                    break;
                case 1:
                    // BeatSnap
                    isSetMode[0] = false;
                    isSetMode[1] = true;
                    InitializeHitObjectsControls();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
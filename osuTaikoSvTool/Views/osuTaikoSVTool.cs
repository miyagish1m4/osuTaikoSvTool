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
        /// osu.exeのメモリデータ取得処理
        /// </summary>
        private void UpdateMemoryData()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(15);
                    // osu.exeを探す
                    var processes = Process.GetProcessesByName("osu!");
                    if (processes.Length == 0)
                    {
                        throw new Exception("osu!が起動されていません。");
                    }
                    // osuフォルダ取得処理
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
                    // メモリから譜面の情報を取得する
                    sreader.TryRead(baseAddresses.Beatmap);
                    sreader.TryRead(baseAddresses.GeneralData);
                    currentTime = baseAddresses.GeneralData.AudioTime;
                    // 譜面のフォルダを取得
                    string osuBeatmapPath = Path.Combine(songsPath ?? "",
                                                         baseAddresses.Beatmap.FolderName ?? "",
                                                         baseAddresses.Beatmap.OsuFileName ?? "");
                    // 譜面のデータを取得
                    OsuParsers.Beatmaps.Beatmap beatmapData = BeatmapDecoder.Decode(osuBeatmapPath);
                    // タイトル
                    beatmapInfo.title = beatmapData.Version <= 9 ? beatmapData.MetadataSection.Title : beatmapData.MetadataSection.TitleUnicode;
                    // アーティスト
                    beatmapInfo.artist = beatmapData.Version <= 9 ? beatmapData.MetadataSection.Artist : beatmapData.MetadataSection.ArtistUnicode;
                    // Diff名
                    beatmapInfo.version = beatmapData.MetadataSection.Version;
                    // マッパー名
                    beatmapInfo.creator = beatmapData.MetadataSection.Creator;
                    // 譜面のパス
                    beatmapInfo.beatmapPath = osuBeatmapPath;
                    // BGのパス
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
                    // このExceptionはErrorログに書き込むと容量が膨大になってしまうため、
                    // Errorログには書かずConsoleログに出力
                    Console.WriteLine(ex);
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
                    // 前回取得したデータと同じ場合は処理を行わない
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
                    // テキストラベルに譜面の情報を書き込む
                    lblFileName.Text = beatmapInfo.artist.Replace("&", "&&") + " - " +
                                       beatmapInfo.title.Replace("&", "&&") + " [" +
                                       beatmapInfo.version.Replace("&", "&&") + "]";
                    // バックアップフォルダ名を設定する
                    backupDirectoryName = beatmapInfo.artist + " - " +
                                          beatmapInfo.title + " (" +
                                          beatmapInfo.creator + ") [" +
                                          beatmapInfo.version + "]";
                    preBeatmapInfo.beatmapPath = beatmapInfo.beatmapPath;
                    // BGのパスが取得できている場合はBGをフォームに表示する
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
                    // このExceptionはErrorログに書き込むと容量が膨大になってしまうため、
                    // Errorログには書かずConsoleログに出力
                    Console.WriteLine(ex);
                }
            }
        }
        /// <summary>
        /// 処理項目タブが"適応"の時のコントロールの初期化処理
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
        /// 実行項目タブが"削除"の時のコントロールの初期化処理
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
        /// 実行項目タブが"削除"から変更された時のコントロールの初期化処理
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
            chkEnableOffset.Checked = true;
            chkApplyStartObject.Checked = true;
            chkApplyEndObject.Checked = true;
        }
        /// <summary>
        /// 処理項目タブが"ビートスナップ間隔"の時のコントロールの初期化処理
        /// </summary>
        private void InitializeBeatSnapControls()
        {
            chkEnableBeatSnap.Checked = false;
        }
        /// <summary>
        /// メイン処理(SV.Volume)
        /// </summary>
        /// <param name="executeCode">実行コード</param>
        private void ExecuteProcess(int executeCode)
        {
            bool isSvCalculation = false;
            // 入力値と譜面情報が取得できていない場合はエラーダイアログを表示する
            if (userInputData == null || beatmapData == null)
            {
                Common.ShowMessageDialog("E_A-D-001");
                return;
            }
            // 実行コードにSV処理を行う
            switch (executeCode)
            {
                // 追加
                case Constants.EXECUTE_APPLY:
                    isSvCalculation = SVCalculatorService.Apply(userInputData, beatmapData, ref timingPoints);
                    beatmapData.timingPoints.AddRange(timingPoints);
                    beatmapData.timingPoints = beatmapData.timingPoints.OrderBy(a => a.time).ThenByDescending(b => b.isRedLine ? 1 : 0).ToList();
                    timingPoints.Clear();
                    break;
                // 削除
                case Constants.EXECUTE_REMOVE:
                    isSvCalculation = SVCalculatorService.Remove(userInputData, beatmapData);
                    break;
            }
            if (!isSvCalculation)
            {
                // 失敗した場合はエラーダイアログを表示する
                Common.ShowMessageDialog("E_A-P-001");
                return;
            }
            // バックアップを作成する
            if (!BeatmapHelper.CreateBackup(this.beatmapInfo.beatmapPath, this.backupDirectoryName))
            {
                // 失敗した場合はエラーダイアログを表示する
                Common.ShowMessageDialog("E_A-P-001");
                return;
            }
            // デバッグ用CSV出力
            // 内容確認などに使ってね
            //if (!Utils.Helper.Debug.ExportToCsvFile(beatmapData, this.backupDirectoryName))
            // osuファイルに上書きする
            if (!BeatmapHelper.ExportToOsuFile(beatmapData, this.beatmapInfo.beatmapPath))
            {
                // 失敗した場合はエラーダイアログを表示する
                Common.ShowMessageDialog("E_A-P-001");
                return;
            }
            // 入力値をxmlファイルにシリアライズする
            if (!UserInputDataHelper.SerializeUserInputData(userInputData))
            {
                // 失敗した場合はエラーダイアログを表示する
                Common.ShowMessageDialog("E_A-P-001");
                return;
            }
            // 成功した場合はメッセージダイアログを表示する
            Common.ShowMessageDialog("I_A-P-001");
            isExecute = true;
            return;
        }
        /// <summary>
        /// 譜面情報の取得処理
        /// </summary>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private bool GetBeatmap()
        {
            // 譜面情報がリアルタイムで取得できていない場合はエラーダイアログを表示する
            if (this.beatmapInfo.beatmapPath == null || this.beatmapInfo.beatmapPath == string.Empty)
            {
                Common.ShowMessageDialog("E_A-D-001");
                return false;
            }
            // 譜面の内容を取得する
            beatmapData = BeatmapHelper.GetBeatmapData(this.beatmapInfo.beatmapPath);
            // 取得できなかった場合はエラーダイアログを表示する
            if (beatmapData.version == string.Empty)
            {
                Common.ShowMessageDialog("E_A-D-001");
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
            // ApplicationExitイベントハンドラを追加
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            // それぞれのコントロールの初期化処理
            InitializeApplyControls();
            picDisplayBg.Controls.Add(lblFileName);
            pnlRelativeSvGroup.Visible = false;
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
        private void osuTaikoSVTool_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                //［Ctrl］+［S］が押されたらSV適応/削除を実行する
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
                //［Ctrl］+［Z］が押されたら実行前の譜面にする
                case (Keys.Z | Keys.Control):
                    if(!isExecute)
                    {
                        break;
                    }
                    if (BeatmapHelper.ExportToPreviousOsuFile(this.beatmapInfo.beatmapPath, this.backupDirectoryName))
                    {
                        // 成功した場合は完了メッセージを表示する
                        Common.ShowMessageDialog("I_A-P-002");
                    }
                    else
                    {
                        // 失敗した場合はエラーダイアログを表示する
                        Common.ShowMessageDialog("E_A-P-001");
                    }
                    break;
            }

        }
        private void Application_ApplicationExit(object? sender, EventArgs e)
        {
            //ApplicationExitイベントハンドラを削除
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
            Common.WriteInfoMessage("LOG_I-END");
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                // 入力値をUserInputDataクラスに格納
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
                // 譜面情報の取得
                if (!GetBeatmap())
                {
                    return;
                }
                // 追加処理の実行
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
                // 入力値をUserInputDataクラスに格納
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
                // 譜面情報の取得
                if (!GetBeatmap())
                {
                    return;
                }
                // 削除処理の実行
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
            // バックアップフォルダをエクスプローラで開く
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
            // osuで流れている現時間をmm:ss:fff形式でセットする
            txtTimingFrom.Text = Common.ConvertFormatTiming(currentTime);
        }
        private void btnSetTimingTo_Click(object sender, EventArgs e)
        {
            // osuで流れている現時間をmm:ss:fff形式でセットする
            txtTimingTo.Text = Common.ConvertFormatTiming(currentTime);
        }
        private void btnSwapTiming_Click(object sender, EventArgs e)
        {
            // Timingの始点と終点を入れ替える
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
            // SVの始点と終点を入れ替える
            string SVBuff = "";
            SVBuff = txtSvFrom.Text;
            txtSvFrom.Text = txtSvTo.Text;
            txtSvTo.Text = SVBuff;
        }
        private void btnSwapVolume_Click(object sender, EventArgs e)
        {
            // Volumeの始点と終点を入れ替える
            string volumeBuff = "";
            volumeBuff = txtVolumeFrom.Text;
            txtVolumeFrom.Text = txtVolumeTo.Text;
            txtVolumeTo.Text = volumeBuff;

        }
        private void chkEnableSv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableSv.Checked)
            {
                // SV関連のコントロールを有効化
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
                // SV関連のコントロールを無効化
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
                // Volume関連のコントロールを有効化
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
                // Volume関連のコントロールを無効化
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
                // offset関連のコントロールを有効化
                txtOffset.Text = string.Empty;
                txtOffset.BackColor = SystemColors.Window;
                txtOffset.Enabled = true;
            }
            else
            {
                // offset関連のコントロールを無効化
                txtOffset.BackColor = SystemColors.WindowFrame;
                txtOffset.Enabled = false;
            }
        }
        private void chkEnableBeatSnap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableBeatSnap.Checked)
            {
                // beatsnap関連のコントロールを有効化
                txtBeatSnap.Text = string.Empty;
                txtBeatSnap.BackColor = SystemColors.Window;
                txtBeatSnap.Enabled = true;
            }
            else
            {
                // beatsnap関連のコントロールを無効化
                txtBeatSnap.BackColor = SystemColors.WindowFrame;
                txtBeatSnap.Enabled = false;
            }

        }
        private void chkEnableKiai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableKiai.Checked && rdoAllHitObjects.Checked)
            {
                // kiaiの始点終点のコントロールを有効化
                chkEnableKiaiStart.Visible = true;
                chkEnableKiaiEnd.Visible = true;
            }
            else
            {
                // kiaiの始点終点のコントロールを無効化
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
            // 仮実装
            // 実行履歴画面を表示する
            Form historyForm = new HistoryForm();
            historyForm.ShowDialog();
        }
        private void rdoAllHitObjects_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAllHitObjects.Checked)
            {
                // すべてのobject関連のコントロールを有効化
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
                // すべてのobject関連のコントロールを無効化
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
                rdoOnlyOnNotes.Text = "小節線のみ";
                rdoOnlyOutNotes.Text = "小節線以外";
                objectCode = 0;
                //objectCode = 0b10000000;
            }
        }
        private void rdoOnlyBookMark_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnlyBookMark.Checked)
            {
                // Tabコントロール内のコントロールをすべて無効化
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
                rdoOnlyOnNotes.Text = "Bookmarkのみ";
                rdoOnlyOutNotes.Text = "Bookmark以外";
                objectCode = 0;
            }
            else
            {
                // Tabコントロール内のコントロールを有効化
                chkEnableOffset.Visible = true;
                txtOffset.Visible = true;
                lblMiliSecond.Visible = true;
            }
        }
        private void rdoOnlySpecificHitObject_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnlySpecificHitObject.Checked)
            {
                // 特定のobject関連のコントロールを有効化
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
                objectCode = 0;
                rdoOnlyOnNotes.Visible = false;
                rdoOnlyOutNotes.Visible = false;
            }
            else
            {
                // 特定のobject関連のコントロールを無効化
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
            }
        }
        private void tabExecuteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 削除→別の項目になった場合の処理
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
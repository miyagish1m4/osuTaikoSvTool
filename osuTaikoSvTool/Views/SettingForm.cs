using osuTaikoSvTool.Models;
using osuTaikoSvTool.Utils.Helper;
using osuTaikoSvTool.Utils;
using osuTaikoSvTool.Properties;

namespace osuTaikoSvTool.Views
{
    public partial class SettingForm : Form
    {
        #region クラス変数
        private Config config;
        #endregion
        #region メソッド
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="config">コンフィグ</param>
        internal SettingForm(Config config)
        {
            object? sender = null;
            EventArgs? e = null;
            InitializeComponent();
            this.config = config;
            InitializeLabelText();
            SetChkAdvanceMode(config.advanceMode);
        }
        /// <summary>
        /// ラベルテキストの初期化設定
        /// </summary>
        private void InitializeLabelText()
        {
            Common.SetLabelText(lblLanguage, "LBL_SETTINGS_LANGUAGE");
            Common.SetLabelText(lblMaxBackupCount, "LBL_SETTINGS_BACKUP_MAX_COUNT");
            Common.SetLabelText(lblMaxHistoryCount, "LBL_SETTINGS_INPUT_HISTORY_MAX_COUNT");
            Common.SetLabelText(btnSave, "LBL_SETTINGS_SAVE");
        }
        /// <summary>
        /// コントロール初期化設定
        /// </summary>
        private void InitializeControls()
        {
            cmbLanguage.Items.AddRange(Constants.LANGUAGES);
            cmbLanguage.Text = config.language;
            txtMaxBackupCount.Text = config.maxBackupCount.ToString();
            txtHistoryCount.Text = config.maxHistoryCount.ToString();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }
        #endregion
        #region イベントハンドラ
        private void SettingForm_Load(object sender, EventArgs e)
        {
            // コントロールの初期化
            InitializeControls();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // app.configに設定値をセットする
            if (SettingHelper.SetConfig(cmbLanguage.Text,
                                        txtMaxBackupCount.Text,
                                        txtHistoryCount.Text,
                                        chkAdvanceMode.Checked,
                                        config))
            {
                Common.LoadConfig(config);
                // 設定値に応じてバックアップと入力履歴ファイルの保持数を変更する
                if (SettingHelper.ResetBackupFile(config) &&
                    SettingHelper.ResetHistoryFile(config))
                {
                    // 成功した場合はメッセージダイアログを表示する
                    Common.ShowMessageDialog("I_A-P-003");
                    this.Close();
                }
                else
                {
                    // 失敗した場合はエラーダイアログを表示する
                    Common.ShowMessageDialog("E_A-P-002");
                }
            }
        }
        #endregion

        private void chkAdvanceMode_CheckedChanged(object? sender, EventArgs? e)
        {
            chkAdvanceMode.Text = chkAdvanceMode.Checked ? "✔" : "";
        }
        private void SetChkAdvanceMode(int isAdvanceMode)
        {
            chkAdvanceMode.Checked = isAdvanceMode == 1 ? true : false;
        }
    }
}

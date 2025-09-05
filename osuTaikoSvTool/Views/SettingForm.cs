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
        internal SettingForm(Config config)
        {
            InitializeComponent();
            this.config = config;
        }
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
                                        config))
            {
                // 設定値に応じてバックアップと入力履歴ファイルの保持数を変更する
                if (SettingHelper.ResetBackupFile(config) &&
                    SettingHelper.ResetHistoryFile(config))
                {
                    // 成功した場合はメッセージダイアログを表示する
                    Common.ShowMessageDialog("I_A-P-003");
                    this.Close();
                } else
                {
                    // 失敗した場合はエラーダイアログを表示する
                    Common.ShowMessageDialog("E_A-P-002");
                }
            }
        }
        #endregion
    }
}

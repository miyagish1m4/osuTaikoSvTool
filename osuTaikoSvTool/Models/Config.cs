using System.Configuration;

namespace osuTaikoSvTool.Models
{
    /// <summary>
    /// 設定情報クラス
    /// </summary>
    internal class Config
    {
        // バックアップの最大保持数
        internal int maxBackupCount { get; set; }
        // 入力履歴ファイルの最大保持数
        internal int maxHistoryCount { get; set; }
        // 言語設定
        internal string? language { get; set; }
        // AdvanceMode設定
        internal int advanceMode { get; set; }
        /// <summary>
        /// configファイルの読み込み処理
        /// </summary>
        internal void ConfigLoad()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // config読み込み
            maxBackupCount = Convert.ToInt32(config.AppSettings.Settings["maxBackupCount"].Value);
            maxHistoryCount = Convert.ToInt32(config.AppSettings.Settings["maxHistoryCount"].Value);
            language = config.AppSettings.Settings["language"].Value;
            advanceMode = Convert.ToInt32(config.AppSettings.Settings["advanceMode"].Value);
        }
        /// <summary>
        /// configファイルの書き込み処理
        /// </summary>
        internal void ConfigSave()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // config書き込み
            config.AppSettings.Settings["maxBackupCount"].Value = maxBackupCount.ToString();
            config.AppSettings.Settings["maxHistoryCount"].Value = maxHistoryCount.ToString();
            config.AppSettings.Settings["language"].Value = language;
            config.AppSettings.Settings["advanceMode"].Value = advanceMode.ToString();
            config.Save();
        }
    }
}

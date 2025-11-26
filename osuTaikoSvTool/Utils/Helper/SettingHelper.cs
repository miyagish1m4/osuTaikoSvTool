using osuTaikoSvTool.Models;
using osuTaikoSvTool.Properties;

namespace osuTaikoSvTool.Utils.Helper
{
    internal class SettingHelper
    {
        /// <summary>
        /// 設定画面で指定された値をconfigファイルに設定する
        /// </summary>
        /// <param name="language">言語</param>
        /// <param name="maxBackupCount">バックアップの最大保持数</param>
        /// <param name="maxHistoryCount">入力履歴ファイルの最大保持数</param>
        /// <param name="config">コンフィグクラス</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        internal static bool SetConfig(string language,
                                       string maxBackupCount,
                                       string maxHistoryCount,
                                       bool isAdvanceMode,
                                       Config config)
        {
            try
            {
                int retMaxBackupCount = 0;
                int retMaxHistoryCount = 0;
                int advanceMode = isAdvanceMode ? 1 : 0;
                if (!ValidateMaxBackupCount(maxBackupCount, ref retMaxBackupCount) ||
                    !ValidateMaxHistoryCount(maxHistoryCount, ref retMaxHistoryCount))
                {

                    return false;
                }
                config.language = language;
                config.maxBackupCount = retMaxBackupCount;
                config.maxHistoryCount = retMaxHistoryCount;
                config.advanceMode = advanceMode;
                config.ConfigSave();
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// バックアップの最大保持数のバリデーションチェックをする関数
        /// </summary>
        /// <param name="maxBackupCount">バックアップの最大保持数</param>
        /// <param name="retMaxBackupCount">チェック後のバックアップの最大保持数</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool ValidateMaxBackupCount(string maxBackupCount, ref int retMaxBackupCount)
        {
            try
            {
                if (maxBackupCount == string.Empty)
                {
                    //バックアップの最大保持数の入力がない
                    Common.ShowMessageDialog("E_V-EM-007");
                    return false;
                }
                if (!int.TryParse(maxBackupCount, out retMaxBackupCount))
                {
                    //バックアップの最大保持数のフォーマットが間違えている
                    Common.ShowMessageDialog("E_V-T-006");
                    return false;
                }
                if ((retMaxBackupCount < 1) || (retMaxBackupCount > 100))
                {
                    //バックアップの最大保持数が1～100以内ではない
                    Common.ShowMessageDialog("E_V-C-007");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// 入力履歴ファイルの最大保持数のバリデーションチェックをする関数
        /// </summary>
        /// <param name="maxHistoryCount">入力履歴ファイルの最大保持数</param>
        /// <param name="retMaxHistoryCount">チェック後の入力履歴ファイルの最大保持数</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool ValidateMaxHistoryCount(string maxHistoryCount, ref int retMaxHistoryCount)
        {
            try
            {
                if (maxHistoryCount == string.Empty)
                {
                    //入力履歴ファイルの最大保持数の入力がない
                    Common.ShowMessageDialog("E_V-EM-006");
                    return false;
                }
                if (!int.TryParse(maxHistoryCount, out retMaxHistoryCount))
                {
                    //入力履歴ファイルの最大保持数のフォーマットが間違えている
                    Common.ShowMessageDialog("E_V-T-005");
                    return false;
                }
                if ((retMaxHistoryCount < 1) || (retMaxHistoryCount > 1000))
                {
                    //入力履歴ファイルの最大保持数が1～1000以内ではない
                    Common.ShowMessageDialog("E_V-C-008");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// バックアップの最大保持数分新しいバックアップファイルを残す
        /// </summary>
        /// <param name="config">コンフィグクラス</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        internal static bool ResetBackupFile(Config config)
        {
            try
            {
                string backupPath = Directory.GetCurrentDirectory() + Constants.BACKUP_DIRECTORY + "\\";
                string[] songPath = Directory.GetDirectories(backupPath);
                // バックアップを作成した譜面の数分ループ
                for (global::System.Int32 i = 0; i < songPath.Length; i++)
                {
                    // バックアップフォルダ内にあるosuファイルを取得
                    string[] backupFiles = Directory.GetFiles(songPath[i], "*.osu");
                    List<long> fileDate = [];
                    // ファイル名の日付のみを取得し、数値にする
                    foreach (var file in backupFiles)
                    {
                        string date = file.Replace(songPath[i] + "\\", "")
                                          .Replace(".osu", "")
                                          .Replace("_", "");
                        fileDate.Add(Convert.ToInt64(date));
                    }
                    // 数値を降順にソートする
                    fileDate.Sort();
                    fileDate.Reverse();
                    // バックアップの最大保持数分新しいファイルのみ残す
                    for (global::System.Int32 j = (fileDate.Count) - (1); j >= config.maxBackupCount; j--)
                    {
                        string targetFileName = fileDate[j].ToString("0000_00_00_00_00_00_000");
                        targetFileName = Path.Combine(songPath[i], targetFileName + ".osu");
                        File.Delete(targetFileName);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// 入力履歴ファイルの最大保持数分新しい入力履歴ファイルを残す
        /// </summary>
        /// <param name="config">コンフィグクラス</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        internal static bool ResetHistoryFile(Config config)
        {
            try
            {
                string historyPath = Directory.GetCurrentDirectory() + Constants.HISTORY_DIRECTORY + "\\";
                // 入力履歴フォルダ内にあるosuファイルを取得
                string[] backupFiles = Directory.GetFiles(historyPath, "*.xml");
                List<long> fileDate = [];
                // ファイル名の日付のみを取得し、数値にする
                foreach (var file in backupFiles)
                {
                    string date = file.Replace(historyPath, "")
                                      .Replace(".xml", "")
                                      .Replace("history_", "");
                    fileDate.Add(Convert.ToInt64(date));
                }
                // 数値を降順にソートする
                fileDate.Sort();
                fileDate.Reverse();
                // 入力履歴ファイルの最大保持数分新しいファイルのみ残す
                for (global::System.Int32 j = (fileDate.Count) - (1); j >= config.maxHistoryCount; j--)
                {
                    string targetFileName = fileDate[j].ToString("history_00000000000000000");
                    targetFileName = Path.Combine(historyPath, targetFileName + ".xml");
                    File.Delete(targetFileName);
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }
}
    }
}

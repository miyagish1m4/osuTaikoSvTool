using System.Text;
using osuTaikoSvTool.Properties;

namespace osuTaikoSvTool.Utils
{
    class Common
    {
        /// <summary>
        /// ファイル,フォルダの初期化設定
        /// </summary>
        internal static void InitializeDirectoryAndFiles()
        {
            DateTime currentDateTime = DateTime.Now;
            string infoLogPath = Directory.GetCurrentDirectory() + Constants.INFO_LOG_DIRECTORY + "\\info_" + currentDateTime.ToString("yyyyMMdd") + Constants.LOG_EXTENSION;
            string warningLogPath = Directory.GetCurrentDirectory() + Constants.WARNING_LOG_DIRECTORY + "\\warning_" + currentDateTime.ToString("yyyyMMdd") + Constants.LOG_EXTENSION;
            string errorLogPath = Directory.GetCurrentDirectory() + Constants.ERROR_LOG_DIRECTORY + "\\error_" + currentDateTime.ToString("yyyyMMdd") + Constants.LOG_EXTENSION;
            // Logディレクトリの作成
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.LOG_DIRECTORY))
            {
                string folderpath = Directory.GetCurrentDirectory() + Constants.LOG_DIRECTORY;
                Directory.CreateDirectory(folderpath);
                var folder_attr = File.GetAttributes(folderpath);
                File.SetAttributes(folderpath, folder_attr | FileAttributes.Hidden);
            }
            // INFOログディレクトリの作成
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.INFO_LOG_DIRECTORY))
            {
                string folderpath = Directory.GetCurrentDirectory() + Constants.INFO_LOG_DIRECTORY;
                Directory.CreateDirectory(folderpath);
                var folder_attr = File.GetAttributes(folderpath);
                File.SetAttributes(folderpath, folder_attr | FileAttributes.Hidden);
            }
            // INFOログファイルの作成
            if (!File.Exists(infoLogPath))
            {
                File.Create(infoLogPath).Close();
            }
            // WARNINGログディレクトリの作成
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.WARNING_LOG_DIRECTORY))
            {
                string folderpath = Directory.GetCurrentDirectory() + Constants.WARNING_LOG_DIRECTORY;
                Directory.CreateDirectory(folderpath);
                var folder_attr = File.GetAttributes(folderpath);
                File.SetAttributes(folderpath, folder_attr | FileAttributes.Hidden);
            }
            // WARNINGログファイルの作成
            if (!File.Exists(warningLogPath))
            {
                File.Create(warningLogPath).Close();
            }
            // ERRORログディレクトリの作成
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.ERROR_LOG_DIRECTORY))
            {
                string folderpath = Directory.GetCurrentDirectory() + Constants.ERROR_LOG_DIRECTORY;
                Directory.CreateDirectory(folderpath);
                var folder_attr = File.GetAttributes(folderpath);
                File.SetAttributes(folderpath, folder_attr | FileAttributes.Hidden);
            }
            // ERRORログファイルの作成
            if (!File.Exists(errorLogPath))
            {
                File.Create(errorLogPath).Close();
            }
            // 履歴ディレクトリの作成
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.HISTORY_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.HISTORY_DIRECTORY);
            }
            // バックアップディレクトリの作成
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.BACKUP_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.BACKUP_DIRECTORY);
            }
        }
        /// <summary>
        /// songsフォルダを取得する
        /// </summary>
        /// <param name="osuDirectory">osuフォルダパス</param>
        /// <returns>songsフォルダパス</returns>
        internal static string GetSongsFolderLocation(string osuDirectory)
        {
            // ユーザー名の取得
            string userName = Environment.UserName;
            // osuのユーザー設定ファイルの取得
            string file = Path.Combine(osuDirectory, "osu!." + userName + ".cfg");
            if (!File.Exists(file))
            {
                // osuのユーザー設定ファイルが存在しない場合はosuフォルダ直下のsongsフォルダを参照する
                return Path.Combine(osuDirectory, "Songs");
            }
            // ユーザー設定を読み込む
            foreach (string readLine in File.ReadLines(file))
            {
                if (!readLine.StartsWith("BeatmapDirectory"))
                {
                    continue;
                }
                // songsフォルダが指定されていた場合はそのsongsフォルダのパスを取得する
                string path = readLine.Split('=')[1].Trim(' ');
                return path == "Songs" ? Path.Combine(osuDirectory, "Songs") : path;
            }
            // songsフォルダが指定されていない場合はosuフォルダ直下のsongsフォルダを参照する
            return Path.Combine(osuDirectory, "Songs");
        }
        /// <summary>
        /// ダイアログを表示する
        /// </summary>
        /// <param name="messageCode">メッセージコード、またはメッセージ</param>
        internal static void ShowMessageDialog(string messageCode)
        {
            string messageLevel = messageCode[..1];
            switch (messageLevel)
            {
                // Informationメッセージの場合
                case "I":
                    MessageBox.Show(WriteDialogMessage(messageCode), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                // Warningメッセージの場合
                case "W":
                    MessageBox.Show(WriteDialogMessage(messageCode), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                // Errorメッセージの場合
                case "E":
                    MessageBox.Show(WriteDialogMessage(messageCode), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                // 上記以外の場合
                default:
                    MessageBox.Show(messageCode, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }
        /// <summary>
        /// ダイアログメッセージ設定処理
        /// </summary>
        /// <param name="messageCode">メッセージコード、またはメッセージ</param>
        /// <returns>ダイアログメッセージ</returns>
        internal static string WriteDialogMessage(string messageCode)
        {
            string message;
            if (Messages.DialogMessages.ContainsKey(messageCode))
            {
                // メッセージリストにメッセージIDがあった場合は
                // メッセージIDと紐づくメッセージを出力する
                message = Messages.DialogMessages[messageCode];
            }
            else
            {
                // メッセージリストにメッセージIDがなかった場合は
                // 引数で渡された文字列をそのまま出力する
                message = messageCode;
            }
            return message;
        }
        /// <summary>
        /// 例外エラー発生時のメッセージ書き込み処理
        /// </summary>
        /// <param name="ex">Exceptionクラス</param>
        internal static void WriteExceptionMessage(Exception ex)
        {
            DateTime currentDateTime = DateTime.Now;
            string errorLogPath = Directory.GetCurrentDirectory() + Constants.ERROR_LOG_DIRECTORY + "\\error_" + currentDateTime.ToString("yyyyMMdd") + Constants.LOG_EXTENSION;
            // ログフォルダがない場合は作成する
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.ERROR_LOG_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.ERROR_LOG_DIRECTORY);
            }
            // Exceptionのメッセージと発生メソッドなどをERRORメッセージとして出力する
            WriteMessage(ex.Message + "\r\n" +
                         ex.TargetSite + "\r\n" +
                         ex.ToString(),
                         Constants.LOG_LEVEL_ERROR, errorLogPath, currentDateTime);
        }
        /// <summary>
        /// Infoメッセージの書き込み処理
        /// </summary>
        /// <param name="messageCode">メッセージコード、またはメッセージ</param>
        internal static void WriteInfoMessage(string messageCode)
        {
            DateTime currentDateTime = DateTime.Now;
            string infoLogPath = Directory.GetCurrentDirectory() + Constants.INFO_LOG_DIRECTORY + "\\info_" + currentDateTime.ToString("yyyyMMdd") + Constants.LOG_EXTENSION;
            // ログフォルダがない場合は作成する
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.INFO_LOG_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.INFO_LOG_DIRECTORY);
            }
            // INFOメッセージを出力する
            WriteMessage(messageCode, Constants.LOG_LEVEL_INFO, infoLogPath, currentDateTime);
        }
        /// <summary>
        /// Warningメッセージの書き込み処理
        /// </summary>
        /// <param name="messageCode">メッセージコード、またはメッセージ</param>
        internal static void WriteWarningMessage(string messageCode)
        {
            DateTime currentDateTime = DateTime.Now;
            string warningLogPath = Directory.GetCurrentDirectory() + Constants.WARNING_LOG_DIRECTORY + "\\warning_" + currentDateTime.ToString("yyyyMMdd") + Constants.LOG_EXTENSION;
            // ログフォルダがない場合は作成する
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.WARNING_LOG_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.WARNING_LOG_DIRECTORY);
            }
            // WARNINGメッセージを出力する
            WriteMessage(messageCode, Constants.LOG_LEVEL_WARNING, warningLogPath, currentDateTime);
        }
        /// <summary>
        /// Errorメッセージの書き込み処理
        /// </summary>
        /// <param name="messageCode">メッセージコード、またはメッセージ</param>
        internal static void WriteErrorMessage(string messageCode)
        {
            DateTime currentDateTime = DateTime.Now;
            string errorLogPath = Directory.GetCurrentDirectory() + Constants.ERROR_LOG_DIRECTORY + "\\error_" + currentDateTime.ToString("yyyyMMdd") + Constants.LOG_EXTENSION;
            // ログフォルダがない場合は作成する
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.ERROR_LOG_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.ERROR_LOG_DIRECTORY);
            }
            // ERRORメッセージを出力する
            WriteMessage(messageCode, Constants.LOG_LEVEL_ERROR, errorLogPath, currentDateTime);
        }
        /// <summary>
        /// ログメッセージ書き込み共通処理
        /// </summary>
        /// <param name="messageCode">メッセージコード、またはメッセージ</param>
        /// <param name="logLevel">ログレベル</param>
        /// <param name="logPath">ログのパス</param>
        /// <param name="date">現時刻</param>
        internal static void WriteMessage(string messageCode, string logLevel, string logPath, DateTime date)
        {
            string message = "";
            if (!File.Exists(logPath))
            {
                // 新規ファイル作成
                File.Create(logPath).Close();
            }
            if (Messages.LogMessages.ContainsKey(messageCode))
            {
                // メッセージリストにメッセージIDがあった場合は
                // メッセージIDと紐づくメッセージを出力する
                message = Messages.LogMessages[messageCode];
                using (StreamWriter writer = new(logPath, true, Encoding.GetEncoding("utf-8")))
                {
                    writer.WriteLine(date.ToString("[HH:mm:ss.fff]") + " " + logLevel + " : " + message);
                }
            }
            else
            {
                // メッセージリストにメッセージIDがなかった場合は
                // 引数で渡された文字列をそのまま出力する
                message = messageCode;
                using (StreamWriter writer = new(logPath, true, Encoding.GetEncoding("utf-8")))
                {
                    writer.WriteLine(message);
                }
            }
        }
        /// <summary>
        /// ユーザが入力したタイミングをミリ秒表記に変換する処理
        /// </summary>
        /// <param name="baseTiming">入力したタイミング (mm:ss:fff (notes))</param>
        /// <param name="returnTiming">変換後のタイミング (mmssfff)</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        internal static bool ConvertMsTiming(string baseTiming, ref int returnTiming)
        {
            try
            {

                string[] arr = baseTiming.Split(':');
                // ms表記で指定されている場合はint型に変換する
                if (arr.Length == 1)
                {
                    if (int.TryParse(baseTiming, out returnTiming))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // mm:ss:fff表記で指定されていた場合はms表記に変換し、int型に変換する
                arr[2] = arr[2][..3];
                returnTiming = Convert.ToInt32(arr[2]) +
                               Convert.ToInt32(arr[1]) * 1000 +
                               Convert.ToInt32(arr[0]) * 60000;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 取得したタイミングをmm:ss:fff表記に変換する処理
        /// </summary>
        /// <param name="currentTime">現タイミング</param>
        /// <returns>変換後のタイミング</returns>
        internal static string ConvertFormatTiming(int currentTime) 
        {
            int minute = currentTime / 60000;
            int second = (currentTime % 60000) / 1000;
            int milliSecond = currentTime % 1000;
            return minute.ToString("00") + ":" +
                   second.ToString("00") + ":" +
                   milliSecond.ToString("000");
        }

    }
}
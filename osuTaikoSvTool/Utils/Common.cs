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
            // 作業ディレクトリの作成
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.WORK_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.WORK_DIRECTORY);
            }
        }
        /// <summary>
        /// コンフィグファイルの初期化設定
        /// </summary>
        /// <returns>処理が<br/>・正常終了した場合は指定したフォルダパス<br/>・異常終了した場合は空文字</returns>
        //internal static string InitializeConfigDirectory()
        //{
        //    try
        //    {
        //        string configPath = Directory.GetCurrentDirectory() + "\\" + Constants.CONFIG_FILE_NAME;
        //        string? songsPath = "";
        //        if (!File.Exists(configPath) || File.ReadAllText(configPath) == "" || File.ReadAllText(configPath) == null)
        //        {
        //            MessageBox.Show(WriteDialogMessage("I_A-EM-001"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //            //{
        //            //    MessageBox.Show(WriteDialogMessage("E_A-P-002"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            //    return "";
        //            //}
        //            using (var OpenFolderDialog = new OpenFileDialog()
        //            {
        //                Title = "フォルダ選択ダイアログ",
        //                FileName = "SongFolder",
        //                Filter = "Folder|.",
        //                InitialDirectory = Directory.GetCurrentDirectory(),
        //                CheckFileExists = false
        //            })
        //            {
        //                if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
        //                {
        //                    songsPath = Path.GetDirectoryName(OpenFolderDialog.FileName);
        //                    if (!File.Exists(configPath))
        //                    {
        //                        // 新規ファイル作成
        //                        File.Create(configPath).Close();
        //                    }
        //                    MessageBox.Show(WriteDialogMessage("I_A-P-002"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                    StreamWriter configFile = new StreamWriter(configPath);
        //                    configFile.WriteLine(Constants.SONGS_DIRECTORY);
        //                    configFile.WriteLine(songsPath);
        //                    configFile.Close();
        //                }
        //                else
        //                {
        //                    MessageBox.Show(WriteDialogMessage("E_A-P-002"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    throw new Exception("Songsフォルダの設定がキャンセルされました。");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            var lines = File.ReadAllLines(configPath);
        //            for (global::System.Int32 i = 0; i < lines.Length; i++)
        //            {
        //                if (lines[i] == Constants.SONGS_DIRECTORY)
        //                {
        //                    songsPath = lines[i + 1];
        //                }
        //            }
        //        }
        //        return songsPath == null ? "" : songsPath;
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteErrorMessage("LOG_E-DIRECTORY-SONGS");
        //        WriteExceptionMessage(ex);
        //        return "";
        //    }

        public static string GetSongsFolderLocation(string osuDirectory)
        {
            string userName = Environment.UserName;
            string file = Path.Combine(osuDirectory, "osu!." + userName + ".cfg");
            if (!File.Exists(file)) return Path.Combine(osuDirectory, "Songs");

            foreach (string readLine in File.ReadLines(file))
            {
                if (!readLine.StartsWith("BeatmapDirectory")) continue;
                string path = readLine.Split('=')[1].Trim(' ');
                return path == "Songs" ? Path.Combine(osuDirectory, "Songs") : path;
            }

            return Path.Combine(osuDirectory, "Songs");
        }

        //}
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
                message = Messages.DialogMessages[messageCode];
            }
            else
            {
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
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.ERROR_LOG_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.ERROR_LOG_DIRECTORY);
            }
            WriteMessage(ex.Message + "\r\n" +
                         ex.TargetSite + "\r\n" +
                         ex.StackTrace,
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
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.INFO_LOG_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.INFO_LOG_DIRECTORY);
            }
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
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.WARNING_LOG_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.WARNING_LOG_DIRECTORY);
            }
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
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.ERROR_LOG_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.ERROR_LOG_DIRECTORY);
            }
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
                message = Messages.LogMessages[messageCode];
                using (StreamWriter writer = new StreamWriter(logPath, true, Encoding.GetEncoding("utf-8")))
                {
                    writer.WriteLine(date.ToString("[HH:mm:ss.fff]") + " " + logLevel + " : " + message);
                }
            }
            else
            {
                message = messageCode;
                using (StreamWriter writer = new StreamWriter(logPath, true, Encoding.GetEncoding("utf-8")))
                {
                    writer.WriteLine(message);
                }
            }
        }

        /// <summary>
        /// ユーザが入力したタイミングを変換する処理
        /// </summary>
        /// <param name="baseTiming">入力したタイミング (mm:ss:fff (notes))</param>
        /// <param name="returnTiming">変換後のタイミング (mmssfff)</param>
        /// <returns>処理が正常終了した場合はtrue、異常終了した場合はfalse</returns>
        internal static bool ConvertTiming(string baseTiming, ref int returnTiming)
        {
            try
            {
                string[] arr = baseTiming.Split(':');
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

    }
}
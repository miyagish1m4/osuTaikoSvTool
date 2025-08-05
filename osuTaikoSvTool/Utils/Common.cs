using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using osuTaikoSvTool.Properties;

namespace osuTaikoSvTool.Utils
{
    class Common
    {
        /// <summary>
        /// ログファイルの初期化設定
        /// </summary>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        internal static bool InitializeLogDirectory()
        {
            try
            {
                DateTime currentDateTime = DateTime.Now;
                string infoMessagePath = Directory.GetCurrentDirectory() + Constants.INFO_MESSAGE_DIRECTORY + "\\info_" + currentDateTime.ToString("yyyyMMdd") + Constants.LOG_EXTENSION;
                string errorMessagePath = Directory.GetCurrentDirectory() + Constants.ERROR_MESSAGE_DIRECTORY + "\\error_" + currentDateTime.ToString("yyyyMMdd") + Constants.LOG_EXTENSION;
                if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.BACKUP_DIRECTORY))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.BACKUP_DIRECTORY);
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.WORK_DIRECTORY))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.WORK_DIRECTORY);
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.INFO_MESSAGE_DIRECTORY))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.INFO_MESSAGE_DIRECTORY);
                }
                if (!File.Exists(infoMessagePath))
                {
                    // 新規ファイル作成
                    File.Create(infoMessagePath).Close();
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.WARNING_MESSAGE_DIRECTORY))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.WARNING_MESSAGE_DIRECTORY);
                }
                if (!File.Exists(infoMessagePath))
                {
                    // 新規ファイル作成
                    File.Create(infoMessagePath).Close();
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.ERROR_MESSAGE_DIRECTORY))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.ERROR_MESSAGE_DIRECTORY);
                }
                if (!File.Exists(errorMessagePath))
                {
                    // 新規ファイル作成
                    File.Create(errorMessagePath).Close();
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// コンフィグファイルの初期化設定
        /// </summary>
        /// <returns>処理が<br/>・正常終了した場合は指定したフォルダパス<br/>・異常終了した場合は空文字</returns>
        internal static string InitializeConfigDirectory()
        {
            try
            {
                string configPath = Directory.GetCurrentDirectory() + "\\" + Constants.CONFIG_FILE_NAME;
                string songsPath = "";
                if (!File.Exists(configPath) || File.ReadAllText(configPath) == "" || File.ReadAllText(configPath) == null)
                {
                    if (MessageBox.Show(WriteDialogMessage("I-003"), "情報", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) != DialogResult.OK)
                    {
                        MessageBox.Show(WriteDialogMessage("E-002"), "結果", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "";
                    }
                    using (var OpenFolderDialog = new OpenFileDialog()
                    {
                        Title = "フォルダ選択ダイアログ",
                        FileName = "SongFolder",
                        Filter = "Folder|.",
                        InitialDirectory = Directory.GetCurrentDirectory(),
                        CheckFileExists = false
                    })
                    {
                        if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
                        {
                            songsPath = Path.GetDirectoryName(OpenFolderDialog.FileName);
                            if (!File.Exists(configPath))
                            {
                                // 新規ファイル作成
                                File.Create(configPath).Close();
                            }
                            MessageBox.Show(WriteDialogMessage("I-002"), "結果", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            StreamWriter configFile = new StreamWriter(configPath);
                            configFile.WriteLine(Constants.SONGS_DIRECTORY);
                            configFile.WriteLine(songsPath);
                            configFile.Close();
                        }
                        else
                        {
                            MessageBox.Show(WriteDialogMessage("E-002"), "結果", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return "";
                        }
                    }
                }
                else
                {
                    var lines = File.ReadAllLines(configPath);
                    for (global::System.Int32 i = 0; i < lines.Length; i++)
                    {
                        if (lines[i] == Constants.SONGS_DIRECTORY)
                        {
                            songsPath = lines[i + 1];
                        }
                    }
                }
                return songsPath;
            }
            catch (Exception e)
            {
                WriteErrorMessage("LOG-ERROR-EXCEPTION");
                WriteErrorMessage(e.Message + "\n" + e.StackTrace);
                return "";
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
                message = Messages.DialogMessages[messageCode];
            }
            else
            {
                message = messageCode;
            }
            return message;
        }
        /// <summary>
        /// Infoメッセージの書き込み処理
        /// </summary>
        /// <param name="messageCode">メッセージコード、またはメッセージ</param>
        internal static void WriteInfoMessage(string messageCode)
        {
            DateTime currentDateTime = DateTime.Now;
            string infoMessagePath = Directory.GetCurrentDirectory() + Constants.INFO_MESSAGE_DIRECTORY + "\\info_" + currentDateTime.ToString("yyyyMMdd") + Constants.LOG_EXTENSION;
            string message;
            if (Messages.LogMessages.ContainsKey(messageCode))
            {
                message = Messages.LogMessages[messageCode];
            }
            else
            {
                message = messageCode;
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.INFO_MESSAGE_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.INFO_MESSAGE_DIRECTORY);
            }
            if (!File.Exists(infoMessagePath))
            {
                // 新規ファイル作成
                File.Create(infoMessagePath).Close();
            }
            using (StreamWriter writer = new StreamWriter(infoMessagePath, true, Encoding.GetEncoding("utf-8")))
            {
                writer.WriteLine(currentDateTime.ToString("[HH:mm:ss.fff]") + " " + message);
            }
        }
        /// <summary>
        /// Errorメッセージの書き込み処理
        /// </summary>
        /// <param name="messageCode">メッセージコード、またはメッセージ</param>
        internal static void WriteWarningMessage(string messageCode)
        {
            DateTime currentDateTime = DateTime.Now;
            string errorMessagePath = Directory.GetCurrentDirectory() + Constants.WARNING_MESSAGE_DIRECTORY + "\\error_" + currentDateTime.ToString("yyyyMMdd") + Constants.LOG_EXTENSION;
            string message;
            if (Messages.LogMessages.ContainsKey(messageCode))
            {
                message = Messages.LogMessages[messageCode];
            }
            else
            {
                message = messageCode;
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.WARNING_MESSAGE_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.WARNING_MESSAGE_DIRECTORY);
            }
            if (!File.Exists(errorMessagePath))
            {
                // 新規ファイル作成
                File.Create(errorMessagePath).Close();
            }
            using (StreamWriter writer = new StreamWriter(errorMessagePath, true, Encoding.GetEncoding("utf-8")))
            {
                writer.WriteLine(currentDateTime.ToString("[HH:mm:ss.fff]") + " " + message);
            }
        }
        /// <summary>
        /// Errorメッセージの書き込み処理
        /// </summary>
        /// <param name="messageCode">メッセージコード、またはメッセージ</param>
        internal static void WriteErrorMessage(string messageCode)
        {
            DateTime currentDateTime = DateTime.Now;
            string errorMessagePath = Directory.GetCurrentDirectory() + Constants.ERROR_MESSAGE_DIRECTORY + "\\error_" + currentDateTime.ToString("yyyyMMdd") + Constants.LOG_EXTENSION;
            string message;
            if (Messages.LogMessages.ContainsKey(messageCode))
            {
                message = Messages.LogMessages[messageCode];
            }
            else
            {
                message = messageCode;
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + Constants.ERROR_MESSAGE_DIRECTORY))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + Constants.ERROR_MESSAGE_DIRECTORY);
            }
            if (!File.Exists(errorMessagePath))
            {
                // 新規ファイル作成
                File.Create(errorMessagePath).Close();
            }
            using (StreamWriter writer = new StreamWriter(errorMessagePath, true, Encoding.GetEncoding("utf-8")))
            {
                writer.WriteLine(currentDateTime.ToString("[HH:mm:ss.fff]") + " " + message);
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
                arr[2] = arr[2][..3];
                returnTiming = Convert.ToInt32(arr[2]) +
                               Convert.ToInt32(arr[1]) * 1000 +
                               Convert.ToInt32(arr[0]) * 60000;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
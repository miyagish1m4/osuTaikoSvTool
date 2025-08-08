namespace osuTaikoSvTool.Properties
{
    internal class Constants
    {
        // ヒットオブジェクトの種類
        internal enum NoteType
        {
            BARLINE,
            CIRCLE,
            SLIDER,
            SPINNER
        }
        // バックアップディレクトリ
        internal const string BACKUP_DIRECTORY = "\\BackUp";
        // 作業ディレクトリ
        internal const string WORK_DIRECTORY = "\\Work";
        // Infoログディレクトリ
        internal const string LOG_DIRECTORY = "\\Log";
        // Infoログディレクトリ
        internal const string INFO_LOG_DIRECTORY = "\\Log\\Info";
        // Warningログディレクトリ
        internal const string WARNING_LOG_DIRECTORY = "\\Log\\Warning";
        // Errorログディレクトリ
        internal const string ERROR_LOG_DIRECTORY = "\\Log\\Error";
        // 履歴ディレクトリ
        internal const string HISTORY_DIRECTORY = "\\History";
        // osuファイル拡張子
        internal const string OSU_EXTENSION = ".osu";
        // ログファイル拡張子
        internal const string LOG_EXTENSION = ".log";
        // xmlファイル拡張子
        internal const string XML_EXTENSION = ".xml";
        // コンフィグファイル名
        internal const string CONFIG_FILE_NAME = "config.cfg";
        #region コンフィグファイルのセクション
        internal const string SONGS_DIRECTORY = "[SongsDirectory]";
        #endregion
        #region 計算コード
        internal const int CALCULATION_ARITHMETIC = 1; // 等差
        internal const int CALCULATION_GEOMETRIC = 2; // 等比
        #endregion
        #region 実行コード
        internal const int EXCECUTE_ADD = 0;
        internal const int EXCECUTE_MODIFY = 1;
        internal const int EXCECUTE_REMOVE = 2;
        #endregion
        #region ログレベル
        internal const string LOG_LEVEL_INFO = "INFO";
        internal const string LOG_LEVEL_WARNING = "WARNING";
        internal const string LOG_LEVEL_ERROR = "ERROR";
        #endregion
        #region osuファイルのセクション
        internal const string GENERAL = "[General]";
        internal const string EDITOR = "[Editor]";
        internal const string METADATA = "[Metadata]";
        internal const string DIFFICULTY = "[Difficulty]";
        internal const string EVENTS = "[Events]";
        internal const string TIMING_POINTS = "[TimingPoints]";
        internal const string COLOURS = "[Colours]";
        internal const string HIT_OBJECTS = "[HitObjects]";
        internal const int VERSION_CODE = 0;
        internal const int GENERAL_CODE = 1;
        internal const int EDITOR_CODE = 2;
        internal const int METADATA_CODE = 3;
        internal const int DIFFICULTY_CODE = 4;
        internal const int EVENTS_CODE = 5;
        internal const int TIMING_POINTS_CODE = 6;
        internal const int COLOURS_CODE = 7;
        internal const int HIT_OBJECTS_CODE = 8;
        #endregion
    }
}

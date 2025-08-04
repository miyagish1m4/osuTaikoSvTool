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
        internal const string INFO_MESSAGE_DIRECTORY = "\\Log\\Info";
        // Errorログディレクトリ
        internal const string ERROR_MESSAGE_DIRECTORY = "\\Log\\Error";
        // 履歴ディレクトリ
        internal const string HISTORY_DIRECTORY = "\\History";
        // Beatmapファイル拡張子
        internal const string BEATMAP_EXTENSION = ".osu";
        // ログファイル拡張子
        internal const string LOG_EXTENSION = ".log";                   
    }
}

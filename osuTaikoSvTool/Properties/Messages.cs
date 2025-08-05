namespace osuTaikoSvTool.Properties
{
    class Messages
    {
        // ToDO 必要なメッセージを洗い出す miyagi
        // ダイアログメッセージ
        public static Dictionary<string, string> DialogMessages = new()
        {
            { "I-001", "処理に成功しました。\nCtrl+Lを押して譜面を更新してください。" },
            { "E-001", "処理に失敗しました。" }
        };
        // ログメッセージ
        public static Dictionary<string, string> LogMessages = new()
        {
            { "LOG-INFO-START", "アプリケーションを開始します。" },
            { "LOG-INFO-END", "アプリケーションを終了します。" },
            { "LOG-WARNING-BG-FAIL", "BGの取得に失敗しました。" },
            { "LOG-ERROR-EXCEPTION", "例外エラーが発生しました。" },
            { "LOG-ERROR-CREATE-FAIL", "譜面の作成に失敗しました。"}
        };
    }
}

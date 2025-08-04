namespace osuTaikoSvTool.Properties
{
    class Messages
    {
        // ToDO 必要なメッセージを洗い出す miyagi
        // ダイアログメッセージ
        public static Dictionary<string, string> DialogMessages = new Dictionary<string, string>()
        {
            { "I-A-001", "処理に成功しました。" },
            { "E-A-001", "処理に失敗しました。" }
        };
        // ログメッセージ
        public static Dictionary<string, string> LogMessages = new Dictionary<string, string>()
        {
            { "LOG-START", "アプリケーションを開始します。" },
            { "LOG-END", "アプリケーションを終了します。" },
            { "LOG-BG-FAIL", "BGの取得に失敗しました。" },
            { "LOG-EXCEPTION", "例外エラーが発生しました。" }
        };
    }
}

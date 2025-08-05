namespace osuTaikoSvTool.Properties
{
    class Messages
    {
        // ToDO 必要なメッセージを洗い出す miyagi
        // ダイアログメッセージ
        public static Dictionary<string, string> DialogMessages = new()
        {
            { "I-001", "処理に成功しました。\nCtrl+Lを押して譜面を更新してください。" },
            { "I-002", "Songsフォルダの設定が完了しました。" },
            { "I-003", "Songsフォルダを指定してください。" },
            { "W-001", "osuファイルを指定してください。" },
            { "E-001", "処理に失敗しました。" },
            { "E-002", "Songsフォルダの設定が失敗しました。\n再起動をし、再度設定してください。" },
            { "E-003", "譜面情報の取得に失敗しました。" },
            { "E-004", "譜面を指定してください。" },
            { "E-005", "Timingの値を指定してください。" },
            { "E-006", "Timingは「mm:ss:fff」の形式で入力してください" },
            { "E-007", "Timingの始点が終点の値を上回っています。" },
            { "E-008", "SVの値を指定してください。" },
            { "E-009", "SVの値は正の数(0除く)を指定してください。" },
            { "E-010", "Volumeの値を指定してください。" },
            { "E-011", "Volumeの値は正の整数(0除く)を指定してください。" },
            { "E-012", "オフセットの値は整数を指定してください。" },
            { "E-013", "ビートスナップ間隔を指定してください。" },
            { "E-014", "ビートスナップ間隔は正の整数を指定してください。" },
            { "E-015", "対象となるノーツを選択してください。" },
            { "E-016", "グラデーションの型を指定してください。" }
        };
        // ログメッセージ
        public static Dictionary<string, string> LogMessages = new()
        {
            { "LOG-INFO-START", "アプリケーションを開始します。" },
            { "LOG-INFO-END", "アプリケーションを終了します。" },
            { "LOG-INFO-DIRECTORY-SUCCESS", "Songsフォルダの設定に成功しました。" },
            { "LOG-WARNING-BG-FAIL", "BGの取得に失敗しました。" },
            { "LOG-ERROR-EXCEPTION", "例外エラーが発生しました。" },
            { "LOG-ERROR-EXPORT-FAIL", "譜面の作成に失敗しました。" },
            { "LOG-ERROR-DIRECTORY-FAIL", "Songsフォルダの設定に失敗しました。" }
        };
    }
}

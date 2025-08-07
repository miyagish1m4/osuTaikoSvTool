namespace osuTaikoSvTool.Properties
{
    class Messages
    {
        // ToDO 必要なメッセージを洗い出す miyagi
        // ダイアログメッセージ
        public static Dictionary<string, string> DialogMessages = new()
        {
            { "I_A-P-001", "処理に成功しました。\nCtrl+Lを押して譜面を更新してください。" },
            { "I_A-P-002", "Songsフォルダの設定が完了しました。" },
            { "I_A-EM-001", "Songsフォルダを指定してください。" },
            { "W_A_EM-001", "履歴が存在しません。" },
            { "W_A-EXT-001", "osuファイルを指定してください。" },
            { "E_A-P-001", "処理に失敗しました。" },
            { "E_A-P-002", "Songsフォルダの設定が失敗しました。\n再起動をし、再度設定してください。" },
            { "E_A-D-001", "譜面情報の取得に失敗しました。" },
            { "E_V-EM-001", "譜面を指定してください。" },
            { "E_V-EM-002", "Timingの値を指定してください。" },
            { "E_V-EM-003", "SVの値を指定してください。" },
            { "E_V-EM-004", "Volumeの値を指定してください。" },
            { "E_V-EM-005", "ビートスナップ間隔を指定してください。" },
            { "E_V-EM-006", "対象となるヒットオブジェクトを選択してください。" },
            { "E_V-EM-007", "計算方法(等差,等比 等)を指定してください。" },
            { "E_V-C-001", "Timingは「mm:ss:fff」の形式で入力してください" },
            { "E_V-C-002", "Timingの始点が終点の値を上回っています。" },
            { "E_V-T-001", "SVの値は正の数(0除く)を指定してください。" },
            { "E_V-T-002", "Volumeの値は正の整数(0除く)を指定してください。" },
            { "E_V-T-003", "オフセットの値は整数を指定してください。" },
            { "E_V-T-004", "ビートスナップ間隔は正の整数(0除く)を指定してください。" }
        };
        // ログメッセージ
        public static Dictionary<string, string> LogMessages = new()
        {
            { "LOG_E-DESERIALIZE-XML", "xmlファイルのデシリアライズに失敗しました。" },
            { "LOG_E-EXPORT-OSU", "osuへエクスポートに失敗しました。" },
            { "LOG_E-DIRECTORY-SONGS", "Songsフォルダの設定に失敗しました。" },
            { "LOG_E-GET-BEATMAP", "譜面情報の取得に失敗しました。" },
            { "LOG_E-GET-INPUT", "入力情報の取得に失敗しました。" },
            { "LOG_E-GET-HISTORY", "編集履歴の取得に失敗しました。" },
            { "LOG_E-ADD-LINES", "緑線の追加に失敗しました。" },
            { "LOG_E-REMOVE-LINES", "緑線の削除に失敗しました。" },
            { "LOG_E-MODIFY-LINES", "緑線の変更に失敗しました。" },
            { "LOG_E-CALCULATE-LINES", "緑線の算出に失敗しました。" },
            { "LOG_E-CREATE-BACKUP", "バックアップの作成に失敗しました。" },
            { "LOG_E-EXCEPTION", "例外エラーが発生しました。" },
            { "LOG_W-GET-BG", "BGの取得に失敗しました。" },
            { "LOG_I-START", "アプリケーションを開始します。" },
            { "LOG_I-END", "アプリケーションを終了します。" },
            { "LOG_I-ADD-LINES", "緑線の追加に成功しました。" },
            { "LOG_I-REMOVE-LINES", "緑線の削除に成功しました。" },
            { "LOG_I-MODIFY-LINES", "緑線の変更に成功しました。" },
            { "LOG_", "" }
        };
    }
}

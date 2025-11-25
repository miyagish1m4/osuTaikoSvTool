namespace osuTaikoSvTool.Models
{
    /// <summary>
    /// 選曲中の譜面から取得したメタデータ
    /// </summary>
    internal class BeatmapMetadata
    {
        // タイトル
        internal string title { set; get; }
        // アーティスト
        internal string artist { set; get; }
        // マッパー名
        internal string creator { set; get; }
        // Diff名
        internal string version { set; get; }
        // BGのパス
        internal string backgroundPath { set; get; }
        // 譜面のパス
        internal string beatmapPath { set; get; }
        /// <summary>
        /// コンストラクタ
        /// クラス変数に空文字を格納する
        /// </summary>
        public BeatmapMetadata()
        {
            this.title = string.Empty;
            this.artist = string.Empty;
            this.creator = string.Empty;
            this.version = string.Empty;
            this.backgroundPath = string.Empty;
            this.beatmapPath = string.Empty;
        }
    }
}

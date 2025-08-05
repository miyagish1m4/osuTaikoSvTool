namespace osuTaikoSvTool.Models
{
    class Beatmap
    {
        // ファイルパス
        public string path { set; get; }
        // バージョン
        public string version { set; get; }
        // General
        public List<string> general { set; get; }
        // Editor
        public List<string> editor { set; get; }
        // Metadata
        public List<string> metadata { set; get; }
        // Difficulty
        public List<string> difficulty { set; get; }
        // イベント
        public List<string> events { set; get; }
        // Colours
        public List<string> colours { set; get; }
        // タイミングポイント
        public List<TimingPoint> timingPoints { set; get; }
        // ヒットオブジェクト
        public List<HitObject> hitObjects { set; get; }
        // ブックマーク
        public List<int> bookmarks { set; get; }
        public Beatmap(string path,
                       string version,
                       List<string> general,
                       List<string> editor,
                       List<string> metadata,
                       List<string> difficulty,
                       List<string> events,
                       List<TimingPoint> timingPoints,
                       List<string> colours,
                       List<HitObject> hitObject,
                       List<int> bookmarks)
        {
            this.path = path;
            this.version = version;
            this.general = general;
            this.editor = editor;
            this.metadata = metadata;
            this.difficulty = difficulty;
            this.events = events;
            this.timingPoints = timingPoints;
            this.colours = colours;
            this.hitObjects = hitObject;
            this.bookmarks = bookmarks;
        }

    }
}

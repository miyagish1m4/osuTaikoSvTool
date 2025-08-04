namespace osuTaikoSvTool.Models
{
    class Beatmap
    {
        public string version { set; get; }
        public List<string> general { set; get; }
        public List<string> editor { set; get; }
        public List<string> metadata { set; get; }
        public List<string> difficulty { set; get; }
        public List<string> events { set; get; }
        public List<string> colours { set; get; }
        // タイミングポイント
        public List<TimingPoint> timingPoints { set; get; }
        // ヒットオブジェクト
        public List<HitObject> hitObjects { set; get; }
        // ブックマーク
        public List<int> bookmarks { set; get; }
        public Beatmap(string version,
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

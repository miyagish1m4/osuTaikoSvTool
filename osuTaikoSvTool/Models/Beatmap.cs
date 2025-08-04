namespace osuTaikoSvTool.Models
{
    class Beatmap
    {
        // タイミングポイント
        public List<TimingPoint> timingPoints { set; get; }
        // ヒットオブジェクト
        public List<HitObject> hitObjects { set; get; }
        // ブックマーク
        public List<int> bookmarks { set; get; }   
        public Beatmap(List<TimingPoint> timingPoints, List<HitObject> hitObject, List<int> bookmarks)
        {
            this.timingPoints = timingPoints;
            this.hitObjects = hitObject;
            this.bookmarks = bookmarks;
        }

    }
}

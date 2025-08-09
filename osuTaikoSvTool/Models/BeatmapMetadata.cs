namespace osuTaikoSvTool.Models
{
    class BeatmapMetadata
    {
        internal string title { set; get; }
        internal string artist { set; get; }
        internal string creator { set; get; }
        internal string version { set; get; }
        internal string backgroundPath { set; get; }
        internal string beatmapPath { set; get; }
        internal BeatmapMetadata()
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

namespace osuTaikoSvTool.Models
{
    class UserInputData

    {
        #region 必須入力値
        // タイミング(開始位置)
        public int timingFrom { set; get; }
        // タイミング(終了位置)
        public int timingTo { set; get; }
        #endregion
        #region 任意入力値
        // SV(開始)
        public decimal svFrom { set; get; }
        // SV(終了)
        public decimal svTo { set; get; }
        // SV有効化設定
        public bool isSv { set; get; }
        // 音量(開始)
        public int volumeFrom { set; get; }
        // 音量(終了)
        public int volumeTo { set; get; }
        // 音量有効化設定
        public bool isVolume { set; get; }
        // オフセット値
        public int offset { set; get; }
        // オフセット有効化設定
        public bool isOffset { set; get; }
        // kiai有効化設定
        public bool isKiai { set; get; }
        // kiai開始有効化設定
        public bool isKiaiStart { set; get; }
        // kiai終了有効化設定
        public bool isKiaiEnd { set; get; }
        #endregion

        internal UserInputData(int timingFrom,
                               int timingTo,
                               decimal svFrom,
                               decimal svTo,
                               int volumeFrom,
                               int volumeTo,
                               bool isSv,
                               bool isVolume,
                               int offset,
                               bool isOffset,
                               bool isKiai,
                               bool isKiaiStart,
                               bool isKiaiEnd)
        {
            this.timingFrom = timingFrom;
            this.timingTo = timingTo;
            this.svFrom = svFrom;
            this.svTo = svTo;
            this.volumeFrom = volumeFrom;
            this.volumeTo = volumeTo;
            this.isSv = isSv;
            this.isVolume = isVolume;
            this.offset = offset;
            this.isOffset = isOffset;
            this.isKiai = isKiai;
            this.isKiaiStart = isKiaiStart;
            this.isKiaiEnd = isKiaiEnd;
        }
    }
}

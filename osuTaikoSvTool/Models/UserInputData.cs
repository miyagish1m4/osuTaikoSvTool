using static osuTaikoSvTool.Models.UserInputData;

namespace osuTaikoSvTool.Models
{
    class UserInputData

    {
        #region 必須入力値
        // タイミング(開始位置)
        public int timingFrom { set; get; }
        // タイミング(終了位置)
        public int timingTo { set; get; }
        // 
        public int calculationCode { set; get; }
        #endregion
        #region 任意入力値
        // SV有効化設定
        public bool isSv { set; get; }
        // SV(開始)
        public decimal svFrom { set; get; }
        // SV(終了)
        public decimal svTo { set; get; }
        // 音量有効化設定
        public bool isVolume { set; get; }
        // 音量(開始)
        public int volumeFrom { set; get; }
        // 音量(終了)
        public int volumeTo { set; get; }
        // 小節線有効化設定
        public bool isIncludeBarline { set; get; }
        // オフセット有効化設定
        public bool isOffset { set; get; }
        // オフセット値
        public int offset { set; get; }
        // ビートスナップ間隔配置設定
        public bool isBeatSnap { set; get; }
        // ビートスナップ間隔
        public int beatSnap { set; get; }
        // kiai有効化設定
        public bool isKiai { set; get; }
        // kiai開始有効化設定
        public bool isKiaiStart { set; get; }
        // kiai終了有効化設定
        public bool isKiaiEnd { set; get; }
        // 小節線のみ有効化設定
        public bool isOnlyBarline { set; get; }
        // Bookmarkのみ有効化設定
        public bool isOnlyBookmark { set; get; }
        // HitObjectsのみ有効化設定
        public bool isOnlyHitObjects { set; get; }
        // 
        public HitObjectType hitObjectType = new(false, false, false, false, false, false);
        internal struct HitObjectType
        {
            public bool isDong { set; get; }
            public bool isFinisherDong { set; get; }
            public bool isKa { set; get; }
            public bool isFinisherKa { set; get; }
            public bool isSlider { set; get; }
            public bool isFinisherSlider { set; get; }
            internal HitObjectType(bool isDong,
                                   bool isFinisherDong,
                                   bool isKa,
                                   bool isFinisherKa,
                                   bool isSlider,
                                   bool isSliderFinisher)
            {
                this.isDong = isDong;
                this.isFinisherDong = isFinisherDong;
                this.isKa = isKa;
                this.isFinisherKa = isFinisherKa;
                this.isSlider = isSlider;
                this.isFinisherSlider = isSliderFinisher;
            }
        }

        #endregion

        internal UserInputData(int timingFrom,
                               int timingTo,
                               bool isSv,
                               decimal svFrom,
                               decimal svTo,
                               bool isVolume,
                               int volumeFrom,
                               int volumeTo,
                               int calculationCode,
                               bool isIncludeBarline,
                               bool isOffset,
                               int offset,
                               bool isBeatSnap,
                               int beatSnap,
                               bool isKiai,
                               bool isKiaiStart,
                               bool isKiaiEnd,
                               bool isOnlyBarline,
                               bool isOnlyBookmark,
                               bool isOnlyHitObject,
                               int OnlyHitObjectCode)
        {
            this.timingFrom = timingFrom;
            this.timingTo = timingTo;
            this.isSv = isSv;
            this.svFrom = svFrom;
            this.svTo = svTo;
            this.isVolume = isVolume;
            this.volumeFrom = volumeFrom;
            this.volumeTo = volumeTo;
            this.calculationCode = calculationCode;
            this.isIncludeBarline = isIncludeBarline;
            this.isOffset = isOffset;
            this.offset = offset;
            this.isBeatSnap = isBeatSnap;
            this.beatSnap = beatSnap;
            this.isKiai = isKiai;
            this.isKiaiStart = isKiaiStart;
            this.isKiaiEnd = isKiaiEnd;
            this.isOnlyBarline = isOnlyBarline;
            this.isOnlyBookmark = isOnlyBookmark;
            this.isOnlyHitObjects = isOnlyHitObjects;
            ConvertHitObjectType(OnlyHitObjectCode, ref hitObjectType);
        }

        private void ConvertHitObjectType(int OnlyHitObject, ref HitObjectType hitObjectType)
        {
            try
            {
                if (OnlyHitObject >= 64)
                {
                    throw new Exception();
                }
                else
                {
                    if ((OnlyHitObject & 0b00000001) != 0)
                    {
                        hitObjectType.isDong = true;
                    }
                    if ((OnlyHitObject & 0b00000010) != 0)
                    {
                        hitObjectType.isFinisherDong = true;
                    }
                    if ((OnlyHitObject & 0b00000100) != 0)
                    {
                        hitObjectType.isKa = true;
                    }
                    if ((OnlyHitObject & 0b00001000) != 0)
                    {
                        hitObjectType.isFinisherKa = true;
                    }
                    if ((OnlyHitObject & 0b00010000) != 0)
                    {
                        hitObjectType.isSlider = true;
                    }
                    if ((OnlyHitObject & 0b00100000) != 0)
                    {
                        hitObjectType.isFinisherSlider = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"エラー: {ex.Message}");
            }
        }
    }
}

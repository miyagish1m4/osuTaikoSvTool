namespace osuTaikoSvTool.Models
{
    /// <summary>
    /// ユーザーがフォーム上で入力したデータをまとめたクラス
    /// </summary>
    [Serializable]
    public class UserInputData

    {
        #region 必須入力値
        // タイミング(開始位置)
        internal int timingFrom { set; get; }
        // タイミング(終了位置)
        internal int timingTo { set; get; }
        // 
        internal int calculationCode { set; get; }
        #endregion
        #region 任意入力値
        // SV有効化設定
        internal bool isSv { set; get; }
        // SV(開始)
        internal decimal svFrom { set; get; }
        // SV(終了)
        internal decimal svTo { set; get; }
        // 音量有効化設定
        internal bool isVolume { set; get; }
        // 音量(開始)
        internal int volumeFrom { set; get; }
        // 音量(終了)
        internal int volumeTo { set; get; }
        // オフセット有効化設定
        internal bool isOffset { set; get; }
        // オフセット値
        internal int offset { set; get; }
        // kiai有効化設定
        internal bool isKiai { set; get; }
        // 相対速度オプション
        // -1 : 無効
        // 0  : 乗算
        // 1  : 加算
        internal int relativeCode { set; get; }
        // 相対速度オプションで"乗算"選択時の基礎SV
        internal decimal relativeBaseSv { set; get; }
        internal SetOption setOption = new();
        internal SetObjectOption setObjectOption = new();
        internal SetBeatSnapOption setBeatSnapOption = new();
        //作成日時
        internal DateTime createDate { set; get; }
        // 更新日時
        // internal DateTime updateDate { set; get; }
        // 対象オブジェクト設定
        internal struct SetOption
        {
            // オブジェクト配置設定
            internal bool isSetObjects { set; get; }
            // ビートスナップ間隔配置設定
            internal bool isSetBeatSnap { set; get; }
        }
        internal struct SetObjectOption
        {
            // 設定対象オブジェクトコード
            // 0b00000000 00000000 00000000 00000001 面
            // 0b00000000 00000000 00000000 00000010 面(大音符)
            // 0b00000000 00000000 00000000 00000100 縁
            // 0b00000000 00000000 00000000 00001000 縁(大音符)
            // 0b00000000 00000000 00000000 00010000 スライダー
            // 0b00000000 00000000 00000000 00100000 スライダー(大音符)
            // 0b00000000 00000000 00000000 01000000 スピナー
            // 0b00000000 00000000 00000000 10000000 小節線以外
            // 0b00000000 00000000 00000001 00000000 小節線
            // 0b00000000 00000000 00000010 00000000 Bookmark以外
            // 0b00000000 00000000 00000100 00000000 Bookmark
            internal int setObjectsCode { set; get; }
            // kiai開始有効化設定
            internal bool isKiaiStart { set; get; }
            // kiai終了有効化設定
            internal bool isKiaiEnd { set; get; }
            // 始点緑線有効化設定
            internal bool isTimingStart { set; get; }
            // 終点緑線有効化設定
            internal bool isTimingEnd { set; get; }

        }
        internal struct SetBeatSnapOption
        {
            internal bool isBeatSnap { set; get; }
            // ビートスナップ間隔
            internal int beatSnap { set; get; }
        }
        #endregion
        /// <summary>
        /// コンストラクタ
        /// シリアライズ時に使用する
        /// </summary>
        public UserInputData()
        {
        }
        /// <summary>
        /// コンストラクタ
        /// 入力値をクラス変数に格納する
        /// </summary>
        /// <param name="timingFrom">timing(始点)</param>
        /// <param name="timingTo">timing(終点)</param>
        /// <param name="isSv">SV有効化フラグ</param>
        /// <param name="svFrom">SV(始点)</param>
        /// <param name="svTo">SV(終点)</param>
        /// <param name="isVolume">Volume有効化フラグ</param>
        /// <param name="volumeFrom">Volume(始点)</param>
        /// <param name="volumeTo">Volume(終点)</param>
        /// <param name="calculationCode">計算コード</param>
        /// <param name="isKiai">kiai有効化フラグ</param>
        /// <param name="relativeCode">相対速度変化コード</param>
        /// <param name="relativeBaseSv">相対速度変化基準SV</param>
        /// <param name="isOffset">オフセット有効化フラグ</param>
        /// <param name="offset">オフセット</param>
        /// <param name="isSetObject">オブジェクト配置有効化フラグ</param>
        /// <param name="isSetBeatSnap">ビートスナップ間隔配置有効化フラグ</param>
        /// <param name="setObjectCode">オブジェクトコード</param>
        /// <param name="isKiaiStart">kiai始点有効化フラグ</param>
        /// <param name="isKiaiEnd">kiai終点有効化フラグ</param>
        /// <param name="isBeatSnap">ビートスナップ間隔有効化フラグ</param>
        /// <param name="beatSnap">ビートスナップ間隔</param>
        /// <param name="date">作成日時</param>
        public UserInputData(int timingFrom,
                               int timingTo,
                               bool isSv,
                               decimal svFrom,
                               decimal svTo,
                               bool isVolume,
                               int volumeFrom,
                               int volumeTo,
                               int calculationCode,
                               bool isKiai,
                               int relativeCode,
                               decimal relativeBaseSv,
                               bool isOffset,
                               int offset,
                               bool isSetObject,
                               bool isSetBeatSnap,
                               int setObjectCode,
                               bool isKiaiStart,
                               bool isKiaiEnd,
                               bool isTimingStart,
                               bool isTimingEnd,
                               bool isBeatSnap,
                               int beatSnap,
                               DateTime date)
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
            this.isKiai = isKiai;
            this.relativeCode = relativeCode;
            this.relativeBaseSv = relativeBaseSv;
            this.isOffset = isOffset;
            this.offset = offset;
            this.setOption.isSetObjects = isSetObject;
            this.setOption.isSetBeatSnap = isSetBeatSnap;
            this.setObjectOption.setObjectsCode = setObjectCode;
            this.setObjectOption.isKiaiStart = isKiaiStart;
            this.setObjectOption.isKiaiEnd = isKiaiEnd;
            this.setObjectOption.isTimingStart = isTimingStart;
            this.setObjectOption.isTimingEnd = isTimingEnd;
            this.setBeatSnapOption.beatSnap = beatSnap;
            this.setBeatSnapOption.isBeatSnap = isBeatSnap;
            this.createDate = date;
        }
    }
}

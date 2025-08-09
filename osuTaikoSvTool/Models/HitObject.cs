using osuTaikoSvTool.Properties;

namespace osuTaikoSvTool.Models
{
    class HitObject
    {
        // BPM
        public decimal bpm { set; get; }
        // SV
        public decimal sv { set; get; }
        // SVが掛かるタイミング
        public int svApplyTime { set; get; }
        // ヒットオブジェクトの種類
        public Constants.NoteType noteType;
        // ノーツの種類
        public NoteHitSound noteHitSound;
        internal struct NoteHitSound
        {
            public bool isNormal { set; get; }
            public bool isWhistle { set; get; }
            public bool isFinish { set; get; }
            public bool isClap { set; get; }
        }
        // NewComboの判定
        public bool isNewCombo { set; get; }
        // 小節線の判定
        public bool isOnBarline { set; get; }

        #region 全ヒットオブジェクト共通変数
        // ヒットオブジェクトのx座標
        public int positionX { set; get; }
        // ヒットオブジェクトのy座標
        public int positionY { set; get; }
        // タイミング(ミリ秒)
        public int time { set; get; }
        // ヒットオブジェクトの種類(.osuファイルのフォーマット)
        public string type { set; get; }
        // ノーツの種類(.osuファイルのフォーマット)
        public string hitSound { set; get; }
        // ヒットサンプルの種類
        public string? hitSample { set; get; } = null;
        #endregion
        #region slider専用変数
        // sliderのカーブ設定を表す文字列
        public string? curveSetting { set; get; } = null;
        // sliderの折り返し回数
        public decimal slides { set; get; }
        // sliderの長さ
        public decimal sliderLength { set; get; }
        // sliderの折り返し時のヒットサウンドの種類
        public string? edgeSounds { set; get; } = null;
        // sliderの折り返し時のヒットサンプルの種類
        public string? edgeSets { set; get; } = null;
        #endregion
        #region spinner専用変数
        // spinnerの終了時間
        public int endTime { set; get; }
        #endregion
        internal HitObject(string line)
        {
            string[] buff = line.Split(",");

            positionX = int.Parse(buff[0]);
            positionY = int.Parse(buff[1]);
            time = int.Parse(buff[2]);
            type = buff[3];
            hitSound = buff[4];
            if ((int.Parse(buff[3]) & 0b00000001) != 0)
            {
                // ノーツの場合
                noteType = Constants.NoteType.CIRCLE;
                hitSample = buff[5];
            }
            else if ((int.Parse(buff[3]) & 0b00000010) != 0)
            {
                // スライダーの場合
                noteType = Constants.NoteType.SLIDER;
                curveSetting = buff[5];
                slides = decimal.Parse(buff[6]);
                sliderLength = decimal.Parse(buff[7]);
                if (buff.Length > 8)
                {
                    edgeSounds = buff[8];
                    edgeSets = buff[9];
                    hitSample = buff[10];
                }
            }
            else if ((int.Parse(buff[3]) & 0b00001000) != 0)
            {
                // スピナーの場合
                noteType = Constants.NoteType.SPINNER;
                endTime = int.Parse(buff[5]);
                hitSample = buff[6];
            }
            if ((int.Parse(buff[3]) & 0b00000100) != 0)
            {
                isNewCombo = true;
            }
            isOnBarline = false;
            SetNoteHitSound(buff);
        }
        internal HitObject(int time)
        {
            // 小節線の場合
            this.time = time;
            this.svApplyTime = time;
            noteType = Constants.NoteType.BARLINE;
            positionX = 0;   // 未使用
            positionY = 0;   // 未使用
            hitSound = "0";  // 未使用
            type = "0";      // 未使用
            isNewCombo = false;
            isOnBarline = true;
        }
        /// <summary>
        /// ヒットサウンドの種類を設定する
        /// </summary>
        /// <param name="buff"></param>
        private void SetNoteHitSound(string[] buff)
        {

            if ((int.Parse(buff[4]) & 0b0010) != 0)
            {
                noteHitSound.isWhistle = true;
            }
            if ((int.Parse(buff[4]) & 0b1000) != 0)
            {
                noteHitSound.isClap = true;
            }
            if ((int.Parse(buff[4]) & 0b0100) != 0)
            {
                noteHitSound.isFinish = true;
            }
            if ((int.Parse(buff[4]) & 0b1011) == 0)
            {
                noteHitSound.isNormal = true;
            }
        }

    }
}

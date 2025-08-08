namespace osuTaikoSvTool.Models
{
    class TimingPoint
    {
        // タイミングポイント
        public int time { set; get; }
        // BPM
        public decimal bpm { set; get; }
        // SV
        public decimal sv { set; get; }
        // 1小節の長さ(ms)
        public decimal barLength { set; get; }
        // 拍子
        public int meter { set; get; }
        // サンプルセット(Normal,Soft,Drum 等)
        public int sampleSet { set; get; }
        // サンプルインデックス
        public int sampleIndex { set; get; }
        // 音量
        public int volume { set; get; }
        // タイミングポイントの種類
        public bool isRedLine { set; get; }
        // エフェクト(kiai有無,小節線有無 等)
        public int effect { set; get; }
        internal TimingPoint(int time,
                             decimal bpm,
                             decimal sv,
                             decimal barLength,
                             int meter,
                             int sampleSet,
                             int sampleIndex,
                             int volume,
                             bool isRedLine,
                             int effect)
        {
            this.time = time;
            this.bpm = bpm;
            this.sv = sv;
            this.barLength = barLength;
            this.meter = meter;
            this.sampleSet = sampleSet;
            this.sampleIndex = sampleIndex;
            this.volume = volume;
            this.isRedLine = isRedLine;
            this.effect = effect;
        }

        internal TimingPoint(string line)
        {
            string[] buff = line.Split(",");
            time = int.Parse(buff[0]);          //タイミング
            meter = int.Parse(buff[2]);         //拍子
            sampleSet = int.Parse(buff[3]);     //サンプルセット(Normal,Soft,Drum 等)
            sampleIndex = int.Parse(buff[4]);   //サンプルインデックス?
            volume = int.Parse(buff[5]);        //音量
            effect = int.Parse(buff[7]);        //エフェクト(kiai有無,小節線有無 等)
            //赤線か緑線か判定する
            if (int.Parse(buff[6]) == 1)
            {
                isRedLine = true;
                barLength = decimal.Parse(buff[1]) * meter;
                bpm = 60000 / decimal.Parse(buff[1]);
            }
            else
            {
                isRedLine = false;
                sv = -100 / decimal.Parse(buff[1]);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace osuTaikoSvTool
{
    internal class TimingPoint
    {
        public double time;
        public double bpm;
        public double sv;
        public double barLength; //1小節の長さ(ms)
        public bool isRedLine;
        public int volume;
        public int mater;
        public int effect;
        public int sampleIndex;
        public int sampleSet;
        TimingPoint(string line)
        {
            string[] buff = line.Split(",");
            time = double.Parse(buff[0]);       //タイミング
            mater = int.Parse(buff[2]);         //拍子
            sampleSet = int.Parse(buff[3]);     //サンプルセット(Normal,Soft,Drum 等)
            sampleIndex = int.Parse(buff[4]);   //サンプルインデックス?
            volume = int.Parse(buff[5]);        //音量
            effect = int.Parse(buff[7]);        //エフェクト(kiai有無,小節線有無 等)
            //赤線か緑線か判定する
            if (int.Parse(buff[6]) == 1)
            {
                isRedLine = true;
                barLength = double.Parse(buff[1]) * mater;
                bpm = 60000 / double.Parse(buff[1]);
            } else
            {
                isRedLine = false;
                sv = -100 / double.Parse(buff[1]);
            }

        }
    }
}

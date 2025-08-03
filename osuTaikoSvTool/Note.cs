using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace osuTaikoSvTool
{
    internal class Note
    {
        Note(string line)
        {
            hitSample = null;
            edgeSets = null;
            edgeSounds = null;
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
                if(noteHitSound.isFinish)
                {
                    isBig = true;
                }
                if(noteHitSound.isWhistle || noteHitSound.isClap)
                {
                    isKat = false;
                }
                hitSample = buff[5];
            }
            else if ((int.Parse(buff[3]) & 0b00000010) != 0)
            {
                // スライダーの場合
                noteType = Constants.NoteType.SLIDER;
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
            } else
            {
                // 小節線の場合
                noteType = Constants.NoteType.BARLINE;
            }
            if ((int.Parse(buff[3]) & 0b00010000) != 0)
            {
                isNewCombo = true;
            }
            //行からノーツ情報を取得する
            //TimingPointを参照し、BPM、SVを初期化する
            GetTimingInfoOfNote(this);
        }
        public double BPM;
        public double SV;
        public int time;
        public Constants.NoteType noteType;
        public NoteHitSound noteHitSound;

        public int positionX;
        public int positionY;
        public string type;
        public string hitSound;
        public bool isNewCombo;
        public bool isKat;
        public bool isBig;
        public bool isBarline;
        public string hitSample;

        // sliderの場合に使用される変数
        public string curveSetting;
        public double sliderLength;
        public string edgeSounds;
        public string edgeSets;

        // spinerの場合に使用される変数
        public int endTime;

        void GetTimingInfoOfNote(Note note)
        {
            //note.BPM = //時間がnote.timingPoint以下で最大の赤線情報を取得
            //note.SV = //時間がnote.timingPoint以下で最大の緑線情報を取得(※赤線が最大の場合は1.0x)
        }

    }
    internal struct NoteHitSound
    {
        public bool isNormal;
        public bool isWhistle;
        public bool isFinish;
        public bool isClap;
    }

}

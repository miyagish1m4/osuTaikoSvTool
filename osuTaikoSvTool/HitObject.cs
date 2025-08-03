using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace osuTaikoSvTool
{
    class HitObject
    {
        public decimal bpm;
        public decimal sv;
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
        public string? hitSample;

        // sliderの場合に使用される変数
        public string? curveSetting;
        public decimal slides;
        public decimal sliderLength;
        public string? edgeSounds;
        public string? edgeSets;

        // spinerの場合に使用される変数
        public int endTime;

        internal HitObject(string line)
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
                hitSample = buff[5];
            }
            else if ((int.Parse(buff[3]) & 0b00000010) != 0)
            {
                // スライダーの場合
                noteType = Constants.NoteType.SLIDER;
                // curveSetting = buff[5];
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
            } else
            {
                noteType = Constants.NoteType.BARLINE;
            }
            if ((int.Parse(buff[3]) & 0b00000100) != 0)
            {
                isNewCombo = true;
            }
            isBarline = false;
            SetNoteHitSound(buff);
        }
        internal HitObject(int time)
        {
            // 小節線の場合
            this.time = time;
            noteType = Constants.NoteType.BARLINE;
            positionX = 0;
            positionY = 0;
            hitSound = "0";
            type = "0";
            isNewCombo = false;
            isBarline = true;
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
            if (noteHitSound.isFinish)
            {
                isBig = true;
            }
            if (noteHitSound.isWhistle || noteHitSound.isClap)
            {
                isKat = false;
            }
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

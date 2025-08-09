using osuTaikoSvTool.Models;
using osuTaikoSvTool.Properties;
using osuTaikoSvTool.Utils;

namespace osuTaikoSvTool.Services
{
    internal class SVCalculatorService
    {
        public static bool Add(UserInputData userInputData, Beatmap beatmap, ref List<TimingPoint> outTimingPoints)
        {
            List<TimingPoint> timingPointBuff = new();
            try
            {
                if (userInputData.isAllHitObjects)
                {
                    AddAllHitObjects(userInputData, beatmap, ref outTimingPoints);
                }
                else if (userInputData.isOnlyBookmark)
                {
                    AddAllBookmarks(userInputData, beatmap, ref outTimingPoints);
                }
                else if (userInputData.isOnlyBarline)
                {
                    AddAllBarLines(userInputData, beatmap, ref outTimingPoints);

                }
                else
                {

                }
                outTimingPoints.AddRange(timingPointBuff);
                return true;

            }
            catch (Exception ex)
            {
                Common.WriteWarningMessage("LOG_E-ADD-LINES");
                Common.WriteExceptionMessage(ex);
                return false;
            }

        }
        public static bool Modify(UserInputData userInputData, Beatmap beatmap)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-MODIFY-LINES");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        public static bool Remove(UserInputData userInputData, Beatmap beatmap)
        {
            try
            {
                decimal baseSv = 1m;
                int baseVolume = 100;
                // 削除後の適応されるSVと音量を求める
                for (global::System.Int32 i = (beatmap.timingPoints.Count) - (1); i >= 0; i--)
                {
                    if (beatmap.timingPoints[i].time < userInputData.timingFrom)
                    {
                        baseSv = beatmap.timingPoints[i].sv;
                        baseVolume = beatmap.timingPoints[i].volume;
                        break;
                    }
                }
                // 指定範囲内にスライダーがある場合はsliderLengthを調整する
                for (global::System.Int32 i = 0; i < beatmap.hitObjects.Count; i++)
                {

                    if ((beatmap.hitObjects[i].time >= userInputData.timingFrom) &&
                        (beatmap.hitObjects[i].time <= userInputData.timingTo) &&
                        (beatmap.hitObjects[i].noteType == Constants.NoteType.SLIDER))
                    {
                        for (global::System.Int32 j = (beatmap.timingPoints.Count) - (1); j >= 0; j--)
                        {
                            if ((beatmap.timingPoints[j].time >= userInputData.timingFrom) &&
                                (beatmap.timingPoints[j].time <= beatmap.hitObjects[i].time) &&
                                beatmap.timingPoints[j].isRedLine)
                            {
                                baseSv = 1;
                            }
                        }
                        beatmap.hitObjects[i].sliderLength = beatmap.hitObjects[i].sliderLength *
                                                     (baseSv / beatmap.hitObjects[i].sv);
                    }
                }
                // 指定範囲内の緑線を削除する
                // 指定範囲内に赤線がある場合は適応させる音量を設定する
                for (global::System.Int32 i = (beatmap.timingPoints.Count) - (1); i >= 0; i--)
                {
                    if ((!beatmap.timingPoints[i].isRedLine) &&
                        (beatmap.timingPoints[i].time >= userInputData.timingFrom) &&
                        (beatmap.timingPoints[i].time <= userInputData.timingTo))
                    {
                        beatmap.timingPoints.RemoveAt(i);
                    }
                    //if (beatmap.timingPoints[i].isRedLine)
                    //{
                    //    beatmap.timingPoints[i].volume = baseVolume;
                    //}
                }

                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-REMOVE-LINES");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        private static bool ResetOriginalTimingPoints(Beatmap beatmap,
                                                      UserInputData userInputData,
                                                      int effectCode,
                                                      decimal volumePerMs)
        {
            try
            {
                for (global::System.Int32 i = 0; i < beatmap.timingPoints.Count; i++)
                {
                    // もし赤線がTiming(終点)より上回った場合は処理を抜ける
                    if (beatmap.timingPoints[i].time > userInputData.timingTo)
                    {
                        // のちの処理のためにKiai終点判定フラグが有効な場合はエフェクトコードを1に変更する
                        if (userInputData.isKiaiEnd)
                        {
                            effectCode = 1;
                        }
                        break;
                    }
                    // もし赤線がTiming(終点)と同じタイミングかつ、
                    // Kiai終点判定フラグが有効な場合はエフェクトコードを0に変更する(kiaiを無効にする)
                    if ((beatmap.timingPoints[i].time == userInputData.timingTo) && userInputData.isKiaiEnd)
                    {
                        effectCode = 0;
                    }
                    if ((beatmap.timingPoints[i].time >= userInputData.timingFrom) &&
                        (beatmap.timingPoints[i].time <= userInputData.timingTo))
                    {
                        if (userInputData.isVolume)
                        {
                            // 指定範囲内に赤線があるかつ、Volume有効化フラグが有効な場合は
                            // 赤線に音量を計算し適応する
                            beatmap.timingPoints[i].volume = (int)(userInputData.volumeFrom +
                                                               (volumePerMs *
                                                                (beatmap.timingPoints[i].time -
                                                                 userInputData.timingFrom)));
                        }
                        // kiaiをつける場合はkiai有効化する
                        beatmap.timingPoints[i].effect += effectCode;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// すべてのノーツのタイミングに緑線を設置する
        /// </summary>
        /// <param name="userInputData">入力値</param>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="outTimingPoints">追加したタイミングポイントの出力先</param>
        /// <returns></returns>
        private static bool AddAllHitObjects(UserInputData userInputData, Beatmap beatmap, ref List<TimingPoint> outTimingPoints)
        {
            decimal baseBpm = 0;
            try
            {
                // 1msあたりのSV,Volumeを計算
                decimal svPerMs = userInputData.isSv ? GetSvPerMs(userInputData.svFrom,
                                                                  userInputData.svTo,
                                                                  userInputData.timingFrom,
                                                                  userInputData.timingTo,
                                                                  userInputData.calculationCode) : 1;
                decimal volumePerMs = userInputData.isVolume ? (decimal)(userInputData.volumeTo - userInputData.volumeFrom) /
                                                               (decimal)(userInputData.timingTo - userInputData.timingFrom) : 1;
                int effectCode = userInputData.isKiai ? 1 : 0;
                if (!SetSvOnHitObjects(userInputData,
                                      beatmap,
                                      ref outTimingPoints,
                                      svPerMs,
                                      volumePerMs,
                                      ref baseBpm,
                                      effectCode))
                {
                    throw new Exception("");
                }
                if (!SetSvOnTimingPoints(userInputData,
                                         beatmap,
                                         ref outTimingPoints,
                                         svPerMs,
                                         volumePerMs,
                                         baseBpm,
                                         effectCode))
                {
                    throw new Exception("");
                }
                // 
                if (userInputData.isKiai)
                {
                    if (!SetSvOnInputTiming(userInputData, beatmap, ref outTimingPoints, 1))
                    {
                        throw new Exception("");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// ブックマークのタイミングに緑線を設置する
        /// </summary>
        /// <param name="userInputData">入力値</param>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="outTimingPoints">追加したタイミングポイントの出力先</param>
        /// <returns></returns>
        private static bool AddAllBookmarks(UserInputData userInputData, Beatmap beatmap, ref List<TimingPoint> outTimingPoints)
        {
            decimal baseBpm = 0;
            bool isFirst = true;
            int offset = userInputData.isOffset ? userInputData.offset : 0;
            // 1msあたりのSV,Volumeを計算
            decimal svPerMs = GetSvPerMs(userInputData.svFrom,
                                         userInputData.svTo,
                                         userInputData.timingFrom,
                                         userInputData.timingTo,
                                         userInputData.calculationCode);
            decimal volumePerMs = (decimal)(userInputData.volumeTo - userInputData.volumeFrom) /
                                  (decimal)(userInputData.timingTo - userInputData.timingFrom);
            int effectCode = userInputData.isKiai ? 1 : 0;
            try
            {
                for (global::System.Int32 i = 0; i < beatmap.bookmarks.Count; i++)
                {
                    if ((beatmap.bookmarks[i].time >= userInputData.timingFrom) &&
                        (beatmap.bookmarks[i].time <= userInputData.timingTo))
                    {
                        // ベースのBPMを求める
                        if (isFirst)
                        {
                            baseBpm = beatmap.hitObjects[i].bpm;
                            isFirst = false;
                        }
                        int time = beatmap.hitObjects[i].time;
                        decimal sv = 0;
                        int volume = 0;
                        int timingIndex = 0;
                        int inheritedIndex = 0;
                        bool isSetInheritedIndex = false;
                        // ノーツに適応されているTimingPointのインデックスを取得する
                        for (global::System.Int32 j = (beatmap.timingPoints.Count) - (1); j >= 0; j--)
                        {
                            if (beatmap.timingPoints[j].time <= beatmap.bookmarks[i].time)
                            {
                                if (!isSetInheritedIndex)
                                {
                                    inheritedIndex = j;
                                    isSetInheritedIndex = true;
                                }
                                if (beatmap.timingPoints[j].isRedLine)
                                {
                                    timingIndex = j;
                                    break;
                                }
                            }
                        }
                        // SV有効化フラグが有効の場合、SVを計算する
                        if (userInputData.isSv)
                        {
                            sv = CalculateSv(userInputData.svFrom,
                                             svPerMs,
                                             userInputData.timingFrom,
                                             beatmap.bookmarks[i].time,
                                             userInputData.calculationCode) *
                                 (baseBpm / beatmap.hitObjects[i].bpm);
                        }
                        else
                        {
                            // 無効の場合は元から適応されているSVを設定する
                            sv = beatmap.timingPoints[inheritedIndex].sv;
                        }
                        // Volume有効化フラグが有効の場合、音量を計算する
                        if (userInputData.isVolume)
                        {
                            // Volumeは等差固定で計算
                            volume = (int)(userInputData.volumeFrom +
                                          (volumePerMs * (beatmap.bookmarks[i].time - userInputData.timingFrom)));
                        }
                        else
                        {
                            // 無効の場合は元から適応されている音量を設定する
                            volume = beatmap.timingPoints[inheritedIndex].volume;
                        }
                        // 緑線を追加
                        outTimingPoints.Add(new TimingPoint(time - offset,
                                                            beatmap.timingPoints[inheritedIndex].bpm,
                                                            sv,
                                                            beatmap.timingPoints[inheritedIndex].barLength,
                                                            beatmap.timingPoints[inheritedIndex].meter,
                                                            beatmap.timingPoints[inheritedIndex].sampleSet,
                                                            beatmap.timingPoints[inheritedIndex].sampleIndex,
                                                            volume,
                                                            false,
                                                            effectCode));
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }

        private static bool AddAllBarLines(UserInputData userInputData, Beatmap beatmap, ref List<TimingPoint> outTimingPoints)
        {
            decimal baseBpm = 0;
            bool isFirst = true;
            int offset = userInputData.isOffset ? userInputData.offset : 0;
            // 1msあたりのSV,Volumeを計算
            decimal svPerMs = GetSvPerMs(userInputData.svFrom,
                                         userInputData.svTo,
                                         userInputData.timingFrom,
                                         userInputData.timingTo,
                                         userInputData.calculationCode);
            decimal volumePerMs = (decimal)(userInputData.volumeTo - userInputData.volumeFrom) /
                                  (decimal)(userInputData.timingTo - userInputData.timingFrom);
            int effectCode = userInputData.isKiai ? 1 : 0;
            try
            {
                for (global::System.Int32 i = 0; i < beatmap.hitObjects.Count; i++)
                {
                    if ((beatmap.hitObjects[i].time >= userInputData.timingFrom) &&
                        (beatmap.hitObjects[i].time <= userInputData.timingTo))
                    {
                        // 小節線以外の場合、スルーする
                        if ((beatmap.hitObjects[i].isOnBarline))
                        {
                            continue;
                        }
                        // ベースのBPMを求める
                        if (isFirst)
                        {
                            baseBpm = beatmap.hitObjects[i].bpm;
                            isFirst = false;
                        }
                        int time = beatmap.hitObjects[i].time;
                        decimal sv = 0;
                        int volume = 0;
                        int timingIndex = 0;
                        int inheritedIndex = 0;
                        bool isSetInheritedIndex = false;
                        // 小節線に適応されているTimingPointのインデックスを取得する
                        for (global::System.Int32 j = (beatmap.timingPoints.Count) - (1); j >= 0; j--)
                        {
                            if (beatmap.timingPoints[j].time <= beatmap.hitObjects[i].time)
                            {
                                if (!isSetInheritedIndex)
                                {
                                    inheritedIndex = j;
                                    isSetInheritedIndex = true;
                                }
                                if (beatmap.timingPoints[j].isRedLine)
                                {
                                    timingIndex = j;
                                    break;
                                }
                            }
                        }
                        // SV有効化フラグが有効の場合、SVを計算する
                        if (userInputData.isSv)
                        {
                            sv = CalculateSv(userInputData.svFrom,
                                             svPerMs,
                                             userInputData.timingFrom,
                                             beatmap.hitObjects[i].time,
                                             userInputData.calculationCode) *
                                 (baseBpm / beatmap.hitObjects[i].bpm);
                        }
                        else
                        {
                            // 無効の場合は元から適応されているSVを設定する
                            sv = beatmap.timingPoints[inheritedIndex].sv;
                        }
                        // Volume有効化フラグが有効の場合、音量を計算する
                        if (userInputData.isVolume)
                        {
                            // Volumeは等差固定で計算
                            volume = (int)(userInputData.volumeFrom +
                                          (volumePerMs * (beatmap.hitObjects[i].time - userInputData.timingFrom)));
                        }
                        else
                        {
                            // 無効の場合は元から適応されている音量を設定する
                            volume = beatmap.timingPoints[inheritedIndex].volume;
                        }
                        // スライダーの場合はsliderLengthを調整する
                        if (beatmap.hitObjects[i].noteType == Constants.NoteType.SLIDER)
                        {
                            beatmap.hitObjects[i].sliderLength = beatmap.hitObjects[i].sliderLength *
                                                                 (sv / beatmap.hitObjects[i].sv);
                        }
                        // 緑線を追加
                        outTimingPoints.Add(new TimingPoint(time - offset,
                                                            beatmap.timingPoints[inheritedIndex].bpm,
                                                            sv,
                                                            beatmap.timingPoints[inheritedIndex].barLength,
                                                            beatmap.timingPoints[inheritedIndex].meter,
                                                            beatmap.timingPoints[inheritedIndex].sampleSet,
                                                            beatmap.timingPoints[inheritedIndex].sampleIndex,
                                                            volume,
                                                            false,
                                                            effectCode));
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }


        /// <summary>
        /// 1msあたりのSVを計算する
        /// </summary>
        /// <param name="svFrom">SV(始点)</param>
        /// <param name="svTo">SV(終点)</param>
        /// <param name="timingFrom">Timing(始点)</param>
        /// <param name="timingTo">Timing(終点)</param>
        /// <param name="calculationCode">計算コード</param>
        /// <returns>1msあたりのSVを返す</returns>
        /// <exception cref="ArgumentException">計算コードが不正</exception>
        private static decimal GetSvPerMs(decimal svFrom,
                                          decimal svTo,
                                          int timingFrom,
                                          int timingTo,
                                          int calculationCode)
        {
            switch (calculationCode)
            {
                case Constants.CALCULATION_ARITHMETIC:
                    return (svTo - svFrom) / (timingTo - timingFrom);
                case Constants.CALCULATION_GEOMETRIC:
                    return (decimal)Math.Pow((double)(svTo / svFrom), 1.0 / (timingTo - timingFrom));
                default:
                    throw new ArgumentException("Invalid calculation code");
            }
        }
        /// <summary>
        /// 算出した1msあたりのSVを元に、指定されたタイミングのSVを計算する
        /// </summary>
        /// <param name="svFrom">SV(始点)</param>
        /// <param name="svPerMs">1msあたりのSV</param>
        /// <param name="timingFrom">Timing(始点)</param>
        /// <param name="currentTiming">現地点のTiming</param>
        /// <param name="calculationCode">計算コード</param>
        /// <returns>算出したSV</returns>
        /// <exception cref="ArgumentException">計算コードが不正</exception>
        private static decimal CalculateSv(decimal svFrom,
                                           decimal svPerMs,
                                           int timingFrom,
                                           int currentTiming,
                                           int calculationCode)
        {
            switch (calculationCode)
            {
                case Constants.CALCULATION_ARITHMETIC:
                    return svFrom + (svPerMs * (currentTiming - timingFrom));
                case Constants.CALCULATION_GEOMETRIC:
                    return svFrom * (decimal)Math.Pow((double)svPerMs, (double)(currentTiming - timingFrom));
                default:
                    throw new ArgumentException("Invalid calculation code");
            }
        }
        /// <summary>
        /// HitObjectのタイミングにSVを設定する
        /// </summary>
        /// <param name="userInputData">入力値</param>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="timingPointBuff">追加したSVの出力先</param>
        /// <param name="svPerMs">1msあたりのＳＶ</param>
        /// <param name="volumePerMs">1msあたりのVolume</param>
        /// <param name="effectCode">エフェクトコード</param>
        /// <returns></returns>
        private static bool SetSvOnHitObjects(UserInputData userInputData,
                                              Beatmap beatmap,
                                              ref List<TimingPoint> timingPointBuff,
                                              decimal svPerMs,
                                              decimal volumePerMs,
                                              ref decimal baseBpm,
                                              int effectCode)
        {
            bool isFirst = true;
            int offset = userInputData.isOffset ? userInputData.offset : 0;
            try
            {
                for (global::System.Int32 i = 0; i < beatmap.hitObjects.Count; i++)
                {
                    if ((beatmap.hitObjects[i].time >= userInputData.timingFrom) &&
                        (beatmap.hitObjects[i].time <= userInputData.timingTo))
                    {
                        // ベースのBPMを求める
                        if (isFirst)
                        {
                            baseBpm = beatmap.hitObjects[i].bpm;
                            isFirst = false;
                        }
                        int time = beatmap.hitObjects[i].time;
                        decimal sv = 0;
                        int volume = 0;
                        int timingIndex = 0;
                        int inheritedIndex = 0;
                        bool isSetInheritedIndex = false;
                        // ノーツに適応されているTimingPointのインデックスを取得する
                        for (global::System.Int32 j = (beatmap.timingPoints.Count) - (1); j >= 0; j--)
                        {
                            if (beatmap.timingPoints[j].time <= beatmap.hitObjects[i].time)
                            {
                                if (!isSetInheritedIndex)
                                {
                                    inheritedIndex = j;
                                    isSetInheritedIndex = true;
                                }
                                if (beatmap.timingPoints[j].isRedLine)
                                {
                                    timingIndex = j;
                                    break;
                                }
                            }
                        }
                        // SV有効化フラグが有効の場合、SVを計算する
                        if (userInputData.isSv)
                        {
                            sv = CalculateSv(userInputData.svFrom,
                                             svPerMs,
                                             userInputData.timingFrom,
                                             beatmap.hitObjects[i].time,
                                             userInputData.calculationCode) *
                                 (baseBpm / beatmap.hitObjects[i].bpm);
                        }
                        else
                        {
                            // 無効の場合は元から適応されているSVを設定する
                            sv = beatmap.timingPoints[inheritedIndex].sv;
                        }
                        // Volume有効化フラグが有効の場合、音量を計算する
                        if (userInputData.isVolume)
                        {
                            // Volumeは等差固定で計算
                            volume = Convert.ToInt32(userInputData.volumeFrom +
                                                    (volumePerMs * (beatmap.hitObjects[i].time - userInputData.timingFrom)));
                        }
                        else
                        {
                            // 無効の場合は元から適応されている音量を設定する
                            volume = beatmap.timingPoints[inheritedIndex].volume;
                        }
                        // スライダーの場合はsliderLengthを調整する
                        if (beatmap.hitObjects[i].noteType == Constants.NoteType.SLIDER)
                        {
                            beatmap.hitObjects[i].sliderLength = beatmap.hitObjects[i].sliderLength *
                                                                 (sv / beatmap.hitObjects[i].sv);
                        }
                        // 緑線を追加
                        timingPointBuff.Add(new TimingPoint(time - offset,
                                                            beatmap.timingPoints[inheritedIndex].bpm,
                                                            sv,
                                                            beatmap.timingPoints[inheritedIndex].barLength,
                                                            beatmap.timingPoints[inheritedIndex].meter,
                                                            beatmap.timingPoints[inheritedIndex].sampleSet,
                                                            beatmap.timingPoints[inheritedIndex].sampleIndex,
                                                            volume,
                                                            false,
                                                            effectCode));
                        // kiaiの始点かつ、オフセットが0じゃないかつ、
                        // Timing(始点)とノーツのタイミングが同じ場合はkiaiを外す
                        if (userInputData.isKiaiStart && (offset != 0) && (beatmap.hitObjects[i].time == userInputData.timingFrom))
                        {
                            timingPointBuff.Last().effect = 0;
                            timingPointBuff.Add(new TimingPoint(time,
                                                                beatmap.timingPoints[inheritedIndex].bpm,
                                                                sv,
                                                                beatmap.timingPoints[inheritedIndex].barLength,
                                                                beatmap.timingPoints[inheritedIndex].meter,
                                                                beatmap.timingPoints[inheritedIndex].sampleSet,
                                                                beatmap.timingPoints[inheritedIndex].sampleIndex,
                                                                volume,
                                                                false,
                                                                1));
                        }
                        if (userInputData.isKiaiEnd)
                        {
                            if ((offset == 0) && (beatmap.hitObjects[i].time == userInputData.timingTo))
                            {
                                timingPointBuff.Last().effect = 0;
                            }
                            if ((offset != 0) && (beatmap.hitObjects[i].time == userInputData.timingTo))
                            {
                                timingPointBuff.Add(new TimingPoint(time,
                                        beatmap.timingPoints[inheritedIndex].bpm,
                                        sv,
                                        beatmap.timingPoints[inheritedIndex].barLength,
                                        beatmap.timingPoints[inheritedIndex].meter,
                                        beatmap.timingPoints[inheritedIndex].sampleSet,
                                        beatmap.timingPoints[inheritedIndex].sampleIndex,
                                        volume,
                                        false,
                                        0));
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteExceptionMessage(ex);
                return false;
            }

        }
        /// <summary>
        /// TimingPoints(赤線)が設定されているタイミングにSVを設定する
        /// </summary>
        /// <param name="userInputData">入力値</param>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="timingPointBuff">追加したSVの出力先</param>
        /// <param name="svPerMs">1msあたりのＳＶ</param>
        /// <param name="volumePerMs">1msあたりのVolume</param>
        /// <param name="baseBpm">始点のBPM</param>
        /// <param name="effectCode">エフェクトコード</param>
        /// <returns></returns>
        private static bool SetSvOnTimingPoints(UserInputData userInputData,
                                                Beatmap beatmap,
                                                ref List<TimingPoint> timingPointBuff,
                                                decimal svPerMs,
                                                decimal volumePerMs,
                                                decimal baseBpm,
                                                int effectCode)
        {
            int offset = userInputData.isOffset ? userInputData.offset : 0;
            try
            {
                for (global::System.Int32 i = (beatmap.timingPoints.Count) - (1); i >= 0; i--)
                {
                    decimal sv = 1;
                    int volume = 100;
                    if ((beatmap.timingPoints[i].time >= userInputData.timingFrom) &&
                        (beatmap.timingPoints[i].time <= userInputData.timingTo) &&
                        beatmap.timingPoints[i].isRedLine)
                    {
                        var hitObjects = beatmap.hitObjects.Where(data => data.time == beatmap.timingPoints[i].time);
                        if (offset == 0)
                        {
                            if (hitObjects.Count() != 0)
                            {
                                continue;
                            }
                        }
                        if (beatmap.timingPoints[i].time == userInputData.timingFrom ||
                            beatmap.timingPoints[i].time == userInputData.timingTo)
                        {
                            if (hitObjects.Count() != 0)
                            {
                                continue;
                            }
                        }
                        if (userInputData.isSv)
                        {
                            sv = CalculateSv(userInputData.svFrom,
                                             svPerMs,
                                             userInputData.timingFrom,
                                             beatmap.timingPoints[i].time,
                                             userInputData.calculationCode) *
                                 (baseBpm / beatmap.timingPoints[i].bpm);
                        }
                        else
                        {
                            // 無効の場合は元から適応されているSVを設定する
                            sv = 1;
                        }
                        // Volume有効化フラグが有効の場合、音量を計算する
                        if (userInputData.isVolume)
                        {
                            // Volumeは等差固定で計算
                            volume = Convert.ToInt32(userInputData.volumeFrom +
                                                    (volumePerMs * (beatmap.timingPoints[i].time - userInputData.timingFrom)));
                        }
                        else
                        {
                            // 無効の場合は元から適応されている音量を設定する
                            volume = beatmap.timingPoints[i].volume;
                        }
                        timingPointBuff.Add(new TimingPoint(beatmap.timingPoints[i].time,
                                                            beatmap.timingPoints[i].bpm,
                                                            sv,
                                                            beatmap.timingPoints[i].barLength,
                                                            beatmap.timingPoints[i].meter,
                                                            beatmap.timingPoints[i].sampleSet,
                                                            beatmap.timingPoints[i].sampleIndex,
                                                            volume,
                                                            false,
                                                            effectCode));
                        if (userInputData.isKiaiEnd && (beatmap.timingPoints[i].time == userInputData.timingTo))
                        {
                            timingPointBuff.Last().effect = 0;
                        }
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// Kiaiの切り替えがある場合に入力値の始点や終点にSVを設定する
        /// </summary>
        /// <param name="userInputData">入力値</param>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="timingPointBuff">追加したSVの出力先</param>
        /// <param name="targetCode">一致しているものの対象</param>
        /// <returns></returns>
        private static bool SetSvOnInputTiming(UserInputData userInputData,
                                               Beatmap beatmap,
                                               ref List<TimingPoint> timingPointBuff,
                                               int targetCode)
        {
            try
            {
                int startInheritedIndex = -1;
                int endInheritedIndex = -1;
                decimal sv = 1;
                int volume = 100;
                List<int> targetTimings;
                if (targetCode == 1)
                {
                    targetTimings = (List<int>)beatmap.hitObjects.Where(data => data.time == userInputData.timingFrom);
                }
                else
                {
                    targetTimings = (List<int>)beatmap.timingPoints.Where(data => data.time == userInputData.timingFrom);
                }
                if (userInputData.isKiaiStart && (targetTimings.Count() == 0))
                {
                    for (global::System.Int32 i = (beatmap.timingPoints.Count) - (1); i >= 0; i--)
                    {
                        if (beatmap.timingPoints[i].time < userInputData.timingFrom)
                        {
                            startInheritedIndex = i;
                            break;
                        }
                    }
                    if (startInheritedIndex == -1)
                    {
                    }
                    if (userInputData.isSv)
                    {
                        sv = userInputData.svFrom;
                    }
                    else
                    {
                        // 無効の場合は元から適応されているSVを設定する
                        sv = beatmap.timingPoints[startInheritedIndex].sv;
                    }
                    if (userInputData.isVolume)
                    {
                        volume = userInputData.volumeFrom;
                    }
                    else
                    {
                        // 無効の場合は元から適応されているSVを設定する
                        volume = beatmap.timingPoints[startInheritedIndex].volume;
                    }
                    timingPointBuff.Add(new TimingPoint(userInputData.timingFrom,
                                                        beatmap.timingPoints[startInheritedIndex].bpm,
                                                        sv,
                                                        beatmap.timingPoints[startInheritedIndex].barLength,
                                                        beatmap.timingPoints[startInheritedIndex].meter,
                                                        beatmap.timingPoints[startInheritedIndex].sampleSet,
                                                        beatmap.timingPoints[startInheritedIndex].sampleIndex,
                                                        volume,
                                                        false,
                                                        1));
                }
                if (targetCode == 1)
                {
                    targetTimings = (List<int>)beatmap.hitObjects.Where(data => data.time == userInputData.timingTo);
                }
                else
                {
                    targetTimings = (List<int>)beatmap.timingPoints.Where(data => data.time == userInputData.timingTo);
                }
                if (userInputData.isKiaiEnd && (targetTimings.Count() == 0))
                {
                    for (global::System.Int32 i = (beatmap.timingPoints.Count) - (1); i >= 0; i--)
                    {
                        if (beatmap.timingPoints[i].time < userInputData.timingTo)
                        {
                            endInheritedIndex = i;
                            break;
                        }
                    }
                    if (endInheritedIndex == -1)
                    {
                    }
                    if (userInputData.isSv)
                    {
                        sv = userInputData.svTo;
                    }
                    else
                    {
                        // 無効の場合は元から適応されているSVを設定する
                        sv = beatmap.timingPoints[endInheritedIndex].sv;
                    }
                    if (userInputData.isVolume)
                    {
                        volume = userInputData.volumeTo;
                    }
                    else
                    {
                        // 無効の場合は元から適応されているSVを設定する
                        volume = beatmap.timingPoints[endInheritedIndex].volume;
                    }
                    timingPointBuff.Add(new TimingPoint(userInputData.timingTo,
                                                        beatmap.timingPoints[endInheritedIndex].bpm,
                                                        sv,
                                                        beatmap.timingPoints[endInheritedIndex].barLength,
                                                        beatmap.timingPoints[endInheritedIndex].meter,
                                                        beatmap.timingPoints[endInheritedIndex].sampleSet,
                                                        beatmap.timingPoints[endInheritedIndex].sampleIndex,
                                                        volume,
                                                        false,
                                                        0));
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
    }
}

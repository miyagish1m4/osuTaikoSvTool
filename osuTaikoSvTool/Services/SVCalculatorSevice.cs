using osuTaikoSvTool.Models;
using osuTaikoSvTool.Properties;
using osuTaikoSvTool.Utils;

namespace osuTaikoSvTool.Services
{
    internal class SVCalculatorSevice
    {
        public static bool Add(UserInputData userInputData, Beatmap beatmap)
        {
            try
            {
                // 1msあたりのSV,Volumeを計算
                decimal svPerMs = GetSvPerMs(userInputData.svFrom,
                                             userInputData.svTo,
                                             userInputData.timingFrom,
                                             userInputData.timingTo,
                                             userInputData.calculationCode);
                int volumePerMs = (userInputData.volumeTo - userInputData.volumeFrom) / (userInputData.timingTo - userInputData.timingFrom);
                decimal baseBpm = 0;
                bool isFirst = true;
                int offset = userInputData.isOffset ? userInputData.offset : 0;
                for (global::System.Int32 i = 0; i < beatmap.hitObjects.Count; i++)
                {
                    if ((beatmap.hitObjects[i].time >= userInputData.timingFrom) &&
                        (beatmap.hitObjects[i].time <= userInputData.timingTo))
                    {
                        if (isFirst)
                        {
                            isFirst = !isFirst;
                            baseBpm = beatmap.hitObjects[i].bpm;
                        }
                        if ((!userInputData.isIncludeBarline) && beatmap.hitObjects[i].isBarline)
                        {
                            // 小節線を無視する
                            continue;
                        }
                        int timingIndex = 0;
                        for (global::System.Int32 j = (beatmap.timingPoints.Count) - (1); j >= 0; j--)
                        {
                            if (beatmap.timingPoints[j].time <= beatmap.hitObjects[i].time)
                            {
                                timingIndex = j;
                            }
                        }
                        int time = beatmap.hitObjects[i].time - offset;
                        decimal sv = 0;
                        int volume = 0;
                        if (userInputData.isSv)
                        {
                            // 計算コードに応じてSVを計算
                            sv = CalculateSv(userInputData.svFrom,
                                             svPerMs,
                                             userInputData.timingFrom,
                                             beatmap.hitObjects[i].time,
                                             userInputData.calculationCode) *
                                 (baseBpm / beatmap.hitObjects[i].bpm);
                        }
                        else
                        {
                            sv = beatmap.timingPoints[timingIndex].sv;
                        }
                        if (userInputData.isVolume)
                        {
                            // Volumeは等差固定で計算
                            volume = (int)(userInputData.volumeFrom +
                                          (volumePerMs * (beatmap.hitObjects[i].time - userInputData.timingFrom)));
                        }
                        else
                        {
                            volume = beatmap.timingPoints[timingIndex].volume;
                        }
                        // SV,Volumeをタイミングポイントに追加
                        beatmap.timingPoints.Add(new TimingPoint(time,
                                                                 beatmap.timingPoints[timingIndex].bpm,
                                                                 sv,
                                                                 beatmap.timingPoints[timingIndex].barLength,
                                                                 beatmap.timingPoints[timingIndex].meter,
                                                                 beatmap.timingPoints[timingIndex].sampleSet,
                                                                 beatmap.timingPoints[timingIndex].sampleIndex,
                                                                 volume,
                                                                 false,
                                                                 beatmap.timingPoints[timingIndex].effect));
                        // 一応ヒットオブジェクトにもSVを設定(意味はない)
                        beatmap.hitObjects[i].sv = sv;
                    }
                }
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
        public static bool Remove(UserInputData userInputData, ref Beatmap beatmap)
        {
            try
            {
                for (global::System.Int32 i = (beatmap.timingPoints.Count) - (1); i >= 0; i--)
                {
                    if ((!beatmap.timingPoints[i].isRedLine) &&
                        (beatmap.timingPoints[i].time >= userInputData.timingFrom) &&
                        (beatmap.timingPoints[i].time <= userInputData.timingTo))
                    {
                        beatmap.timingPoints.RemoveAt(i);
                    }
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
        private static decimal GetSvPerMs(decimal svFrom, decimal svTo, int timingFrom, int timingTo, int calculationCode)
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
        private static decimal CalculateSv(decimal svFrom, decimal svPerMs, int timingFrom, int currentTiming, int calculationCode)
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
    }
}

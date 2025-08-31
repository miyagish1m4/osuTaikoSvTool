﻿using osuTaikoSvTool.Models;
using osuTaikoSvTool.Properties;
using osuTaikoSvTool.Utils;
using osuTaikoSvTool.Utils.Helper;

namespace osuTaikoSvTool.Services
{
    internal class SVCalculatorService
    {
        /// <summary>
        /// 適応ボタン押下時の処理
        /// </summary>
        /// <param name="userInputData">ユーザー入力データ</param>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="outTimingPoints">追加する緑線の格納先</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        internal static bool Apply(UserInputData userInputData, Beatmap beatmap, ref List<TimingPoint> outTimingPoints)
        {
            List<TimingPoint> timingPointsBuff = [];
            try
            {
                if (userInputData.setOption.isSetObjects)
                {
                    // objectに緑線を置く場合
                    if (!ApplyOnObjects(userInputData, beatmap, ref timingPointsBuff))
                    {
                        throw new Exception();
                    }
                }
                else if (userInputData.setOption.isSetBeatSnap)
                {
                    // beatSnap間隔で緑線を置く場合
                    if (!ApplyOnBeatSnaps(userInputData, beatmap, ref timingPointsBuff))
                    {
                        throw new Exception();
                    }

                }
                // 処理で取得した緑線を情報を格納する
                outTimingPoints.AddRange(timingPointsBuff);
                return true;

            }
            catch (Exception ex)
            {
                Common.WriteWarningMessage("LOG_E-ADD-LINES");
                Common.WriteExceptionMessage(ex);
                return false;
            }

        }
        /// <summary>
        /// 削除ボタン押下時の処理
        /// </summary>
        /// <param name="userInputData">ユーザー入力データ</param>
        /// <param name="beatmap">譜面情報</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        internal static bool Remove(UserInputData userInputData, Beatmap beatmap)
        {
            try
            {
                // 緑線の削除を行う
                if (!RemoveInferitedPoint(userInputData, beatmap))
                {
                    throw new Exception();
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
        /// <summary>
        /// 緑線を削除する処理
        /// </summary>
        /// <param name="userInputData">ユーザー入力データ</param>
        /// <param name="beatmap">譜面情報</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool RemoveInferitedPoint(UserInputData userInputData, Beatmap beatmap)
        {
            try
            {
                decimal baseSv = 1m;
                int offset = userInputData.isOffset ? userInputData.offset : 0;
                // 削除後の適応されるSVと音量を求める
                var applyInheritedPoint = beatmap.timingPoints.LastOrDefault(tp => tp.time < (userInputData.timingFrom - offset));
                if (applyInheritedPoint != null)
                {
                    baseSv = applyInheritedPoint.sv;
                }
                else
                {
                    // 最初のタイミングポイントと範囲内の最初のノーツが同じタイミングの場合に該当する
                    baseSv = beatmap.timingPoints[0].sv;
                }
                // 指定範囲内にスライダーがある場合はsliderLengthを調整する
                for (global::System.Int32 i = 0; i < beatmap.hitObjects.Count; i++)
                {
                    if ((beatmap.hitObjects[i].time >= (userInputData.timingFrom - offset)) &&
                        (beatmap.hitObjects[i].time <= userInputData.timingTo) &&
                        (beatmap.hitObjects[i].noteType == Constants.NoteType.SLIDER))
                    {
                        // 途中に赤線が設置されている場合はbaseSvを1に変更する
                        for (global::System.Int32 j = (beatmap.timingPoints.Count) - (1); j >= 0; j--)
                        {
                            if ((beatmap.timingPoints[j].time >= (userInputData.timingFrom - offset)) &&
                                (beatmap.timingPoints[j].time <= beatmap.hitObjects[i].time))
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
                    if (beatmap.timingPoints[i].time > userInputData.timingTo)
                    {
                        continue;
                    }
                    if (beatmap.timingPoints[i].time < (userInputData.timingFrom - offset))
                    {
                        break;
                    }
                    if (!beatmap.timingPoints[i].isRedLine)
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
        /// <summary>
        /// Objectに緑線を適応する
        /// </summary>
        /// <param name="userInputData">ユーザー入力値</param>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="outTimingPoints">適応する緑線の格納先</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool ApplyOnObjects(UserInputData userInputData, Beatmap beatmap, ref List<TimingPoint> outTimingPoints)
        {
            try
            {

                // HitObjectsに緑線適応処理
                if (!ApplyOnHitObjects(userInputData, beatmap, ref outTimingPoints))
                {
                    throw new Exception();
                }
                // TimingPointsに緑線適応処理
                if (!ApplyOnTimingPoints(userInputData, beatmap, ref outTimingPoints))
                {
                    throw new Exception();
                }
                if ((userInputData.setObjectOption.isKiaiStart || userInputData.setObjectOption.isKiaiEnd) && 
                    ((userInputData.setObjectOption.setObjectsCode != 0x00000100) && 
                     (userInputData.setObjectOption.setObjectsCode != 0x00000400)))
                {
                    // 始点・終点に緑線適応処理
                    if (!ApplyOnStartAndEndPoints(userInputData, beatmap, ref outTimingPoints))
                    {
                        throw new Exception();
                    }
                }
                // ユーザーが指定した範囲外のスライダーの長さの調整
                if (!AdjustSliderLengthAfterTimingTo(userInputData, beatmap, ref outTimingPoints))
                {
                    throw new Exception();
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// HitObjectsに緑線を適応する
        /// </summary>
        /// <param name="userInputData">ユーザー入力値</param>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="outTimingPoints">適応する緑線の格納先</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool ApplyOnHitObjects(UserInputData userInputData, Beatmap beatmap, ref List<TimingPoint> outTimingPoints)
        {
            decimal baseBpm = 120;
            decimal svPerMs = 0;
            decimal volumePerMs = 0;
            bool isIgnoreObject = false;
            int offset = userInputData.isOffset ? userInputData.offset : 0;
            int kiaiEffect = userInputData.isKiai ? 1 : 0;
            List<int> removeList = [];
            TimingPoint lastNotesInheritedLine = new();
            TimingPoint? lastNotesTimingPointLine = new();
            try
            {
                // 始点のBPMを求める
                var baseTimingPoint = beatmap.timingPoints.LastOrDefault(tp => (tp.time <= userInputData.timingFrom) && tp.isRedLine);
                baseBpm = baseTimingPoint != null ? baseTimingPoint.bpm : 120;
                if (userInputData.isSv)
                {
                    // 1msあたりのSVの変化量を求める
                    svPerMs = GetSvPerMs(userInputData.svFrom,
                                         userInputData.svTo,
                                         userInputData.timingFrom,
                                         userInputData.timingTo,
                                         userInputData.calculationCode);
                }
                if (userInputData.isVolume)
                {
                    // 1msあたりのVolumeの変化量を求める
                    volumePerMs = (decimal)(userInputData.volumeTo - userInputData.volumeFrom) /
                                  (decimal)(userInputData.timingTo - userInputData.timingFrom);
                }
                for (global::System.Int32 i = 0; i < beatmap.hitObjects.Count; i++)
                {
                    // ユーザーが入力した始点より前の場合は何も処理をしない
                    if (beatmap.hitObjects[i].time < userInputData.timingFrom)
                    {
                        continue;
                    }
                    // ユーザーが入力した始点より後ろの場合は処理を抜ける
                    if (beatmap.hitObjects[i].time > userInputData.timingTo)
                    {
                        break;
                    }
                    decimal sv;
                    int volume;
                    if ((userInputData.setObjectOption.setObjectsCode == 0x0000017f) && 
                        !userInputData.setObjectOption.isTimingStart && 
                        (beatmap.hitObjects[i].time == userInputData.timingFrom))
                    {
                        continue;
                    }
                    if ((userInputData.setObjectOption.setObjectsCode == 0x0000017f) && 
                        !userInputData.setObjectOption.isTimingEnd && 
                        (beatmap.hitObjects[i].time == userInputData.timingTo))
                    {
                        continue;
                    }
                    // オブジェクトコードを比較し、一致するものがある場合に緑線の追加を行う
                    if ((beatmap.hitObjects[i].hitObjectCode & userInputData.setObjectOption.setObjectsCode) != 0)
                    {
                        // 直前のTimingPointを探す
                        var applyInheritedPoint = beatmap.timingPoints.LastOrDefault(tp => tp.time <= beatmap.hitObjects[i].svApplyTime);
                        // 直前のTimingPointのインデックスを算出する
                        var applyInheritedPointIndex = beatmap.timingPoints.FindLastIndex(tp => tp.time <= beatmap.hitObjects[i].svApplyTime);
                        // 直前の赤線を探す
                        var applyTimingPoint = beatmap.timingPoints.LastOrDefault(tp => (tp.time <= beatmap.hitObjects[i].svApplyTime) && tp.isRedLine);
                        if (i != 0)
                        {
                            // 直前のTimingPointが前のノーツより後にあるかつ、
                            // ユーザーの指定範囲内の場合は削除対象にする
                            if ((beatmap.hitObjects[i - 1].time < applyInheritedPoint?.time) &&
                                (userInputData.timingFrom - userInputData.offset <= applyInheritedPoint?.time) &&
                                !applyInheritedPoint.isRedLine)
                            {
                                removeList.Add(applyInheritedPointIndex);
                            }
                        }
                        if (userInputData.isSv)
                        {
                            // 直前のSVを取得する
                            decimal baseSv = applyInheritedPoint != null ? applyInheritedPoint.sv : 1m;
                            // SVを求める
                            sv = applyTimingPoint != null ? CalculateSv(userInputData.svFrom,
                                                                        svPerMs,
                                                                        userInputData.timingFrom,
                                                                        beatmap.hitObjects[i].time,
                                                                        baseSv,
                                                                        userInputData.calculationCode,
                                                                        userInputData.relativeCode,
                                                                        userInputData.relativeBaseSv) *
                                                                        (baseBpm / applyTimingPoint.bpm) : 120;
                        }
                        else
                        {
                            // 直前のSVを参照する
                            sv = applyInheritedPoint != null ? applyInheritedPoint.sv : 1m;
                        }
                        if (userInputData.isVolume)
                        {
                            // 音量を求める
                            volume = applyTimingPoint != null ? (int)Math.Floor(CalculateVolume(userInputData.volumeFrom,
                                                                                                volumePerMs,
                                                                                                userInputData.timingFrom,
                                                                                                beatmap.hitObjects[i].time) *
                                                                                                (baseBpm / applyTimingPoint.bpm)) : 100;
                        }
                        else
                        {
                            // 直前の音量を参照する
                            volume = applyInheritedPoint != null ? applyInheritedPoint.volume : 100;
                        }
                        if (beatmap.hitObjects[i].noteType == Constants.NoteType.SLIDER)
                        {
                            // スライダーの長さを調整する
                            beatmap.hitObjects[i].sliderLength = beatmap.hitObjects[i].sliderLength *
                                                                 (sv / beatmap.hitObjects[i].sv);
                        }
                        // 緑線を追加する
                        outTimingPoints.Add(new TimingPoint(beatmap.hitObjects[i].time - offset,
                                                            0,//bpmは緑線には不要な情報の為、0を設定する
                                                            sv,
                                                            0,//barLengthは緑線には不要な情報の為、0を設定する
                                                            applyInheritedPoint != null ? applyInheritedPoint.meter : 4,
                                                            applyInheritedPoint != null ? applyInheritedPoint.sampleSet : 1,
                                                            applyInheritedPoint != null ? applyInheritedPoint.sampleIndex : 0,
                                                            volume,
                                                            false,
                                                            kiaiEffect));
                        isIgnoreObject = false;
                    }
                    else
                    {
                        // 前回のノーツがSV,Volumeの計算の対象外だった場合は何もしない
                        if (isIgnoreObject)
                        {
                            continue;
                        }
                        // 全体の1ノーツ目だった場合は最低でも赤線が適応されているため、何も処理をしない
                        if (i == 0)
                        {
                            continue;
                        }
                        // 直前のTimingPointを探す
                        var applyInheritedPoint = beatmap.timingPoints.LastOrDefault(tp => tp.time <= beatmap.hitObjects[i].svApplyTime);
                        // 直前のTimingPointのインデックスを算出する
                        var applyInheritedPointIndexes = beatmap.timingPoints.Select((tp, index) => new { tp, index }).
                                                                              Where(x => x.tp.time <= beatmap.hitObjects[i].svApplyTime).
                                                                              Select(x => x.index).
                                                                              ToList();
                        if (beatmap.hitObjects[i].noteType != Constants.NoteType.BARLINE || offset != 0)
                        {
                            isIgnoreObject = true;
                        }
                        if (beatmap.hitObjects[i - 1].time >= applyInheritedPoint?.time)
                        {
                            // 緑線が前のノーツより前にある場合は該当するノーツのタイミングに緑線を追加する
                            outTimingPoints.Add(new TimingPoint(beatmap.hitObjects[i].time - offset,
                                                                applyInheritedPoint.bpm,
                                                                applyInheritedPoint.sv,
                                                                applyInheritedPoint.barLength,
                                                                applyInheritedPoint.meter,
                                                                applyInheritedPoint.sampleSet,
                                                                applyInheritedPoint.sampleIndex,
                                                                applyInheritedPoint.volume,
                                                                false,
                                                                kiaiEffect));
                        }
                        else
                        {
                            // 直前のTimingPointが見つからなかった場合はエラー
                            if (applyInheritedPoint == null)
                            {
                                throw new Exception("情報の取得に失敗しました。");
                            }
                            // 直前のTimingPointの情報を元に緑線を作成する
                            outTimingPoints.Add(new TimingPoint(beatmap.hitObjects[i].time - offset,
                                                                applyInheritedPoint.bpm,
                                                                applyInheritedPoint.sv,
                                                                applyInheritedPoint.barLength,
                                                                applyInheritedPoint.meter,
                                                                applyInheritedPoint.sampleSet,
                                                                applyInheritedPoint.sampleIndex,
                                                                applyInheritedPoint.volume,
                                                                false,
                                                                kiaiEffect));
                        }
                        foreach (var applyInheritedPointIndex in applyInheritedPointIndexes)
                        {
                            if ((beatmap.timingPoints[applyInheritedPointIndex].time > beatmap.hitObjects[i - 1].time) &&
                                !beatmap.timingPoints[applyInheritedPointIndex].isRedLine)
                            {
                                // 直前のTimingPointが前のノーツより後にある場合は削除対象にする
                                removeList.Add(applyInheritedPointIndex);
                            }
                        }
                    }
                }
                // 削除をする際に順番が変にならないようにソートする
                removeList.Sort();
                // 前から削除を行うと要素を詰めてしまうため、後ろから削除を行う
                for (global::System.Int32 i = (removeList.Count) - (1); i >= 0; i--)
                {
                    beatmap.timingPoints.RemoveAt(removeList[i]);
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// 赤線に緑線を適応する
        /// </summary>
        /// <param name="userInputData">ユーザー入力値</param>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="outTimingPoints">適応する緑線の格納先</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool ApplyOnTimingPoints(UserInputData userInputData, Beatmap beatmap, ref List<TimingPoint> outTimingPoints)
        {
            decimal baseBpm = 120;
            decimal svPerMs = 0;
            decimal volumePerMs = 0;
            int kiaiEffect = userInputData.isKiai ? 1 : 0;
            int offset = userInputData.isOffset ? userInputData.offset : 0;
            List<TimingPoint> timingPointsBuff = [];
            List<int> removeList = [];
            try
            {
                // 始点のBPMを求める
                var baseTimingPoint = beatmap.timingPoints.LastOrDefault(tp => (tp.time <= userInputData.timingFrom) && tp.isRedLine);
                baseBpm = baseTimingPoint != null ? baseTimingPoint.bpm : 120;
                if (userInputData.isSv)
                {
                    // 1msあたりのSVの変化量を求める
                    svPerMs = GetSvPerMs(userInputData.svFrom,
                                         userInputData.svTo,
                                         userInputData.timingFrom,
                                         userInputData.timingTo,
                                         userInputData.calculationCode);
                }
                if (userInputData.isVolume)
                {
                    // 1msあたりのVolumeの変化量を求める
                    volumePerMs = (decimal)(userInputData.volumeTo - userInputData.volumeFrom) /
                                  (decimal)(userInputData.timingTo - userInputData.timingFrom);
                }
                for (int i = 0; i < beatmap.hitObjects.Count; i++)
                {
                    // 緑線設定フラグ
                    bool isSetInheritedPoint = false;
                    if (beatmap.hitObjects[i].time < userInputData.timingFrom)
                    {
                        continue;
                    }
                    if (beatmap.hitObjects[i].time > userInputData.timingTo)
                    {
                        break;
                    }
                    if ((userInputData.setObjectOption.setObjectsCode == 0x0000017f) &&
                        !userInputData.setObjectOption.isTimingStart &&
                        (beatmap.hitObjects[i].time == userInputData.timingFrom))
                    {
                        continue;
                    }
                    if ((userInputData.setObjectOption.setObjectsCode == 0x0000017f) &&
                        !userInputData.setObjectOption.isTimingEnd &&
                        (beatmap.hitObjects[i].time == userInputData.timingTo))
                    {
                        continue;
                    }
                    var applyTimingPoint = beatmap.timingPoints.LastOrDefault(tp => (tp.time == beatmap.hitObjects[i].time) && tp.isRedLine);
                    decimal sv = 1;
                    int volume = 100;
                    TimingPoint? applyOutputInheritedPoint = new();
                    // ノーツと同じタイミングに赤線がある場合
                    if (applyTimingPoint != null)
                    {
                        // オフセット値が0の場合
                        if (offset == 0)
                        {

                            applyOutputInheritedPoint = outTimingPoints.LastOrDefault(tp => (tp.time == beatmap.hitObjects[i].time) && !tp.isRedLine);
                            // ノーツと同じタイミングに緑線がない場合
                            if (applyOutputInheritedPoint == null)
                            {
                                // 緑線設定フラグを有効にする
                                isSetInheritedPoint = true;
                            }
                            // ある場合は(同じタイミングに赤線,緑線,ノーツがある)
                            else
                            {
                                // 何もしない
                                continue;
                            }
                        }
                        // オフセット値が0以外の場合
                        else
                        {
                            // 緑線設定フラグを有効にする
                            isSetInheritedPoint = true;
                        }
                    }
                    // 緑線設定フラグが有効の場合
                    if (isSetInheritedPoint)
                    {
                        // 直前のTimingPointを探す
                        var applyInheritedPoint = beatmap.timingPoints.LastOrDefault(tp => tp.time <= beatmap.hitObjects[i].svApplyTime);
                        // 直前のTimingPointのインデックスを算出する
                        var applyInheritedPointIndex = beatmap.timingPoints.FindLastIndex(tp => tp.time <= beatmap.hitObjects[i].svApplyTime);
                        // オブジェクトコードを比較し、一致するものがある場合にSV,Volumeの計算を行う
                        if ((beatmap.hitObjects[i].hitObjectCode & userInputData.setObjectOption.setObjectsCode) != 0)
                        {
                            if (userInputData.isSv)
                            {
                                // 直前のSVを取得する
                                decimal baseSv = applyInheritedPoint != null ? applyInheritedPoint.sv : 1m;
                                // SVを求める
                                sv = applyTimingPoint != null ? CalculateSv(userInputData.svFrom,
                                                                            svPerMs,
                                                                            userInputData.timingFrom,
                                                                            beatmap.hitObjects[i].time,
                                                                            baseSv,
                                                                            userInputData.calculationCode,
                                                                            userInputData.relativeCode,
                                                                            userInputData.relativeBaseSv) *
                                                                            (baseBpm / applyTimingPoint.bpm) : 120;
                            }
                            else
                            {
                                // 直前のSVを参照する
                                sv = applyInheritedPoint != null ? applyInheritedPoint.sv : 1m;
                            }
                        }
                        else
                        {
                            // 直前のSVを参照する
                            sv = applyInheritedPoint != null ? applyInheritedPoint.sv : 1m;

                        }
                        if (userInputData.isVolume)
                        {
                            // 音量を求める
                            volume = applyTimingPoint != null ? (int)Math.Floor(CalculateVolume(userInputData.volumeFrom,
                                                                                                volumePerMs,
                                                                                                userInputData.timingFrom,
                                                                                                beatmap.hitObjects[i].time) *
                                                                                                (baseBpm / applyTimingPoint.bpm)) : 100;
                        }
                        else
                        {
                            // 直前の音量を参照する
                            volume = applyInheritedPoint != null ? applyInheritedPoint.volume : 100;
                        }
                        if (applyTimingPoint != null)
                        {
                            outTimingPoints.Add(new TimingPoint(beatmap.hitObjects[i].time,
                                                                0,
                                                                sv,
                                                                0,
                                                                applyTimingPoint.meter,
                                                                applyTimingPoint.sampleSet,
                                                                applyTimingPoint.sampleIndex,
                                                                volume,
                                                                false,
                                                                kiaiEffect));
                        }
                    }
                    else
                    {
                        continue;
                    }
                    var applyInheritedPointIndexes = beatmap.timingPoints.Select((tp, index) => new { tp, index }).
                                                                          Where(x => (x.tp.time <= beatmap.hitObjects[i].svApplyTime) && !x.tp.isRedLine).
                                                                          Select(x => x.index).
                                                                          ToList();
                    if (applyInheritedPointIndexes.Count != 0)
                    {
                        for (global::System.Int32 j = (applyInheritedPointIndexes.Count - 1); j >= 0; j--)
                        {
                            if (beatmap.timingPoints[applyInheritedPointIndexes[j]].time > beatmap.hitObjects[i - 1].time)
                            {
                                beatmap.timingPoints.RemoveAt(applyInheritedPointIndexes[j]);
                            }
                        }
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// 始点と終点に緑線を適応する
        /// </summary>
        /// <param name="userInputData">ユーザー入力値</param>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="outTimingPoints">適応する緑線の格納先</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool ApplyOnStartAndEndPoints(UserInputData userInputData, Beatmap beatmap, ref List<TimingPoint> outTimingPoints)
        {
            int offset = userInputData.isOffset ? userInputData.offset : 0;
            //実行コード
            // 0b0010 ノーツある
            // 0b0001 オフセずれてる
            int executeCode = 0;
            try
            {
                // 順番を揃える為ソートする
                outTimingPoints = [.. outTimingPoints.OrderBy(otp => otp.time)];
                if (userInputData.setObjectOption.isKiaiStart)
                {
                    var hitObjectOnTimingFrom = beatmap.hitObjects.FirstOrDefault(tp => tp.time == userInputData.timingFrom);
                    if (hitObjectOnTimingFrom != null)
                    {
                        executeCode += 0b0010;
                    }
                    if (offset != 0)
                    {
                        executeCode += 0b0001;
                    }
                    switch (executeCode)
                    {
                        case 0b0000:
                        case 0b0001:
                            if (userInputData.setObjectOption.isTimingStart)
                            {
                                // 直前の緑線と入力値を基に緑線を作成する
                                var applyTimingPoint = beatmap.timingPoints.LastOrDefault(tp => tp.time <= userInputData.timingFrom);
                                if (applyTimingPoint != null)
                                {
                                    outTimingPoints.Add(new TimingPoint(userInputData.timingFrom,
                                                                        applyTimingPoint.bpm,
                                                                        userInputData.isSv ? userInputData.svFrom : applyTimingPoint.sv,
                                                                        applyTimingPoint.barLength,
                                                                        applyTimingPoint.meter,
                                                                        applyTimingPoint.sampleSet,
                                                                        applyTimingPoint.sampleIndex,
                                                                        userInputData.isVolume ? userInputData.volumeFrom : applyTimingPoint.volume,
                                                                        false,
                                                                        1));
                                }
                            }
                            break;
                        case 0b0010:
                            // 何もしない
                            break;
                        case 0b0011:
                            // ズレてる緑線のkiaiを外し、始点のタイミングにkiaiが付いた緑線を置く
                            outTimingPoints.First().effect -= 1;
                            outTimingPoints.Add(new TimingPoint(userInputData.timingFrom,
                                                                outTimingPoints.First().bpm,
                                                                outTimingPoints.First().sv,
                                                                outTimingPoints.First().barLength,
                                                                outTimingPoints.First().meter,
                                                                outTimingPoints.First().sampleSet,
                                                                outTimingPoints.First().sampleIndex,
                                                                outTimingPoints.First().volume,
                                                                false,
                                                                1));
                            break;
                    }

                }
                executeCode = 0;
                // 順番を揃える為ソートする
                outTimingPoints = [.. outTimingPoints.OrderBy(otp => otp.time)];
                if (userInputData.setObjectOption.isKiaiEnd)
                {
                    var hitObjectOnTimingFrom = beatmap.hitObjects.FirstOrDefault(tp => tp.time == userInputData.timingTo);
                    if (hitObjectOnTimingFrom != null)
                    {
                        executeCode += 0b0010;
                    }
                    if (offset != 0)
                    {
                        executeCode += 0b0001;
                    }
                    switch (executeCode)
                    {
                        case 0b0000:
                        case 0b0001:
                            if (userInputData.setObjectOption.isTimingEnd)
                            {
                                var applyTimingPoint = beatmap.timingPoints.LastOrDefault(tp => tp.time <= userInputData.timingTo);
                                if (applyTimingPoint != null)
                                {
                                    outTimingPoints.Add(new TimingPoint(userInputData.timingTo,
                                                                        applyTimingPoint.bpm,
                                                                        userInputData.isSv ? userInputData.svTo : applyTimingPoint.sv,
                                                                        applyTimingPoint.barLength,
                                                                        applyTimingPoint.meter,
                                                                        applyTimingPoint.sampleSet,
                                                                        applyTimingPoint.sampleIndex,
                                                                        userInputData.isVolume ? userInputData.volumeTo : applyTimingPoint.volume,
                                                                        false,
                                                                        0));
                                }
                            }
                            break;
                        case 0b0010:
                            outTimingPoints.Last().effect -= 1;
                            break;
                        case 0b0011:
                            outTimingPoints.Add(new TimingPoint(userInputData.timingFrom,
                                                                outTimingPoints.Last().bpm,
                                                                outTimingPoints.Last().sv,
                                                                outTimingPoints.Last().barLength,
                                                                outTimingPoints.Last().meter,
                                                                outTimingPoints.Last().sampleSet,
                                                                outTimingPoints.Last().sampleIndex,
                                                                outTimingPoints.Last().volume,
                                                                false,
                                                                0));
                            break;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// ユーザーが指定した範囲より後にあるスライダーの長さ調整をする
        /// </summary>
        /// <param name="userInputData">ユーザー入力値</param>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="outTimingPoints">適応された緑線</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool AdjustSliderLengthAfterTimingTo(UserInputData userInputData, Beatmap beatmap, ref List<TimingPoint> outTimingPoints)
        {
            // 削除処理をすると上手くスライダーの長さが調整されない
            try
            {
                // 最後に追加されたタイミングポイント
                TimingPoint? addedLastInheritedLine = new();
                // 出力された緑線(ソート済み)
                outTimingPoints = [.. outTimingPoints.OrderBy(otp => otp.time)];
                // 最後に追加されたタイミングポイントを取得する
                // 1msズレ赤線対策で3ms前から探す
                addedLastInheritedLine = outTimingPoints.LastOrDefault(otp => otp.time <= userInputData.timingTo - 3 && (!otp.isRedLine));
                // 最後に追加された赤線がある場合
                if (addedLastInheritedLine != null)
                {
                    var betweenExistingTimingPoint = beatmap.timingPoints.LastOrDefault(tp => (tp.time <= userInputData.timingTo) &&
                                                                                               tp.time > addedLastInheritedLine?.time);
                    // 最後に置いた緑線とTiming(終点)の間にすでに緑線があった場合は
                    // スライダーの調整が必要ないため処理を終了する
                    if (betweenExistingTimingPoint != null)
                    {
                        return true;
                    }
                    for (global::System.Int32 i = 0; i < beatmap.hitObjects.Count; i++)
                    {
                        // ノーツのタイミングがTiming(終点)以前だった場合は何も処理をしない
                        if (beatmap.hitObjects[i].time <= userInputData.timingTo)
                        {
                            continue;
                        }
                        var betweenTiming = beatmap.timingPoints.FirstOrDefault(tp => (tp.time <= beatmap.hitObjects[i].time) &&
                                                                                      (tp.time > beatmap.hitObjects[i - 1].time));
                        if (betweenTiming != null)
                        {
                            // 現地点のノーツと次の地点のノーツの間にTimingPointがあった場合は処理を抜ける
                            break;
                        }
                        if (beatmap.hitObjects[i].noteType == Constants.NoteType.SLIDER)
                        {
                            // スライダーの長さを調整する
                            beatmap.hitObjects[i].sliderLength = beatmap.hitObjects[i].sliderLength *
                                                                 (addedLastInheritedLine.sv / beatmap.hitObjects[i].sv);
                        }
                    }
                    return true;
                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// beatSnap間隔に緑線を適応する
        /// </summary>
        /// <param name="userInputData">ユーザー入力値</param>
        /// <param name="beatmap">譜面情報</param>
        /// <param name="outTimingPoints">適応する緑線の格納先</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool ApplyOnBeatSnaps(UserInputData userInputData, Beatmap beatmap, ref List<TimingPoint> outTimingPoints)
        {
            int kiaiEffect = userInputData.isKiai ? 1 : 0;
            decimal svPerMs = 0;
            decimal volumePerMs = 0;
            int offset = userInputData.isOffset ? userInputData.offset : 0;
            try
            {
                List<TimingPoint> redLineList = beatmap.timingPoints.FindAll(tp => tp.isRedLine);
                decimal rawTimingFrom = BeatmapHelper.GetRawTiming(beatmap.timingPoints, userInputData.timingFrom);
                decimal timingOffset = 0m;
                if (rawTimingFrom == decimal.MinValue)
                {
                    throw new Exception();
                }
                var applyTimingPoint = beatmap.timingPoints.LastOrDefault(tp => (tp.time <= rawTimingFrom) && tp.isRedLine) ?? throw new Exception();
                decimal currentTiming = applyTimingPoint.time;
                decimal beatSnapTiming = 60 / applyTimingPoint.bpm / userInputData.setBeatSnapOption.beatSnap * 1000;
                // timingが指定されたビートスナップ間隔からどれぐらいズレてるか算出する
                while (true)
                {
                    if (currentTiming >= rawTimingFrom)
                    {
                        timingOffset = currentTiming - rawTimingFrom;
                        break;
                    }
                    currentTiming += beatSnapTiming;
                }
                if (userInputData.isSv)
                {
                    // 1msあたりのSVの変化量を求める
                    svPerMs = GetSvPerMs(userInputData.svFrom,
                                         userInputData.svTo,
                                         userInputData.timingFrom,
                                         userInputData.timingTo,
                                         userInputData.calculationCode);
                }
                if (userInputData.isVolume)
                {
                    // 1msあたりのVolumeの変化量を求める
                    volumePerMs = (decimal)(userInputData.volumeTo - userInputData.volumeFrom) /
                                  (decimal)(userInputData.timingTo - userInputData.timingFrom);
                }
                currentTiming = applyTimingPoint.time + timingOffset;
                for (global::System.Int32 i = 0; i < redLineList.Count; i++)
                {
                    if (redLineList[i].time < applyTimingPoint?.time)
                    {
                        continue;
                    }
                    if (redLineList[i].time > userInputData.timingTo)
                    {
                        break;
                    }
                    while (true)
                    {
                        if ((int)currentTiming < userInputData.timingFrom)
                        {
                            currentTiming += beatSnapTiming;
                            continue;
                        }
                        if (userInputData.timingTo < currentTiming)
                        {
                            break;
                        }
                        decimal sv = 1m;
                        int volume = 100;
                        var applyInheritedPoint = beatmap.timingPoints.LastOrDefault(tp => tp.time <= (int)currentTiming) ?? throw new Exception();
                        if (userInputData.isSv)
                        {
                            // 直前のSVを取得する
                            decimal baseSv = applyInheritedPoint != null ? applyInheritedPoint.sv : 1m;
                            // SVを求める
                            sv = applyTimingPoint != null ? CalculateSv(userInputData.svFrom,
                                                                        svPerMs,
                                                                        userInputData.timingFrom,
                                                                        (int)currentTiming,
                                                                        baseSv,
                                                                        userInputData.calculationCode,
                                                                        userInputData.relativeCode,
                                                                        userInputData.relativeBaseSv) *
                                                                        (applyTimingPoint.bpm / applyTimingPoint.bpm) : 120;
                        }
                        else
                        {
                            // 直前のSVを参照する
                            sv = applyTimingPoint != null ? applyTimingPoint.sv : 1m;
                        }
                        if (userInputData.isVolume)
                        {
                            // 音量を求める
                            volume = applyTimingPoint != null ? (int)Math.Floor(CalculateVolume(userInputData.volumeFrom,
                                                                                                volumePerMs,
                                                                                                userInputData.timingFrom,
                                                                                                (int)currentTiming) *
                                                                (applyTimingPoint.volume / applyTimingPoint.bpm)) : 100;
                        }
                        else
                        {
                            // 直前の音量を参照する
                            volume = applyTimingPoint != null ? applyTimingPoint.volume : 100;
                        }
                        if(applyInheritedPoint == null)
                        {
                            return false;
                        }
                        outTimingPoints.Add(new TimingPoint((int)currentTiming - offset,
                                                            applyInheritedPoint.bpm,
                                                            sv,
                                                            applyInheritedPoint.barLength,
                                                            applyInheritedPoint.meter,
                                                            applyInheritedPoint.sampleSet,
                                                            applyInheritedPoint.sampleIndex,
                                                            volume,
                                                            false,
                                                            kiaiEffect));

                        currentTiming += beatSnapTiming;
                        if (i != redLineList.Count - 1)
                        {
                            var currentIndex = 0;
                            if (currentTiming + 1 > redLineList[i + 1].time)
                            {
                                currentIndex = i;
                                if (i != redLineList.Count - 2)
                                {
                                    if (redLineList[i + 2].time - redLineList[i + 1].time < 10)
                                    {
                                        i++;
                                    }
                                }
                                if (applyTimingPoint != null)
                                {
                                    currentTiming = redLineList[i + 1].time +
                                                    timingOffset *
                                                    (applyTimingPoint.bpm /
                                                     redLineList[i + 1].bpm);
                                    beatSnapTiming = 60 / redLineList[i + 1].bpm / userInputData.setBeatSnapOption.beatSnap * 1000;
                                }
                                break;
                            }
                        }
                    }
                }
                // 元から設定されている緑線の削除
                if (!RemoveInferitedPoint(userInputData, beatmap))
                {
                    throw new Exception();
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXCEPTION");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// 計算コードに応じて1msあたりのSVを計算する
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
                                           decimal baseSv,
                                           int calculationCode,
                                           int relativeCode,
                                           decimal relativeBaseSv)
        {
            decimal currentSv = 0m;
            switch (calculationCode)
            {
                case Constants.CALCULATION_ARITHMETIC:
                    currentSv = svFrom + (svPerMs * (currentTiming - timingFrom));
                    break;
                case Constants.CALCULATION_GEOMETRIC:
                    currentSv = svFrom * (decimal)Math.Pow((double)svPerMs, (double)(currentTiming - timingFrom));
                    break;
                default:
                    throw new ArgumentException("Invalid calculation code");
            }
            switch (relativeCode)
            {
                case Constants.RELATIVE_DISABLE:
                    return currentSv;
                case Constants.RELATIVE_MULTIPLY:
                    return (baseSv - relativeBaseSv) * currentSv + relativeBaseSv;
                case Constants.RELATIVE_SUM:
                    return baseSv + currentSv;
                default:
                    throw new ArgumentException("Invalid relative code");
            }
        }
        /// <summary>
        /// 算出した1msあたりのVolumeを元に、指定されたタイミングのVolumeを計算する
        /// </summary>
        /// <param name="volumeFrom">Volume(始点)</param>
        /// <param name="volumePerMs">1msあたりのVolume</param>
        /// <param name="timingFrom">Timing(始点)</param>
        /// <param name="currentTiming">現地点のTiming</param>
        /// <returns>算出したVolume</returns>
        private static decimal CalculateVolume(decimal volumeFrom,
                                               decimal volumePerMs,
                                               int timingFrom,
                                               int currentTiming)
        {
            return volumeFrom + (volumePerMs * (currentTiming - timingFrom));
        }
        //private static bool ResetOriginalTimingPoints(Beatmap beatmap,
        //                                              UserInputData userInputData,
        //                                              int effectCode,
        //                                              decimal volumePerMs)
        //{
        //    try
        //    {
        //        for (global::System.Int32 i = 0; i < beatmap.timingPoints.Count; i++)
        //        {
        //            // もし赤線がTiming(終点)より上回った場合は処理を抜ける
        //            if (beatmap.timingPoints[i].time > userInputData.timingTo)
        //            {
        //                // のちの処理のためにKiai終点判定フラグが有効な場合はエフェクトコードを1に変更する
        //                if (userInputData.isKiaiEnd)
        //                {
        //                    effectCode = 1;
        //                }
        //                break;
        //            }
        //            // もし赤線がTiming(終点)と同じタイミングかつ、
        //            // Kiai終点判定フラグが有効な場合はエフェクトコードを0に変更する(kiaiを無効にする)
        //            if ((beatmap.timingPoints[i].time == userInputData.timingTo) && userInputData.isKiaiEnd)
        //            {
        //                effectCode = 0;
        //            }
        //            if ((beatmap.timingPoints[i].time >= userInputData.timingFrom) &&
        //                (beatmap.timingPoints[i].time <= userInputData.timingTo))
        //            {
        //                if (userInputData.isVolume)
        //                {
        //                    // 指定範囲内に赤線があるかつ、Volume有効化フラグが有効な場合は
        //                    // 赤線に音量を計算し適応する
        //                    beatmap.timingPoints[i].volume = (int)(userInputData.volumeFrom +
        //                                                       (volumePerMs *
        //                                                        (beatmap.timingPoints[i].time -
        //                                                         userInputData.timingFrom)));
        //                }
        //                // kiaiをつける場合はkiai有効化する
        //                beatmap.timingPoints[i].effect += effectCode;
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.WriteExceptionMessage(ex);
        //        return false;
        //    }
        //}
    }
}
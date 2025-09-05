using System.Xml.Serialization;
using osuTaikoSvTool.Models;
using osuTaikoSvTool.Properties;

namespace osuTaikoSvTool.Utils.Helper
{
    /// <summary>
    /// ユーザーが入力したデータを扱うクラス
    /// </summary>
    class UserInputDataHelper
    {
        /// <summary>
        /// ユーザーが入力したデータをXML形式でシリアライズする関数
        /// </summary>
        /// <param name="userInputData">入力データ</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        internal static bool SerializeUserInputData(UserInputData userInputData)
        {
            try
            {
                DateTime date = DateTime.Now;
                // シリアライザーの作成
                XmlSerializer serializer = new(userInputData.GetType());
                using (var sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\" +
                                                 Properties.Constants.HISTORY_DIRECTORY + "\\" +
                                                 "\\history_" +
                                                 userInputData.createDate.ToString("yyyyMMddHHmmssfff") +
                                                 Properties.Constants.XML_EXTENSION,
                                                 false,
                                                 new System.Text.UTF8Encoding(false))) // BOMなしUTF-8
                {
                    // historyディレクトリにシリアライズしたファイルを作成する
                    serializer.Serialize(sw, userInputData);
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-SERIALIZE-XML");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// ユーザーが入力したデータをXML形式からデシリアライズする関数
        /// </summary>
        /// <param name="userInputData">格納先のデータ</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        internal static bool DeserializeUserInputData(ref List<UserInputData> userInputData)
        {
            try
            {
                // 履歴ファイルを探す
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\" +
                                                    Properties.Constants.HISTORY_DIRECTORY, "history_*.xml");
                DateTime date = DateTime.Now;
                // シリアライザーの作成
                XmlSerializer serializer = new(typeof(UserInputData));
                // 履歴ファイルが見つからない場合は
                if (files.Length == 0)
                {
                    return false;
                }
                foreach (var file in files)
                {
                    // 履歴をデシリアライズし、入力値リストに格納する
                    using (var sw = new StreamReader(file,
                                                     new System.Text.UTF8Encoding(false)))
                    {
                        UserInputData? tempUserInputData = (UserInputData?)serializer?.Deserialize(sw);
                        if (tempUserInputData != null)
                        {
                            userInputData?.Add(tempUserInputData);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-DESERIALIZE-XML");
                Common.WriteExceptionMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// 入力値を検証し、UserInputDataを作成する関数
        /// </summary>
        /// <param name="timingFrom">Timing(始点)</param>
        /// <param name="timingTo">Timing(終点)</param>
        /// <param name="isSv">SV有効化フラグ</param>
        /// <param name="svFrom">SV(始点)</param>
        /// <param name="svTo">SV(終点)</param>
        /// <param name="isVolume">Volume有効化フラグ</param>
        /// <param name="volumeFrom">Volume(始点)</param>
        /// <param name="volumeTo">Volume(終点)</param>
        /// <param name="calculationCode">計算コード</param>
        /// <param name="isKiai">Kiai判定フラグ</param>
        /// <param name="relativeCode">相対速度変化コード</param>
        /// <param name="relativeBaseSv">相対速度変化基準SV</param>
        /// <param name="isSvTo">SV終点有効化フラグ</param>
        /// <param name="isOffset">Offset有効化フラグ</param>
        /// <param name="offset">Offset</param>
        /// <param name="isBeatSnap">BeatSnap間隔配置有効化フラグ</param>
        /// <param name="beatSnap">BeatSnap間隔</param>
        /// <param name="isKiaiStart">Kiai始点判定フラグ</param>
        /// <param name="isKiaiEnd">Kiai終点判定フラグ</param>
        /// <param name="excecuteCode">実行コード</param>
        /// <param name="userInputData">検証したデータの格納先</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        internal static bool SetUserInputData(string timingFrom,
                                              string timingTo,
                                              bool isSv,
                                              string svFrom,
                                              string svTo,
                                              bool isVolume,
                                              string volumeFrom,
                                              string volumeTo,
                                              int calculationCode,
                                              bool isKiai,
                                              int relativeCode,
                                              string relativeBaseSv,
                                              bool isSvTo,
                                              bool isOffset,
                                              string offset,
                                              bool isSetObject,
                                              bool isSetBeatSnap,
                                              int setObjectCode,
                                              bool isKiaiStart,
                                              bool isKiaiEnd,
                                              bool isTimingStart,
                                              bool isTimingEnd,
                                              bool isBeatSnap,
                                              string beatSnap,
                                              int excecuteCode,
                                              ref UserInputData? userInputData)
        {
            int retTimingFrom = -1;
            int retTimingTo = -1;
            decimal retSvFrom = -1m;
            decimal retSvTo = -1m;
            int retVolumeFrom = -1;
            int retVolumeTo = -1;
            int retOffset = 0;
            int retBeatSnap = -1;
            decimal retRlativeBaseSv = -1m;
            DateTime date = DateTime.Now;
            try
            {
                // Timingのバリデーションチェック
                if (!ValidateTiming(timingFrom,
                                    timingTo,
                                    ref retTimingFrom,
                                    ref retTimingTo))
                {
                    throw new Exception();
                }
                // 実行コードが適応の場合は
                // SV.Volume,Beatsnap間隔のバリデーションチェックを行う
                if (excecuteCode == Properties.Constants.EXECUTE_APPLY)
                {
                    if (!ValidateSv(svFrom,
                                    svTo,
                                    isSv,
                                    calculationCode,
                                    relativeCode,
                                    isSvTo,
                                    ref retSvFrom,
                                    ref retSvTo) ||
                        !ValidateVolume(volumeFrom,
                                        volumeTo,
                                        isVolume,
                                        ref retVolumeFrom,
                                        ref retVolumeTo) ||
                        !ValidateBeatSnap(beatSnap,
                                          isBeatSnap,
                                          ref retBeatSnap) ||
                        !ValidateRelativeBaseSv(relativeBaseSv,
                                                relativeCode,
                                                ref retRlativeBaseSv))
                    {
                        throw new Exception();
                    }

                    // SV有効化フラグが有効かつ、計算コードが指定されていない場合は
                    // エラーダイアログを出力する
                    if ((calculationCode == 0) && isSv)
                    {
                        //計算方法が指定されていない
                        Common.ShowMessageDialog("E_V-EM-005");
                        throw new Exception();
                    }
                    // 特定のヒットオブジェクトのみ有効化フラグが有効かつ、
                    // 特定のヒットオブジェクトが指定されていない場合は
                    // すべてのHitObjectを対象とする
                    if (setObjectCode == 0)
                    {
                        setObjectCode = 0x0000017f;
                    }
                }
                // offsetのバリデーションチェックを行う
                if (!ValidateOffset(offset,
                                    isOffset,
                                    ref retOffset))
                {
                    throw new Exception();
                }

                // 入力値クラスのインスタンスを作成する
                userInputData = new UserInputData(retTimingFrom,
                                                  retTimingTo,
                                                  isSv,
                                                  retSvFrom,
                                                  retSvTo,
                                                  isVolume,
                                                  retVolumeFrom,
                                                  retVolumeTo,
                                                  calculationCode,
                                                  isKiai,
                                                  relativeCode,
                                                  retRlativeBaseSv,
                                                  isOffset,
                                                  retOffset,
                                                  isSetObject,
                                                  isSetBeatSnap,
                                                  setObjectCode,
                                                  isKiaiStart,
                                                  isKiaiEnd,
                                                  isTimingStart,
                                                  isTimingEnd,
                                                  isBeatSnap,
                                                  retBeatSnap,
                                                  date);
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-GET-INPUT");
                Common.WriteExceptionMessage(ex);
                return false;
            }


        }
        /// <summary>
        /// Timingのバリデーションチェックをする関数
        /// </summary>
        /// <param name="timingFrom">Timing(始点)</param>
        /// <param name="timingTo">Timing(終点)</param>
        /// <param name="retTimingFrom">チェック後のTiming(始点)</param>
        /// <param name="retTimingTo">チェック後のTiming(終点)</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool ValidateTiming(string timingFrom,
                                           string timingTo,
                                           ref int retTimingFrom,
                                           ref int retTimingTo)
        {
            try
            {
                if ((timingFrom == string.Empty) || (timingTo == string.Empty))
                {
                    //タイミングの入力がない
                    Common.ShowMessageDialog("E_V-EM-001");
                    return false;
                }
                if (!Common.ConvertMsTiming(timingFrom, ref retTimingFrom) || !Common.ConvertMsTiming(timingTo, ref retTimingTo))
                {
                    //タイミングのフォーマットが間違えている
                    Common.ShowMessageDialog("E_V-C-001");
                    return false;
                }
                if (retTimingFrom > retTimingTo)
                {
                    //タイミングの開始位置が終了位置より大きい
                    Common.ShowMessageDialog("E_V-C-002");
                    return false;
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
        /// SVのバリデーションチェックをする関数
        /// </summary>
        /// <param name="svFrom">SV(始点)</param>
        /// <param name="svTo">SV(終点)</param>
        /// <param name="isSv">SV有効化フラグ</param>
        /// <param name="calculationCode">計算コード</param>
        /// <param name="relativeCode">相対速度変化コード</param>
        /// <param name="isSvTo">SV終点有効化フラグ</param>
        /// <param name="retSvFrom">チェック後のSV(始点)</param>
        /// <param name="retSvTo">チェック後のSV(終点)</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool ValidateSv(string svFrom,
                                       string svTo,
                                       bool isSv,
                                       int calculationCode,
                                       int relativeCode,
                                       bool isSvTo,
                                       ref decimal retSvFrom,
                                       ref decimal retSvTo)
        {
            try
            {
                if (!isSv)
                {
                    //SV有効化フラグが有効ではない
                    retSvFrom = -1;
                    retSvTo = -1;
                    return true;
                }
                if (!isSvTo)
                {
                    svTo = svFrom;
                }
                if (((svFrom == string.Empty) || (svTo == string.Empty)))
                {
                    //SVの入力がない
                    Common.ShowMessageDialog("E_V-EM-002");
                    return false;
                }
                if (!decimal.TryParse(svFrom, out retSvFrom) || !decimal.TryParse(svTo, out retSvTo))
                {
                    //SVのフォーマットが間違えている
                    Common.ShowMessageDialog("E_V-T-001");
                    return false;
                }
                switch (relativeCode)
                {
                    case Constants.RELATIVE_DISABLE:
                        // 相対速度変化オプションが無効の場合は
                        // SVがosu側で指定できる範囲内かチェックする
                        if (((retSvFrom < 0.01m) || (retSvFrom > 10m) || (retSvTo < 0.01m) || (retSvTo > 10m)))
                        {
                            retSvFrom = -1m;
                            retSvTo = -1m;
                            // SVがosu側で指定できる範囲外の値
                            Common.ShowMessageDialog("E_V-C-003");
                            return false;
                        }
                        break;
                    case Constants.RELATIVE_SUM:
                        // 相対速度変化オプションが加算の場合は
                        // SVがosu側で指定できる範囲内かチェックする
                        if (((retSvFrom <= -10m) || (retSvFrom >= 10m) || (retSvTo <= -10m) || (retSvTo >= 10m)))
                        {
                            retSvFrom = -1m;
                            retSvTo = -1m;
                            // SVがosu側で指定できる範囲外の値
                            Common.ShowMessageDialog("E_V-C-003");
                            return false;
                        }
                        break;
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
        /// Volumeのバリデーションチェックをする関数
        /// </summary>
        /// <param name="volumeFrom">Volume(始点)</param>
        /// <param name="volumeTo">Volume(終点)</param>
        /// <param name="isVolume">Volume有効化フラグ</param>
        /// <param name="retVolumeFrom">チェック後のVolume(始点)</param>
        /// <param name="retVolumeTo">チェック後のVolume(終点)</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool ValidateVolume(string volumeFrom,
                                           string volumeTo,
                                           bool isVolume,
                                           ref int retVolumeFrom,
                                           ref int retVolumeTo)
        {
            try
            {
                if (!isVolume)
                {
                    //Volume有効化フラグが有効ではない
                    retVolumeFrom = -1;
                    retVolumeTo = -1;
                    return true;
                }
                if ((volumeFrom == string.Empty) || (volumeTo == string.Empty))
                {
                    //Volumeの入力がない
                    Common.ShowMessageDialog("E_V-EM-003");
                    return false;
                }
                if (!int.TryParse(volumeFrom, out retVolumeFrom) || !int.TryParse(volumeTo, out retVolumeTo))
                {
                    //Volumeのフォーマットが間違えている
                    Common.ShowMessageDialog("E_V-T-002");
                    return false;
                }
                if ((retVolumeFrom < 5) || (retVolumeFrom > 100) ||
                    (retVolumeTo < 5) || (retVolumeTo > 100))
                {
                    retVolumeFrom = -1;
                    retVolumeTo = -1;
                    //Volumeがosu側で指定できる範囲外の値
                    Common.ShowMessageDialog("E_V-C-006");
                    return false;
                }
                // osu側で指定できるVolumeの範囲内の場合はバリデーションチェックを完了する
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
        /// Offsetのバリデーションチェックをする関数
        /// </summary>
        /// <param name="offset">Offset</param>
        /// <param name="isOffset">Offset有効化フラグ</param>
        /// <param name="retOffset">チェック後のOffset</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool ValidateOffset(string offset,
                                           bool isOffset,
                                           ref int retOffset)
        {
            try
            {
                if (!isOffset)
                {
                    //Offset有効化フラグが有効ではない
                    retOffset = 0;
                    return true;
                }
                if (offset == string.Empty)
                {
                    //Offsetが指定されていない
                    retOffset = 0;
                    return true;
                }
                if (!int.TryParse(offset, out retOffset))
                {
                    //Offsetのフォーマットが間違えている
                    Common.ShowMessageDialog("E_V-T-003");
                    return false;
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
        /// 基礎SVのバリデーションチェックをする関数
        /// </summary>
        /// <param name="relativeBaseSv">基礎SV</param>
        /// <param name="relativeCode">相対速度オプションコード</param>
        /// <param name="retRelativeBaseSv">チェック後の基礎SV</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool ValidateRelativeBaseSv(string relativeBaseSv,
                                                   int relativeCode,
                                                   ref decimal retRelativeBaseSv)
        {
            try
            {
                if (relativeCode == Constants.RELATIVE_MULTIPLY)
                {
                    if (!decimal.TryParse(relativeBaseSv, out retRelativeBaseSv))
                    {
                        //基礎SVのフォーマットが間違えている
                        Common.ShowMessageDialog("E_V-T-003");
                        return false;
                    }
                    if (retRelativeBaseSv < 0 || retRelativeBaseSv > 10)
                    {
                        //基礎SVのフォーマットが間違えている
                        Common.ShowMessageDialog("E_V-T-003");
                        return false;
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
        /// BeatSnapのバリデーションチェックをする関数
        /// </summary>
        /// <param name="beatSnap">BeatSnap</param>
        /// <param name="isBeatSnap">BeatSnap間隔配置有効化フラグ</param>
        /// <param name="retBeatSnap">チェック後のBeatSnap</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        private static bool ValidateBeatSnap(string beatSnap,
                                             bool isBeatSnap,
                                             ref int retBeatSnap)
        {
            try
            {
                if (!isBeatSnap)
                {
                    retBeatSnap = -1;
                    return true;
                }
                if (beatSnap == string.Empty)
                {
                    //ビートスナップ間隔が空欄
                    Common.ShowMessageDialog("E_V-EM-004");
                    return false;
                }
                if (!int.TryParse(beatSnap, out retBeatSnap))
                {
                    //ビートスナップ間隔が整数ではない
                    Common.ShowMessageDialog("E_V-T-004");
                    return false;
                }
                if (retBeatSnap <= 0)
                {
                    //ビートスナップ間隔が0以下の整数
                    Common.ShowMessageDialog("E_V-T-004");
                    return false;
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
    }
}

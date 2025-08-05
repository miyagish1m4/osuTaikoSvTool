using osuTaikoSvTool.Models;

namespace osuTaikoSvTool.Utils.Helper
{
    class UserInputDataHelper
    {
        /// <summary>
        /// 入力値を元にUserInputDataを生成する関数
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
        /// <param name="isIncludeBarline">小節線含有フラグ</param>
        /// <param name="isOffset">Offset有効化フラグ</param>
        /// <param name="offset">Offset</param>
        /// <param name="isBeatSnap">BeatSnap間隔配置有効化フラグ</param>
        /// <param name="beatSnap">BeatSnap間隔</param>
        /// <param name="isKiai">Kiai判定フラグ</param>
        /// <param name="isKiaiStart">Kiai始点判定フラグ</param>
        /// <param name="isKiaiEnd">Kiai終点判定フラグ</param>
        /// <param name="isOnlyBarline">小節線のみ有効化フラグ</param>
        /// <param name="isOnlyBookmark">ブックマークのみ有効化フラグ</param>
        /// <param name="isOnlyHitObject">特定のオブジェクトのみ有効化フラグ</param>
        /// <param name="OnlyHitObjectCode">特定のオブジェクトコード</param>
        /// <returns>作成したUserInputData</returns>
        internal static UserInputData GetUserInputData(string timingFrom,
                                                       string timingTo,
                                                       bool isSv,
                                                       string svFrom,
                                                       string svTo,
                                                       bool isVolume,
                                                       string volumeFrom,
                                                       string volumeTo,
                                                       int calculationCode,
                                                       bool isIncludeBarline,
                                                       bool isOffset,
                                                       string offset,
                                                       bool isBeatSnap,
                                                       string beatSnap,
                                                       bool isKiai,
                                                       bool isKiaiStart,
                                                       bool isKiaiEnd,
                                                       bool isOnlyBarline,
                                                       bool isOnlyBookmark,
                                                       bool isOnlyHitObject,
                                                       int OnlyHitObjectCode)
        {
            int retTimingFrom = -1;
            int retTimingTo = -1;
            decimal retSvFrom = -1m;
            decimal retSvTo = -1m;
            int retVolumeFrom = -1;
            int retVolumeTo = -1;
            int retOffset = Int32.MinValue;
            int retBeatSnap = -1;

            UserInputData userInputData = null;
            try
            {
                if (!validateTiming(timingFrom,
                                    timingTo,
                                    ref retTimingFrom,
                                    ref retTimingTo) ||
                    !validateSv(svFrom,
                                svTo,
                                isSv,
                                ref retSvFrom,
                                ref retSvTo) ||
                    !validateVolume(volumeFrom,
                                    volumeTo,
                                    isVolume,
                                    ref retVolumeFrom,
                                    ref retVolumeTo) ||
                    !validateOffset(offset,
                                    isOffset,
                                    ref retOffset) ||
                    !validateBeatSnap(beatSnap, 
                                      isBeatSnap, 
                                      ref retBeatSnap))
                {
                    throw new Exception();
                }
                return new UserInputData(retTimingFrom,
                                         retTimingTo,
                                         isSv,
                                         retSvFrom,
                                         retSvTo,
                                         isVolume,
                                         retVolumeFrom,
                                         retVolumeTo,
                                         calculationCode,
                                         isIncludeBarline,
                                         isOffset,
                                         retOffset,
                                         isBeatSnap,
                                         retBeatSnap,
                                         isKiai,
                                         isKiaiStart,
                                         isKiaiEnd,
                                         isOnlyBarline,
                                         isOnlyBookmark,
                                         isOnlyHitObject,
                                         OnlyHitObjectCode);

            }
            catch (Exception ex)
            {
                return null;
            }


        }
        /// <summary>
        /// Timingのバリデーションチェックをする関数
        /// </summary>
        /// <param name="timingFrom">Timing(始点)</param>
        /// <param name="timingTo">Timing(終点)</param>
        /// <param name="retTimingFrom">チェック後のTiming(始点)</param>
        /// <param name="retTimingTo">チェック後のTiming(終点)</param>
        /// <returns></returns>
        private static bool validateTiming(string timingFrom,
                                           string timingTo,
                                           ref int retTimingFrom,
                                           ref int retTimingTo)
        {
            try
            {
                if ((timingFrom != string.Empty) || (timingTo != string.Empty))
                {
                    if (Common.ConvertTiming(timingFrom, ref retTimingFrom) && Common.ConvertTiming(timingTo, ref retTimingTo))
                    {
                        if (retTimingFrom > retTimingTo)
                        {
                            //タイミングの開始位置が終了位置より大きい
                            MessageBox.Show(Common.WriteDialogMessage("E-007"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        //タイミングのフォーマットが間違えている
                        MessageBox.Show(Common.WriteDialogMessage("E-006"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    //タイミングの入力がない
                    MessageBox.Show(Common.WriteDialogMessage("E-005"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG-ERROR-EXCEPTION");
                Common.WriteErrorMessage(ex.Message + "\n" + ex.StackTrace);
                MessageBox.Show(Common.WriteDialogMessage("E-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        /// <summary>
        /// SVのバリデーションチェックをする関数
        /// </summary>
        /// <param name="svFrom">SV(始点)</param>
        /// <param name="svTo">SV(終点)</param>
        /// <param name="isSv">SV有効化フラグ</param>
        /// <param name="retSvFrom">チェック後のSV(始点)</param>
        /// <param name="retSvTo">チェック後のSV(終点)</param>
        /// <returns></returns>
        private static bool validateSv(string svFrom,
                                       string svTo,
                                       bool isSv,
                                       ref decimal retSvFrom,
                                       ref decimal retSvTo)
        {
            try
            {
                if (isSv)
                {
                    if ((svFrom != string.Empty) || (svTo != string.Empty))
                    {
                        if (decimal.TryParse(svFrom, out retSvFrom) && decimal.TryParse(svTo, out retSvTo))
                        {
                            if ((retSvFrom > 0m) && (retSvTo > 0m))
                            {
                                return true;
                            }
                            else
                            {
                                retSvFrom = -1m;
                                retSvTo = -1m;
                                //SVが負の値
                                MessageBox.Show(Common.WriteDialogMessage("E-009"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            //SVのフォーマットが間違えている
                            MessageBox.Show(Common.WriteDialogMessage("E-009"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        //SVの入力がない
                        MessageBox.Show(Common.WriteDialogMessage("E-008"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    retSvFrom = -1;
                    retSvTo = -1;
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG-ERROR-EXCEPTION");
                Common.WriteErrorMessage(ex.Message + "\n" + ex.StackTrace);
                MessageBox.Show(Common.WriteDialogMessage("E-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// <returns></returns>
        private static bool validateVolume(string volumeFrom,
                                           string volumeTo,
                                           bool isVolume,
                                           ref int retVolumeFrom,
                                           ref int retVolumeTo)
        {
            try
            {
                if (isVolume)
                {
                    if ((volumeFrom != string.Empty) || (volumeTo != string.Empty))
                    {
                        if (int.TryParse(volumeFrom, out retVolumeFrom) && int.TryParse(volumeTo, out retVolumeTo))
                        {
                            if ((retVolumeFrom > 0) && (retVolumeTo > 0))
                            {
                                return true;
                            }
                            else
                            {
                                retVolumeFrom = -1;
                                retVolumeTo = -1;
                                //Volumeが負の値
                                MessageBox.Show(Common.WriteDialogMessage("E-011"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            //Volumeのフォーマットが間違えている
                            MessageBox.Show(Common.WriteDialogMessage("E-011"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        //Volumeの入力がない
                        MessageBox.Show(Common.WriteDialogMessage("E-010"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    retVolumeFrom = -1;
                    retVolumeTo = -1;
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG-ERROR-EXCEPTION");
                Common.WriteErrorMessage(ex.Message + "\n" + ex.StackTrace);
                MessageBox.Show(Common.WriteDialogMessage("E-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        /// <summary>
        /// Offsetのバリデーションチェックをする関数
        /// </summary>
        /// <param name="offset">Offset</param>
        /// <param name="isOffset">Offset有効化フラグ</param>
        /// <param name="retOffset">チェック後のOffset</param>
        /// <returns></returns>
        private static bool validateOffset(string offset,
                                           bool isOffset,
                                           ref int retOffset)
        {
            try
            {
                if (isOffset)
                {
                    if (offset != string.Empty)
                    {
                        if (int.TryParse(offset, out retOffset))
                        {
                            return true;
                        }
                        else
                        {
                            //Offsetのフォーマットが間違えている
                            MessageBox.Show(Common.WriteDialogMessage("E-012"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        retOffset = 0;
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG-ERROR-EXCEPTION");
                Common.WriteErrorMessage(ex.Message + "\n" + ex.StackTrace);
                MessageBox.Show(Common.WriteDialogMessage("E-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        /// <summary>
        /// BeatSnapのバリデーションチェックをする関数
        /// </summary>
        /// <param name="beatSnap">BeatSnap</param>
        /// <param name="isBeatSnap">BeatSnap間隔配置有効化フラグ</param>
        /// <param name="retBeatSnap">チェック後のBeatSnap</param>
        /// <returns></returns>
        private static bool validateBeatSnap(string beatSnap,
                                             bool isBeatSnap,
                                             ref int retBeatSnap)
        {
            try
            {
                if (isBeatSnap)
                {
                    if (beatSnap != string.Empty)
                    {

                        if (int.TryParse(beatSnap, out retBeatSnap))
                        {
                            if (retBeatSnap > 0)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            //ビートスナップ間隔は正の整数(0除く)を指定してください。
                            MessageBox.Show(Common.WriteDialogMessage("E-014"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        //ビートスナップ間隔を指定してください。
                        MessageBox.Show(Common.WriteDialogMessage("E-013"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    return true;
                }
                else
                {
                    retBeatSnap = -1;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG-ERROR-EXCEPTION");
                Common.WriteErrorMessage(ex.Message + "\n" + ex.StackTrace);
                MessageBox.Show(Common.WriteDialogMessage("E-001"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}

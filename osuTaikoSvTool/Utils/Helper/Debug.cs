using osuTaikoSvTool.Properties;
using osuTaikoSvTool.Models;
using System.Text;

namespace osuTaikoSvTool.Utils.Helper
{
    /// <summary>
    /// デバッグ用のメソッドを集約したクラス
    /// </summary>
    internal class Debug
    {
        /// <summary>
        /// TimingPointsのCSVファイル出力処理
        /// </summary>
        /// <param name="beatmap">譜面データ</param>
        /// <param name="backupDirectory">バックアップフォルダ</param>
        /// <returns>処理が<br/>・正常終了した場合はtrue<br/>・異常終了した場合はfalse</returns>
        internal static bool ExportToCsvFile(Beatmap beatmap, string backupDirectory)
        {
            string path = Directory.GetCurrentDirectory() + Constants.BACKUP_DIRECTORY + "\\" + backupDirectory;
            DateTime now = DateTime.Now;
            string backupFileName = $"{now:yyyy_MM_dd_HH_mm_ss_fff}.csv";
            // バックアップフォルダがない場合は作成する
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            StreamWriter file = new(path + "\\" + backupFileName, false, Encoding.GetEncoding("utf-8"));
            beatmap.timingPoints = [.. beatmap.timingPoints.OrderBy(a => a.time).ThenByDescending(b => b.isRedLine ? 1 : 0)];
            string Header = "time,bpm,sv,barLength,meter,sampleSet,sampleIndex,volume,isRedLine,effect";
            // ヘッダーを書き込む
            file.WriteLine(Header);
            try
            {
                // データを書き込む
                foreach (var timingPoint in beatmap.timingPoints)
                {

                    string timingPointLine = timingPoint.time + "," +
                                             timingPoint.bpm + "," +
                                             timingPoint.sv + "," +
                                             timingPoint.barLength + "," +
                                             timingPoint.meter + "," +
                                             timingPoint.sampleSet + "," +
                                             timingPoint.sampleIndex + "," +
                                             timingPoint.volume + "," +
                                             (timingPoint.isRedLine ? "1" : "0") + "," +
                                             timingPoint.effect;
                    file.WriteLine(timingPointLine);
                }
            }
            catch (Exception ex)
            {
                Common.WriteErrorMessage("LOG_E-EXPORT-OSU");
                Common.WriteExceptionMessage(ex);
                return false;
            }
            finally
            {
                // いかなる場合でもファイルを閉じる
                file.Close();
            }
            return true;
        }
    }
}

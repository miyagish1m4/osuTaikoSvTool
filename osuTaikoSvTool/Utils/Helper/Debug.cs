using osuTaikoSvTool.Properties;
using osuTaikoSvTool.Models;
using System.Text;
using System.Linq;

namespace osuTaikoSvTool.Utils.Helper
{
    internal class Debug
    {
        internal static bool ExportToCsvFile(Beatmap beatmap, string backupDirectory)
        {
            string path = Directory.GetCurrentDirectory() + Constants.BACKUP_DIRECTORY + "\\" + backupDirectory;
            DateTime now = DateTime.Now;
            string backupFileName = $"{now:yyyy_MM_dd_HH_mm_ss_fff}.csv";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            StreamWriter file = new StreamWriter(path + "\\" + backupFileName, false, Encoding.GetEncoding("utf-8"));
            beatmap.timingPoints = beatmap.timingPoints.OrderBy(a => a.time).ThenByDescending(b => b.isRedLine ? 1 : 0).ToList();
            string Header = "time,bpm,sv,barLength,meter,sampleSet,sampleIndex,volume,isRedLine,effect";
            file.WriteLine(Header);
            try
            {
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
                file.Close();
            }
            return true;
        }
    }
}

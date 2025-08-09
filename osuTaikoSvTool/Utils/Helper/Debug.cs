using osuTaikoSvTool.Properties;
using osuTaikoSvTool.Models;
using System.Text;
using System.Linq;

namespace osuTaikoSvTool.Utils.Helper
{
    internal class Debug
    {
        internal static bool ExportToCsvFile(Beatmap beatmap, string beatmapPath)
        {
            StreamWriter file = new StreamWriter(beatmapPath.Replace(".osu", ".csv"), false, Encoding.GetEncoding("utf-8"));
            try
            {
                beatmap.timingPoints = beatmap.timingPoints.OrderBy(a => a.time).ThenByDescending(b => b.isRedLine ? 1 : 0).ToList();
                string Header = "time,bpm,sv,barLength,meter,sampleSet,sampleIndex,volume,isRedLine,effect";
                file.WriteLine(Header);
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

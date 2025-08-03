using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuTaikoSvTool
{
    internal class Constants
    {
        internal enum NoteType
        {
            BARLINE,
            CIRCLE,
            SLIDER,
            SPINNER
        }
        const string BACKUP_DIRECTORY = "\\BackUp";
        const string WORK_DIRECTORY = "\\Work";
        const string INFO_MESSAGE_DIRECTORY = "\\Log\\Info";
        const string ERROR_MESSAGE_DIRECTORY = "\\Log\\Error";
        const string HISTORY_DIRECTORY = "\\History";
        const string BEATMAP_EXTENSION = ".osu";
        const string LOG_EXTENSION = ".log";
    }
}

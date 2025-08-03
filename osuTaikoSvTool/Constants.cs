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
        internal const string BACKUP_DIRECTORY = "\\BackUp";
        internal const string WORK_DIRECTORY = "\\Work";
        internal const string INFO_MESSAGE_DIRECTORY = "\\Log\\Info";
        internal const string ERROR_MESSAGE_DIRECTORY = "\\Log\\Error";
        internal const string HISTORY_DIRECTORY = "\\History";
        internal const string BEATMAP_EXTENSION = ".osu";
        internal const string LOG_EXTENSION = ".log";
    }
}

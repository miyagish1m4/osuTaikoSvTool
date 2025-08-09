using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuTaikoSvTool.Models
{
    internal class Bookmarks : TimingPoint
    {
        internal Bookmarks(int time)
        {
            this.time = time;
            this.sv = -1;
        }
    }
}

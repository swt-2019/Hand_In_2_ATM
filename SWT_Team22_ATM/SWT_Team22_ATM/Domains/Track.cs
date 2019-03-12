using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Team22_ATM.Domains
{
    public class Track : ITrack
    {
        public Position TrackPosition { get; set; }
        public string Tag { get; set; }
        public string TimeStamp { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Team22_ATM.Domains
{
    public class Track : ITrack
    {
        private int _course;
        public Position TrackPosition { get; set; }
        public string Tag { get; set; }
        public string TimeStamp { get; set; }
        public double Speed { get; set; }
        public int Course { get => _course; set => _course = value>=0 && value < 360 ? value : _course; }
    }
}

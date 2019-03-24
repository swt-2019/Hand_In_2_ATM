using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.interpreter
{
    public class TrackListEventArgs : EventArgs
    {
        public List<ITrack> Tracks { get; set; }
    }
}

using SWT_Team22_ATM.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Team22_ATM.interpreter
{
    public interface ITrackListEvent
    {
        event EventHandler<TrackListEventArgs> TrackListEventHandler;
    }
}

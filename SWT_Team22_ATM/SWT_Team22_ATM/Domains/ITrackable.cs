using System.Collections.Generic;

namespace SWT_Team22_ATM.Domains
{
    public interface ITrackable
    {
        List<ITrack> Trackables { get; set; }
    }
}
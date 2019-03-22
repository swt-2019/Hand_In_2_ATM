using System;
using System.Collections.Generic;

namespace SWT_Team22_ATM.Domains
{
    public interface ITrackable
    {
        int HorizontalSize { get; set; }
        int VerticalStart { get; set; }
        int VerticalEnd { get; set; }
        List<ITrack> Trackables { get; set; }
        Position AirspacePosition { get; set; }
    }
}
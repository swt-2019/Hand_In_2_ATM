using System.Collections.Generic;

namespace SWT_Team22_ATM.Domains
{
    public class Airspace : ITrackable
    {
        public Position AirspacePosition { get; set; }
        public int HorizontalSize { get; set; }
        public int VerticalStart { get; set; }
        public int VerticalEnd { get; set; }
        public List<ITrack> Trackables { get; set; } = new List<ITrack>();
    }
}
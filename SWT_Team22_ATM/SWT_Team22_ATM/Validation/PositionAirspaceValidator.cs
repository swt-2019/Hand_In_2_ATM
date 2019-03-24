using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.Validation
{
    public class PositionAirspaceValidator : IValidator
    {
        public ITrack Track { get; set; }
        public ITrackable Trackable { get; set; }

        public bool Validate(ITrack track, ITrackable airspace)
        {
            Track = track;
            Trackable = airspace;
            return IsTrackInAirspace();
        }

        public bool IsTrackInAirspace()
        {
            return IsTrackXCoordinateInAirspaceArea() && IsTrackYCoordinateInAirspaceArea() && IsTrackZCoordinateInAirspaceArea();
        }

        public bool IsTrackXCoordinateInAirspaceArea()
        {
            return Track.TrackPosition.XCoordinate < Trackable.HorizontalSize && (Track.TrackPosition.XCoordinate > Trackable.AirspacePosition.XCoordinate);
        }

        public bool IsTrackYCoordinateInAirspaceArea()
        {
            return Track.TrackPosition.YCoordinate < Trackable.HorizontalSize && (Track.TrackPosition.YCoordinate > Trackable.AirspacePosition.YCoordinate);
        }

        public bool IsTrackZCoordinateInAirspaceArea()
        {
            return Track.TrackPosition.ZCoordinate > Trackable.VerticalStart &&
                   (Track.TrackPosition.ZCoordinate < Trackable.VerticalEnd);
        }
    }
}

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
        public ITrack Track { get=>_track; set => _track = value; }
        public ITrackable Trackable { get=>_airspace; set=>_airspace =value; }
        private ITrack _track;
        private ITrackable _airspace;

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
            return _track.TrackPosition.XCoordinate < _airspace.HorizontalSize && (_track.TrackPosition.XCoordinate > _airspace.AirspacePosition.XCoordinate);
        }

        public bool IsTrackYCoordinateInAirspaceArea()
        {
            return _track.TrackPosition.YCoordinate < _airspace.HorizontalSize && (_track.TrackPosition.YCoordinate > _airspace.AirspacePosition.YCoordinate);
        }

        public bool IsTrackZCoordinateInAirspaceArea()
        {
            return _track.TrackPosition.ZCoordinate > _airspace.VerticalStart &&
                   (_track.TrackPosition.ZCoordinate < _airspace.VerticalEnd);
        }
    }
}

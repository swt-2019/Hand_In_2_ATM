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
        private ITrack _track;
        private ITrackable _airspace;

        public bool Validate(ITrack track, ITrackable airspace)
        {
            _track = track;
            _airspace = airspace;
            return IsTrackInAirspace();
        }

        private bool IsTrackInAirspace()
        {

            return IsTrackXCoordinateInAirspaceArea() & IsTrackYCoordinateInAirspaceArea();
        }

        private bool IsTrackXCoordinateInAirspaceArea()
        {
            return _track.TrackPosition.XCoordinate < _airspace.AirspacePosition.XCoordinate &&
                   _track.TrackPosition.XCoordinate > _airspace.AirspacePosition.XCoordinate;
        }

        private bool IsTrackYCoordinateInAirspaceArea()
        {
            return _track.TrackPosition.YCoordinate < _airspace.AirspacePosition.YCoordinate &&
                   _track.TrackPosition.YCoordinate > _airspace.AirspacePosition.YCoordinate;
        }
    }
}

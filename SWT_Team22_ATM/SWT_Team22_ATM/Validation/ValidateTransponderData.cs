using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.interpreter;
using SWT_Team22_ATM.Monitors;
using SWT_Team22_ATM.Validation;
using TransponderReceiver;

namespace SWT_Team22_ATM.Validation
{
    public class ValidateTransponderData : ITrafficMonitor, IValidateEvent
    {
        private readonly PositionAirspaceValidator _airspaceValidator = new PositionAirspaceValidator();
        private readonly TrackAirspaceValidator _trackAirspaceValidator = new TrackAirspaceValidator();

        public event EventHandler<ValidateEventArgs> ValidationCompleteEventHandler;

        public ValidateTransponderData(ITrackable airspace)
        {
            Airspace = airspace;
        }

        public ValidateTransponderData(ref EventHandler<TrackListEventArgs> trackListEventHandler)
        {
            trackListEventHandler += OnNewValidation;
        }

        private void OnNewValidation(object sender, TrackListEventArgs e)
        {
            foreach (var track in e.Tracks)
            {
                if (_airspaceValidator.Validate(track, Airspace).Equals(false))// checks if tracks are in airspace. false -> remove track
                {
                    e.Tracks.Remove(track);
                }
            }

            foreach (var track in e.Tracks)//in the tracks IN airspace, are we already tracking them or not? Not tracking, add them
            {
                if (_trackAirspaceValidator.Validate(track, Airspace).Equals(false))
                {
                    Airspace.Trackables.Add(track);
                }
            }

            ValidationCompleteEventHandler += Update;

        }

        public ITrackable Airspace { get; set; }
        public void Update(object sender, ValidateEventArgs e)
        {
            ValidationCompleteEventHandler?.Invoke(this, e);
        }

    }
}

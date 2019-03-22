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
    public class ValidateTransponderData : IValidateEvent
    {
        private readonly IValidator _airspaceValidator = new PositionAirspaceValidator();
        private readonly IValidator _trackAirspaceValidator = new TrackAirspaceValidator();

        public event EventHandler<ValidateEventArgs> ValidationCompleteEventHandler;

        public ITrackable Airspace;

        public ValidateTransponderData(ITrackable airspace)// burde måske samle de 2 constructors
        {
            Airspace = airspace;
        }

        public ValidateTransponderData(ref EventHandler<TrackListEventArgs> trackListEventHandler) // denne
        {
            trackListEventHandler += OnNewValidation;
        }

        public void OnNewValidation(object sender, TrackListEventArgs e)
        {

            var validateEventArgs = new ValidateEventArgs();
            
            foreach (var track in e.Tracks)
            {
                var isInAirspace = _airspaceValidator.Validate(track, Airspace);// checks if tracks are in airspace. false -> remove track
                var hasBeenInAirspace = _trackAirspaceValidator.Validate(track, Airspace);// check if track already us tracked
                if (HasBeenAndIsStillInAirspace(hasBeenInAirspace, isInAirspace))
                {
                    validateEventArgs.StillInAirspace.Add(track);// has been and still is
                }
                else if (HasNotBeenButIsInAirspace(hasBeenInAirspace,isInAirspace))
                {
                    validateEventArgs.NewInAirspace.Add(track);// has not been, but is now
                }
                else if(HasBeenInAirspaceButIsNotAnymore(hasBeenInAirspace,isInAirspace))
                {
                    validateEventArgs.NotInAirspaceButUsedToBe.Add(track);// has been there but is not anymore 
                }
            }

            ValidationCompleteEventHandler?.Invoke(this, validateEventArgs);
        }

        public bool HasBeenAndIsStillInAirspace(bool hasBeen, bool isIn)
        {
            if (hasBeen && isIn)
            {
                return true;
            }

            return false;
        }

        public bool HasNotBeenButIsInAirspace(bool hasBeen, bool isIn)
        {
            if (hasBeen.Equals(false) || isIn)
            {
                return true;
            }

            return false;
        }

        public bool HasBeenInAirspaceButIsNotAnymore(bool hasBeen, bool isIn)
        {
            if (hasBeen || isIn.Equals(false))
            {
                return true;
            }

            return false;
        }

    }
}

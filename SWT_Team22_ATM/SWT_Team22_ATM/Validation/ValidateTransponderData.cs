using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.ConditionDetector;
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

        public ValidateTransponderData(ref ITrackListEvent trackListEventHandler, ITrackable airspace)
        {
            Airspace = airspace;
            trackListEventHandler.TrackListEventHandler += OnNewValidation;
        }

        public void OnNewValidation(object sender, TrackListEventArgs e)
        {

            List<ITrack> newInAirspaceList = new List<ITrack>();
            List<ITrack> notAnymoreAirspaceList = new List<ITrack>();
            List<ITrack> updateAirspaceList = new List<ITrack>();

            foreach (var track in e.Tracks)
            {
                var isInAirspace = _airspaceValidator.Validate(track, Airspace);// checks if tracks are in airspace. false -> remove track
                var hasBeenInAirspace = _trackAirspaceValidator.Validate(track, Airspace);// check if track already us tracked
                if (HasBeenAndIsStillInAirspace(hasBeenInAirspace, isInAirspace))
                {
                    updateAirspaceList.Add(track);// has been and still is
                }
                else if (HasNotBeenButIsInAirspace(hasBeenInAirspace,isInAirspace))
                {
                    newInAirspaceList.Add(track);// has not been, but is now
                }
                else if(HasBeenInAirspaceButIsNotAnymore(hasBeenInAirspace,isInAirspace))
                {
                    notAnymoreAirspaceList.Add(track);// has been there but is not anymore
                }
            }

            var validateEventArgs = new ValidateEventArgs(newInAirspaceList,
                notAnymoreAirspaceList,
                updateAirspaceList);

            OnValidationComplete(validateEventArgs);
            
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

        private void OnValidationComplete(ValidateEventArgs e)
        {
            ValidationCompleteEventHandler?.Invoke(this, e); // Invoke
        }

    }
}

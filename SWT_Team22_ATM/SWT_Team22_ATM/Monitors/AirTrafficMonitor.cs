using System;
using System.Collections.Generic;
using SWT_Team22_ATM.ConditionDetector;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Updater;
using SWT_Team22_ATM.Validation;

namespace SWT_Team22_ATM.Monitors
{
    public class AirTrafficMonitor : ITrafficMonitor
    {
        private readonly IValidateEvent _validator;
        private readonly IConditionDetector _conditionDetector;
        private readonly IUpdater<List<ITrack>> _updater;
        private readonly IOutputter _outputter;
        public AirTrafficMonitor(IValidateEvent validator, IConditionDetector conditionDetector, IOutputter outputter, IUpdater<List<ITrack>> updater)
        {
            _validator = validator;
            _validator.ValidationCompleteEventHandler += Update;
            _conditionDetector = conditionDetector;
            _conditionDetector.ConditionsHandler += ConditionDetector_ConditionsHandler;
            _outputter = outputter;
            _updater = updater;
            Airspace = new Airspace();
            Conditions = new List<ConditionEventArgs>();
        }
        
        public ITrackable Airspace { get; private set; }
        public List<ConditionEventArgs> Conditions { get; private set; }
        public void Update(object sender, ValidateEventArgs e)
        {
            Conditions.Clear();
            Airspace.Trackables.RemoveAll(tracks => e.NotInAirspaceButUsedToBe.Exists(tr => tr.Tag == tracks.Tag));
            List<ITrack> tempTracks = Airspace.Trackables;
            _updater.Update(ref tempTracks,e.StillInAirspace);
            Airspace.Trackables = tempTracks;
            Airspace.Trackables.AddRange(e.NewInAirspace);
            _conditionDetector.DetectCondition(Airspace);
            _outputter.TrafficController.DisplayTracks(Airspace.Trackables);
        }

        private void ConditionDetector_ConditionsHandler(object sender, ConditionEventArgs e)
        {
            Conditions.Add(e);
            _outputter.Logger.LogCondition(e.FirstConditionHolder,e.SecondConditionHolder);
            _outputter.TrafficController.DisplayConditions(Conditions);
        }
    }
}
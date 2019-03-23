using System;
using System.Collections.Generic;
using NUnit.Framework;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.interpreter;
using SWT_Team22_ATM.Monitors;
using SWT_Team22_ATM.Validation;
using SWT_TEAM22_ATM.Test.Unit.TestMonitors;

namespace SWT_TEAM22_ATM.Test.Unit.ValidatorTest
{
    [TestFixture]
    public class ValidateTransponderDataTest
    {
        private ValidateTransponderData _uut;
        private ITrackable _airspace;
        private IValidateEvent _uut_validateEvent;
        private EventHandler<TrackListEventArgs> trackListEventHandler;
        private ValidateTransponderData _validateTransponderData;
        private ValidateEventArgs _validateEventArgs;

        [SetUp]
        public void TestSetUp()
        {
            _validateEventArgs = null;
            _airspace = FakeAirspaceGenerator.GetAirspace(0, 0, 0);
            _validateTransponderData.Airspace = _airspace;
            _uut_validateEvent = new ValidateTransponderData(ref trackListEventHandler);
            
            _validateTransponderData.ValidationCompleteEventHandler += (sender, args) => { _validateEventArgs = args; };
        }

        [Test]
        public void OnNewValidation_ValidateTracks_EventHandlerInvoked()
        {
            var invoked = false;
            var firstTrack = FakeTrackFactory.GetTrackWithTag("ATR423", 1000, 1000, 1000);
            var secondTrack = FakeTrackFactory.GetTrackWithTag("ATR423", 1100, 1100, 1000);
            _airspace.Trackables = new List<ITrack>() {firstTrack, secondTrack};

            

            TrackListEventArgs eventArgs = new TrackListEventArgs();

            trackListEventHandler.Invoke(this,eventArgs);

        }
        
    }
}
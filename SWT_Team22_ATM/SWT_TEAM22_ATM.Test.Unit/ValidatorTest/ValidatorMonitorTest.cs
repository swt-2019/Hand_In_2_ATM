using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.interpreter;
using SWT_Team22_ATM.Validation;
using SWT_TEAM22_ATM.Test.Unit.TestMonitors;

namespace SWT_TEAM22_ATM.Test.Unit.ValidatorTest
{
    [TestFixture]
    public class ValidatorMonitorTest
    {
        private IValidateEvent _validateEvent;
        private TrafficMonitorFake _trafficMonitorFake;
        private ValidateTransponderData _validateTransponderData;
        private ITrackListEvent _trackListEvent;
        private ITrackable _airspace;
        private ValidateEventArgs _validateEventArgs;
        private TrackListEventArgs _trackListEventArgs;

        [SetUp]
        public void TestSetup()
        {
            _validateEvent = Substitute.For<IValidateEvent>();
            _trafficMonitorFake = new TrafficMonitorFake(ref _validateEvent);


            _trackListEvent = Substitute.For<ITrackListEvent>();
            _airspace = FakeAirspaceGenerator.GetAirspace(0, 0, 0);

            

        }

        public void testInvokedHelper(object sender, ValidateEventArgs e)
        {
            Console.WriteLine("Got here");
        }

        [Test]
        public void OnValidationComplete_Invoked()
        {
            var invoked = false;

            var trackListInvoked = false;

            _validateTransponderData = new ValidateTransponderData(ref _trackListEvent, _airspace);

            var trackList = FakeTrackFactory.GetMultipleTracksWithTags(10);
            _trackListEventArgs = new TrackListEventArgs(trackList);

            _trackListEvent.TrackListEventHandler += (sender, args) => trackListInvoked = true;

            _validateEvent.ValidationCompleteEventHandler += (sender, args) => invoked = true;


            _validateEvent.ValidationCompleteEventHandler += testInvokedHelper;


            var testTrack = FakeTrackFactory.GetTrackWithTag("ASB123", 100, 200, 300);

            //var list = new List<ITrack>(){testTrack};
            
            _validateEventArgs = new ValidateEventArgs(trackList, trackList, trackList);

            _validateEvent.ValidationCompleteEventHandler += Raise.EventWith(new object(), _validateEventArgs);

            _trackListEvent.TrackListEventHandler += Raise.EventWith(new object(), _trackListEventArgs);

            Console.WriteLine(trackListInvoked);

            Assert.That(invoked);
        }
    }
}
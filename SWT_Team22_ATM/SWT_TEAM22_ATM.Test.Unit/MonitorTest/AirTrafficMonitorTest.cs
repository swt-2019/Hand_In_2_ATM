using System.Collections.Generic;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using SWT_Team22_ATM;
using SWT_Team22_ATM.ConditionDetector;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Monitors;
using SWT_Team22_ATM.Updater;
using SWT_Team22_ATM.Validation;

namespace SWT_TEAM22_ATM.Test.Unit.MonitorTest
{
    [TestFixture]
    public class AirTrafficMonitorTest
    {
        private IValidateEvent _fakeValidator;
        private IConditionDetector _fakeConditionDetector;
        private IOutputter _fakeOutputter;
        private IUpdater<List<ITrack>> _fakeUpdater;
        private AirTrafficMonitor _uutAirTrafficMonitor;
        [SetUp]
        public void TestSetup()
        {
            _fakeValidator = Substitute.For<IValidateEvent>();
            _fakeConditionDetector = Substitute.For<IConditionDetector>();
            _fakeOutputter = Substitute.For<IOutputter>();
            _fakeUpdater = Substitute.For<IUpdater<List<ITrack>>>();
            _uutAirTrafficMonitor = new AirTrafficMonitor(_fakeValidator,_fakeConditionDetector,_fakeOutputter,_fakeUpdater);
        }

        [Test]
        public void Update_ValidationEventRaise_UpdaterInvoked()
        {
            var fakeNewList = new List<ITrack>() {FakeTrackFactory.GetTrackWithTag("newTrack", 0, 0, 0)};
            var fakeUpdateList = new List<ITrack>(){FakeTrackFactory.GetTrackWithTag("updateTrack",0,0,0)};
            var fakeRemoveList = new List<ITrack>() { FakeTrackFactory.GetTrackWithTag("removeTrack", 0, 0, 0)};
            var fakeEventArgs = new ValidateEventArgs(fakeNewList,fakeRemoveList,fakeUpdateList);

            _fakeValidator.ValidationCompleteEventHandler += Raise.EventWith(_fakeValidator, fakeEventArgs);


            _fakeUpdater.Received().Update(ref Arg.Any<List<ITrack>>(),
                Arg.Is<List<ITrack>>(trackList => trackList.Exists(t => t.Tag == "updateTrack")));
        }

        [Test]
        public void Update_ValidationEventRaise_CorrectTracksRemoved()
        {
            var fakeNewList = new List<ITrack>() { FakeTrackFactory.GetTrackWithTag("newTrack", 0, 0, 0) };
            var fakeUpdateList = new List<ITrack>() { FakeTrackFactory.GetTrackWithTag("updateTrack", 0, 0, 0) };
            var fakeRemoveList = new List<ITrack>() { FakeTrackFactory.GetTrackWithTag("removeTrack", 0, 0, 0) };
            _uutAirTrafficMonitor.Airspace.Trackables.Add(FakeTrackFactory.GetTrackWithTag("removeTrack",120,120,120));
            var fakeEventArgs = new ValidateEventArgs(fakeNewList, fakeRemoveList, fakeUpdateList);

            _fakeValidator.ValidationCompleteEventHandler += Raise.EventWith(_fakeValidator, fakeEventArgs);


            Assert.That(_uutAirTrafficMonitor.Airspace.Trackables.Exists(t=>t.Tag=="removeTrack"),Is.False);
        }

        [Test]
        public void Update_NewTrackConditionCheck_ConditionDetectorInvoked()
        {
            var fakeNewList = new List<ITrack>() { FakeTrackFactory.GetTrackWithTag("newTrack", 0, 0, 0) };
            var fakeUpdateList = new List<ITrack>() { FakeTrackFactory.GetTrackWithTag("updateTrack", 0, 0, 0) };
            var fakeRemoveList = new List<ITrack>() { FakeTrackFactory.GetTrackWithTag("removeTrack", 0, 0, 0) };
            var fakeEventArgs = new ValidateEventArgs(fakeNewList, fakeRemoveList, fakeUpdateList);

            _fakeValidator.ValidationCompleteEventHandler += Raise.EventWith(_fakeValidator, fakeEventArgs);


            _fakeConditionDetector.Received().DetectCondition(Arg.Is<ITrackable>(trackList =>
                trackList.Trackables.Exists(t => t.Tag == "newTrack")));
        }


        [Test]
        public void ConditionHandler_ConditionInvoke_ConditionAdded()
        {
            var fakeFirstCondition = FakeTrackFactory.GetTrackWithTag("firstCondition", 0, 0, 0);
            var fakeSecondCondition = FakeTrackFactory.GetTrackWithTag("secondCondition", 0, 0, 0);
            var fakeConditionEventArgs = new ConditionEventArgs(fakeFirstCondition,fakeSecondCondition);

            _fakeConditionDetector.ConditionsHandler += Raise.EventWith(_fakeConditionDetector, fakeConditionEventArgs);

            Assert.That(_uutAirTrafficMonitor.Conditions.Contains(fakeConditionEventArgs));
        }
        [Test]
        public void ConditionHandler_ConditionInvoke_LoggerInvokedCorrect()
        {
            var fakeFirstCondition = FakeTrackFactory.GetTrackWithTag("firstCondition", 0, 0, 0);
            var fakeSecondCondition = FakeTrackFactory.GetTrackWithTag("secondCondition", 0, 0, 0);
            var fakeConditionEventArgs = new ConditionEventArgs(fakeFirstCondition, fakeSecondCondition);

            _fakeConditionDetector.ConditionsHandler += Raise.EventWith(_fakeConditionDetector, fakeConditionEventArgs);
            
            _fakeOutputter.Logger.Received().LogCondition(
                Arg.Is<ITrack>(t => t == fakeFirstCondition ),
                Arg.Is<ITrack>(t => t == fakeSecondCondition));
        }
        [Test]
        public void ConditionHandler_ConditionInvoke_TrafficControllerInvokedCorrectly()
        {
            var fakeFirstCondition = FakeTrackFactory.GetTrackWithTag("firstCondition", 0, 0, 0);
            var fakeSecondCondition = FakeTrackFactory.GetTrackWithTag("secondCondition", 0, 0, 0);
            var fakeConditionEventArgs = new ConditionEventArgs(fakeFirstCondition, fakeSecondCondition);

            _fakeConditionDetector.ConditionsHandler += Raise.EventWith(_fakeConditionDetector, fakeConditionEventArgs);

            _fakeOutputter.TrafficController.Received().DisplayConditions(_uutAirTrafficMonitor.Conditions);
        }
    }
}
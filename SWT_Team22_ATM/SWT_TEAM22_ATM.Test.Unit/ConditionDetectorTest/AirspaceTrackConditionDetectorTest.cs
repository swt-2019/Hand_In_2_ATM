using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using SWT_Team22_ATM.ConditionDetector;
using SWT_Team22_ATM.Domains;
using TransponderReceiverUser;


namespace SWT_TEAM22_ATM.Test.Unit
{
    [TestFixture]
    public class AirspaceTrackConditionDetectorTest
    {
        private IConditionDetector _uutConditionDetector;
        private IConditionStrategy<ITrack> _fakeCondition;

        [SetUp]
        public void TestSetup()
        {
            _fakeCondition = Substitute.For<IConditionStrategy<ITrack>>();
            var conditionList = new List<IConditionStrategy<ITrack>>() {_fakeCondition};
            _uutConditionDetector = new AirspaceTrackConditionDetector(conditionList);
        }

        [Test]
        public void DetectCondition_ConditionFound_EventHandlerInvoked()
        {
            bool invoked = false;
            ITrack trackInAirspace = FakeTrackFactory.GetTrack(1000, 1000, 1000);
            ITrack trackToCheck = FakeTrackFactory.GetTrack(1100, 1100, 1000);
            ITrackable airspace = FakeAirspaceGenerator.GetAirspace(0, 0, 0);
            _fakeCondition.ConditionBetween(Arg.Any<ITrack>(),Arg.Any<ITrack>()).Returns(true);
            airspace.Trackables.Add(trackInAirspace);
            _uutConditionDetector.ConditionsHandler += (s,e) => invoked = true;

            _uutConditionDetector.DetectCondition(airspace,trackToCheck);

            Assert.That(invoked);
        }


        [Test]
        public void DetectCondition_ConditionNotFound_EventHandlerNotInvoked()
        {
            bool invoked = false;
            ITrack trackInAirspace = FakeTrackFactory.GetTrack(1000, 1000, 1000);
            ITrack trackToCheck = FakeTrackFactory.GetTrack(1100, 1100, 1000);
            ITrackable airspace = FakeAirspaceGenerator.GetAirspace(0, 0, 0);
            _fakeCondition.ConditionBetween(Arg.Any<ITrack>(), Arg.Any<ITrack>()).Returns(false);
            airspace.Trackables.Add(trackInAirspace);
            _uutConditionDetector.ConditionsHandler += (s, e) => invoked = true;

            _uutConditionDetector.DetectCondition(airspace, trackToCheck);

            Assert.That(invoked == false);
        }
    }
}

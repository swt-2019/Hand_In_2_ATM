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
            ITrack firstTrack = FakeTrackFactory.GetTrack(1000, 1000, 1000);
            ITrack secondTrack = FakeTrackFactory.GetTrack(1100, 1100, 1000);
            ITrackable airspace = FakeAirspaceGenerator.GetAirspace(0, 0, 0);
            airspace.Trackables = new List<ITrack>() { firstTrack, secondTrack };
            _fakeCondition.ConditionBetween(Arg.Any<ITrack>(),Arg.Any<ITrack>()).Returns(true);
            _uutConditionDetector.ConditionsHandler += (s,e) => invoked = true;

            _uutConditionDetector.DetectCondition(airspace);

            Assert.That(invoked);
        }


        [Test]
        public void DetectCondition_ConditionNotFound_EventHandlerNotInvoked()
        {
            bool invoked = false;
            ITrack firstTrack = FakeTrackFactory.GetTrack(1000, 1000, 1000);
            ITrack secondTrack = FakeTrackFactory.GetTrack(1100, 1100, 1000);
            ITrackable airspace = FakeAirspaceGenerator.GetAirspace(0, 0, 0);
            airspace.Trackables = new List<ITrack>() {firstTrack, secondTrack};
            _fakeCondition.ConditionBetween(Arg.Any<ITrack>(), Arg.Any<ITrack>()).Returns(false);
            _uutConditionDetector.ConditionsHandler += (s, e) => invoked = true;

            _uutConditionDetector.DetectCondition(airspace);

            Assert.That(invoked == false);
        }


        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(100)]
        public void DetectCondition_MultipleConditions_EventHandlerInvokedCorrect(int numConditions)
        {
            int timesInvoked = 0;
            ITrack trackInAirspace = FakeTrackFactory.GetTrack(1000, 1000, 1000);
            ITrackable airspace = FakeAirspaceGenerator.GetAirspace(0, 0, 0);
            airspace.Trackables.Add(trackInAirspace); //There must be one track always
            for (int i = 0; i < numConditions; i++)
            {
                airspace.Trackables.Add(trackInAirspace);
            }
            //Because each element in the airspace is compared to each other:
            int expectedVisitations = numConditions * airspace.Trackables.Count / 2;
            _fakeCondition.ConditionBetween(Arg.Any<ITrack>(), Arg.Any<ITrack>()).Returns(true);
            _uutConditionDetector.ConditionsHandler += (s, e) => ++timesInvoked;

            _uutConditionDetector.DetectCondition(airspace);

            Assert.That(timesInvoked, Is.EqualTo(expectedVisitations));
        }



        [Test]
        public void DetectCondition_ConditionFound_FirstConditionCorrect()
        {
            ConditionEventArgs eventArgsReceived = null;
            ITrack firstTrack = FakeTrackFactory.GetTrack(1000, 1000, 1000);
            ITrack secondTrack = FakeTrackFactory.GetTrack(1100, 1100, 1000);
            ITrackable airspace = FakeAirspaceGenerator.GetAirspace(0, 0, 0);
            airspace.Trackables = new List<ITrack>() {firstTrack, secondTrack};
            _fakeCondition.ConditionBetween(Arg.Any<ITrack>(), Arg.Any<ITrack>()).Returns(true);
            _uutConditionDetector.ConditionsHandler += (s, e) => eventArgsReceived = e;

            _uutConditionDetector.DetectCondition(airspace);

            Assert.That(eventArgsReceived.FirstConditionHolder,Is.EqualTo(firstTrack));
        }


        [Test]
        public void DetectCondition_ConditionFound_SecondConditionCorrect()
        {
            ConditionEventArgs eventArgsReceived = null;
            ITrack firstTrack = FakeTrackFactory.GetTrack(1000, 1000, 1000);
            ITrack secondTrack = FakeTrackFactory.GetTrack(1100, 1100, 1000);
            ITrackable airspace = FakeAirspaceGenerator.GetAirspace(0, 0, 0);
            airspace.Trackables = new List<ITrack>() { firstTrack, secondTrack };
            _fakeCondition.ConditionBetween(Arg.Any<ITrack>(), Arg.Any<ITrack>()).Returns(true);
            _uutConditionDetector.ConditionsHandler += (s, e) => eventArgsReceived = e;

            _uutConditionDetector.DetectCondition(airspace);

            Assert.That(eventArgsReceived.SecondConditionHolder, Is.EqualTo(secondTrack));
        }
    }
}

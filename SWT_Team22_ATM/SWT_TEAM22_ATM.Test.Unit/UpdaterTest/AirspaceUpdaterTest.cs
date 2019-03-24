using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Updater;
using SWT_Team22_ATM.Updater.ICalculateTracks;

namespace SWT_TEAM22_ATM.Test.Unit.UpdaterTest
{
    [TestFixture]
    public class AirspaceUpdaterTest
    {
        private AirspaceUpdater _uutAirspaceUpdater;
        private ITrackCalculator<double> _courseCalculator;
        private ITrackCalculator<double> _speedCalculator;

        [SetUp]
        public void TestSetup()
        {
            _courseCalculator = Substitute.For<ITrackCalculator<double>>();
            _speedCalculator = Substitute.For<ITrackCalculator<double>>();
            _uutAirspaceUpdater = new AirspaceUpdater(_speedCalculator,_courseCalculator);
        }

        [Test]
        public void Update_TheListIsUpdated_FirstTracksAreEqalSecondTracks()
        {
            List<ITrack> firstTracks = new List<ITrack>()
            {
                FakeTrackFactory.GetTrackWithTag("tag1",100,100,100),
                FakeTrackFactory.GetTrackWithTag("tag2",200,200,300),
                FakeTrackFactory.GetTrackWithTag("tag3",200,200,400),
            };
            List<ITrack> secondTracks = new List<ITrack>()
            {
                FakeTrackFactory.GetTrackWithTag("tag1",200,300,100),
                FakeTrackFactory.GetTrackWithTag("tag2",100,400,300),
                FakeTrackFactory.GetTrackWithTag("tag3",300,500,600),
            };
            _uutAirspaceUpdater.Update(ref firstTracks, secondTracks);

            CollectionAssert.AreEqual(firstTracks,secondTracks);
        }

        [Test]
        public void Update_TheUpdateCalculatesSpeed_SpeedIsCorrect()
        {

            List<ITrack> firstTracks = new List<ITrack>()
            {
                FakeTrackFactory.GetTrackWithTag("tag1",100,100,100),
                FakeTrackFactory.GetTrackWithTag("tag2",200,200,300),
                FakeTrackFactory.GetTrackWithTag("tag3",200,200,400),
            };
            List<ITrack> secondTracks = new List<ITrack>()
            {
                FakeTrackFactory.GetTrackWithTag("tag1",200,300,100),
                FakeTrackFactory.GetTrackWithTag("tag2",100,400,300),
                FakeTrackFactory.GetTrackWithTag("tag3",300,500,600),
            };
            _speedCalculator.Calculate(Arg.Any<ITrack>(),Arg.Any<ITrack>()).Returns(100);
            
            _uutAirspaceUpdater.Update(ref firstTracks,secondTracks);
            Assert.That(firstTracks.Select(track=>track.Speed),Is.All.EqualTo(100.0).Within(1).Percent);
        }


        [Test]
        public void Update_TheUpdateCalculatesCourse_CourseIsCorrect()
        {

            List<ITrack> firstTracks = new List<ITrack>()
            {
                FakeTrackFactory.GetTrackWithTag("tag1",100,100,100),
                FakeTrackFactory.GetTrackWithTag("tag2",200,200,300),
                FakeTrackFactory.GetTrackWithTag("tag3",200,200,400),
            };
            List<ITrack> secondTracks = new List<ITrack>()
            {
                FakeTrackFactory.GetTrackWithTag("tag1",200,300,100),
                FakeTrackFactory.GetTrackWithTag("tag2",100,400,300),
                FakeTrackFactory.GetTrackWithTag("tag3",300,500,600),
            };
            _courseCalculator.Calculate(Arg.Any<ITrack>(), Arg.Any<ITrack>()).Returns(100);

            _uutAirspaceUpdater.Update(ref firstTracks, secondTracks);
            Assert.That(firstTracks.Select(track => track.Course), Is.All.EqualTo(100.0).Within(1).Percent);
        }


        [Test]
        public void Update_SpeedNotSetIfTrackNotFound_SpeedIs0()
        {

            List<ITrack> firstTracks = new List<ITrack>()
            {
                FakeTrackFactory.GetTrackWithTag("tag1",100,100,100),
                FakeTrackFactory.GetTrackWithTag("tag2",200,200,300),
                FakeTrackFactory.GetTrackWithTag("tag3",200,200,400),
            };
            List<ITrack> secondTracks = new List<ITrack>()
            {
                FakeTrackFactory.GetTrackWithTag("tagX",200,300,100),
                FakeTrackFactory.GetTrackWithTag("tagY",100,400,300),
                FakeTrackFactory.GetTrackWithTag("tagZ",300,500,600),
            };
            _speedCalculator.Calculate(Arg.Any<ITrack>(), Arg.Any<ITrack>()).Returns(100);

            _uutAirspaceUpdater.Update(ref firstTracks, secondTracks);
            Assert.That(firstTracks.Select(track => track.Speed), Is.All.EqualTo(0).Within(1).Percent);
        }


        [TestCase(0,0,0)]
        [TestCase(1,2,3)]
        [TestCase(-2,-3,1)]
        [TestCase(3,3,3)]
        [TestCase(1000,-1000,1000)]
        public void Update_TrackPositionIsUpdated_TrackPositionCorrect(int newX, int newY,int newZ)
        {
            List<ITrack> firstTracks = new List<ITrack>()
            {
                FakeTrackFactory.GetTrackWithTag("tag1",100,100,100),
                FakeTrackFactory.GetTrackWithTag("tag2",200,200,300),
                FakeTrackFactory.GetTrackWithTag("tag3",200,200,400),
            };
            List<ITrack> secondTracks = new List<ITrack>()
            {
                FakeTrackFactory.GetTrackWithTag("tag1",newX,newY,newZ),
                FakeTrackFactory.GetTrackWithTag("tag2",newX,newY,newZ),
                FakeTrackFactory.GetTrackWithTag("tag3",newX,newY,newZ),
            };

            _uutAirspaceUpdater.Update(ref firstTracks, secondTracks);
            Assert.That(firstTracks.Select(track => track.TrackPosition.XCoordinate), Is.All.EqualTo(newX));
            Assert.That(firstTracks.Select(track => track.TrackPosition.YCoordinate), Is.All.EqualTo(newY));
            Assert.That(firstTracks.Select(track => track.TrackPosition.ZCoordinate), Is.All.EqualTo(newZ));
        }
    }
}
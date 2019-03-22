using System;
using NUnit.Framework;
using NSubstitute;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Updater.ICalculateTracks;

namespace SWT_TEAM22_ATM.Test.Unit
{
    [TestFixture]
    public class TrackSpeedCalculatorTest
    {

        private ITrackCalculator<double> _fakeTrackHorizontalDistanceCalculator;
        private TrackSpeedCalculator _uutTrackSpeedCalculator;
        

        [SetUp]
        public void TestSetup()
        {
            _fakeTrackHorizontalDistanceCalculator = Substitute.For<ITrackCalculator<double>>();
            _uutTrackSpeedCalculator = new TrackSpeedCalculator(_fakeTrackHorizontalDistanceCalculator);
        }
        
        [Test]
        public void Calculate_CalculateRightTrackDistance_ReturnIsCorrect()
        {
            var firstTrack = FakeTrackFactory.GetTrackWithTime("20190101000000000", 100, 100, 100);
            var secondTrack = FakeTrackFactory.GetTrackWithTime("20190101000500000",100, 100, 100);//5 minutes after the last
            _fakeTrackHorizontalDistanceCalculator.Calculate(Arg.Any<ITrack>(), Arg.Any<ITrack>()).Returns(300);


            var result = _uutTrackSpeedCalculator.Calculate(firstTrack, secondTrack);

            Assert.That(result,Is.EqualTo(1));
        }
    }
}
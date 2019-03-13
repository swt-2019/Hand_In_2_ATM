using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SWT_Team22_ATM.ConditionDetector;
using SWT_Team22_ATM.Domains;

namespace SWT_TEAM22_ATM.Test.Unit.ConditionDetectorTest
{
    [TestFixture]
    public class TrackHorizontalDistanceConditionTest
    {
        private TrackHorizontalDistanceCondition _uutTrackHorizontalDistanceCondition;

        [SetUp]
        public void TestSetup()
        {
            _uutTrackHorizontalDistanceCondition = new TrackHorizontalDistanceCondition();
        }


        [TestCase(500, 1000, 1500, 1200, 3000 )]
        [TestCase(700, 1300, 1000, 1900, 4000)]
        [TestCase(1000, 1900, 1200, 900, 200)]
        [TestCase(100, 1200, 1300,1160,2000)]
        public void ConditionBetween_ConditionFoundXCoordinate_ReturnsTrue(int horizontalRestriction, int xTrack1, int yTrack1, int xTrack2, int yTrack2  )
        {
            _uutTrackHorizontalDistanceCondition.HorizontalDistance = horizontalRestriction;
            ITrack track1 = FakeTrackFactory.GetTrack(xTrack1, yTrack1, 1000);
            ITrack track2 = FakeTrackFactory.GetTrack(xTrack2, yTrack2, 1000);

            var result = _uutTrackHorizontalDistanceCondition.ConditionBetween(track1, track2);

            Assert.That(result == true);
        }



        [TestCase(500, 2000, 2500, 1200, 3000)]
        [TestCase(700, 300, 3500, 1900, 4000)]
        [TestCase(1000, 2000, 1200, 900, 1300)]
        [TestCase(100, 7000, 1400, 160, 1330)]
        public void ConditionBetween_ConditionFoundYCoordinate_ReturnsTrue(int horizontalRestriction, int xTrack1, int yTrack1, int xTrack2, int yTrack2)
        {
            _uutTrackHorizontalDistanceCondition.HorizontalDistance = horizontalRestriction;
            ITrack track1 = FakeTrackFactory.GetTrack(xTrack1, yTrack1, 1000);
            ITrack track2 = FakeTrackFactory.GetTrack(xTrack2, yTrack2, 1000);

            var result = _uutTrackHorizontalDistanceCondition.ConditionBetween(track1, track2);

            Assert.That(result == true);
        }


        [TestCase(500, 1300, 2500, 1200, 3000)]
        [TestCase(700, 1300, 3500, 1900, 4000)]
        [TestCase(1000, 2000, 1200, 1900, 1300)]
        [TestCase(100, 7000, 1400, 7020, 1430)]
        public void ConditionBetween_ConditionFoundBothCoordinate_ReturnsTrue(int horizontalRestriction, int xTrack1, int yTrack1, int xTrack2, int yTrack2)
        {
            _uutTrackHorizontalDistanceCondition.HorizontalDistance = horizontalRestriction;
            ITrack track1 = FakeTrackFactory.GetTrack(xTrack1, yTrack1, 1000);
            ITrack track2 = FakeTrackFactory.GetTrack(xTrack2, yTrack2, 1000);

            var result = _uutTrackHorizontalDistanceCondition.ConditionBetween(track1, track2);

            Assert.That(result == true);
        }
    }
}

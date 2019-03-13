using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SWT_Team22_ATM.ConditionDetector;
using SWT_Team22_ATM.Domains;

namespace SWT_TEAM22_ATM.Test.Unit
{
    [TestFixture]
    public class TrackAltitudeConditionTest
    {
        private TrackAltitudeCondition _uuTrackAltitudeCondition;
        [SetUp]
        public void TestSetup()
        {
            _uuTrackAltitudeCondition = new TrackAltitudeCondition();
        }

        [TestCase(1000,1000,1500)]
        [TestCase(700,1300,1000)]
        [TestCase(1000,1900,1200)]
        [TestCase(100,1200,1300)]
        public void ConditionBetween_ConditionFound_ReturnsTrue(int altitudeRestriction, int altitudeTrack1, int altitudeTrack2)
        {
            _uuTrackAltitudeCondition.AltitudeRestriction = altitudeRestriction;
            ITrack track1 = FakeTrackFactory.GetTrack(1000, 1000, altitudeTrack1);
            ITrack track2 = FakeTrackFactory.GetTrack(2000, 2000, altitudeTrack2);

            var result = _uuTrackAltitudeCondition.ConditionBetween(track1, track2);

            Assert.That(result == true);
        }


        [TestCase(400, 1000, 1500)]
        [TestCase(300, 3000, 1500)]
        [TestCase(500, 600, 1200)]
        [TestCase(10, 1300, 1800)]
        public void ConditionBetween_ConditionNotFound_ReturnsFalse(int altitudeRestriction, int altitudeTrack1, int altitudeTrack2)
        {
            _uuTrackAltitudeCondition.AltitudeRestriction = altitudeRestriction;
            ITrack track1 = FakeTrackFactory.GetTrack(1000, 1000, altitudeTrack1);
            ITrack track2 = FakeTrackFactory.GetTrack(2000, 2000, altitudeTrack2);

            var result = _uuTrackAltitudeCondition.ConditionBetween(track1, track2);

            Assert.That(result == false);
        }

    }
}

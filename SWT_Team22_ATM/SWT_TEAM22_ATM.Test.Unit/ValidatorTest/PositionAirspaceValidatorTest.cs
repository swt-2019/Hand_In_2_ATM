using NUnit.Framework;
using SWT_Team22_ATM.Validation;

namespace SWT_TEAM22_ATM.Test.Unit.ValidatorTest
{
    [TestFixture]
    public class PositionAirspaceValidatorTest
    {
        private PositionAirspaceValidator _uut;

        [SetUp]
        public void TestSetUp()
        {
            _uut = new PositionAirspaceValidator();
        }

        [Test]
        public void IsTrackXCoordinateInAirspaceArea_IsInAirspace_returnsTrue()
        {
            _uut.Track = FakeTrackFactory.GetTrack(200, 300, 400);
            _uut.Trackable = FakeAirspaceGenerator.GetAirspace(0, 0, 0);

            var result = _uut.IsTrackXCoordinateInAirspaceArea();
            Assert.That(result);

        }

        [Test]
        public void IsTrackXCoordinateInAirspaceArea_IsInAirspace_returnsFalse()
        {
            _uut.Track = FakeTrackFactory.GetTrack(200, 300, 400);
            _uut.Trackable = FakeAirspaceGenerator.GetAirspace(1000,1000,1000);

            var result = _uut.IsTrackXCoordinateInAirspaceArea();
            Assert.That(result.Equals(false));
        }

        [Test]
        public void IsTrackYCoordinateInAirspaceArea_IsInAirspace_returnsTrue()
        {
            _uut.Track = FakeTrackFactory.GetTrack(200, 300, 400);
            _uut.Trackable = FakeAirspaceGenerator.GetAirspace(0,0,0);

            var result = _uut.IsTrackYCoordinateInAirspaceArea();
            Assert.That(result);
        }

        [Test]
        public void IsTrackYCoordinateInAirspaceArea_IsInAirspace_returnsFalse()
        {
            _uut.Track = FakeTrackFactory.GetTrack(200, 300, 400);
            _uut.Trackable = FakeAirspaceGenerator.GetAirspace(1000, 1000, 1000);

            var result = _uut.IsTrackYCoordinateInAirspaceArea();
            Assert.That(result.Equals(false));
        }

        [Test]
        public void IsTrackZCoordinateInAirspaceArea_IsInAirspace_returnsTrue()
        {
            _uut.Track = FakeTrackFactory.GetTrack(200, 300, 400);
            _uut.Trackable = FakeAirspaceGenerator.GetAirspace(0, 0, 0);

            var result = _uut.IsTrackZCoordinateInAirspaceArea();
            Assert.That(result);
        }

        [Test]
        public void IsTrackZCoordinateInAirspaceArea_IsInAirspace_returnsFalse()
        {
            _uut.Track = FakeTrackFactory.GetTrack(200, 300, 400);
            _uut.Trackable = FakeAirspaceGenerator.GetAirspace(1000, 1000, 1000);

            var result = _uut.IsTrackZCoordinateInAirspaceArea();
            Assert.That(result.Equals(false));
        }
    }
}
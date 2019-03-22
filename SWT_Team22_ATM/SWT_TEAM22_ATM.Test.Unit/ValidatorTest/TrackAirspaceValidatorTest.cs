using NUnit.Framework;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Validation;

namespace SWT_TEAM22_ATM.Test.Unit.ValidatorTest
{
    [TestFixture]
    public class TrackAirspaceValidatorTest
    {
        private TrackAirspaceValidator _uut;

        [SetUp]
        public void TestSetUp()
        {
            _uut = new TrackAirspaceValidator();
        }

        [Test]
        public void IsTrackAlreadyRegistered_AlreadyTracked_returnsTrue()
        {
            var track = FakeTrackFactory.GetTrackWithTag("ATR423", 234, 432, 654);
            var track2 = FakeTrackFactory.GetTrackWithTag("ATR423", 200, 300, 400);
            _uut.Trackable = FakeAirspaceGenerator.GetAirspace(0, 0, 0);

            
            _uut.Trackable.Trackables.Add(track);
            _uut.Trackable.Trackables.Add(track2);

            var result = _uut.IsTrackAlreadyRegistered(track, track2);

            Assert.That(result);
        }

        [Test]
        public void IsTrackAlreadyRegistered_AlreadyTracked_returnsFalse()
        {
            var track = FakeTrackFactory.GetTrackWithTag("ATR424", 234, 432, 654);
            var track2 = FakeTrackFactory.GetTrackWithTag("ATR423", 200, 300, 400);
            _uut.Trackable = FakeAirspaceGenerator.GetAirspace(0, 0, 0);


            _uut.Trackable.Trackables.Add(track);
            _uut.Trackable.Trackables.Add(track2);

            var result = _uut.IsTrackAlreadyRegistered(track, track2);

            Assert.That( result.Equals(false));
        }

        [Test]
        public void Validate_AlreadyTracked_returnsTrue()
        {
            var track = FakeTrackFactory.GetTrackWithTag("ATR424", 234, 432, 654);
            var track2 = FakeTrackFactory.GetTrackWithTag("ATR424", 200, 300, 400);
            _uut.Trackable = FakeAirspaceGenerator.GetAirspace(0, 0, 0);

            
            _uut.Trackable.Trackables.Add(track2);

            var result = _uut.Validate(track, _uut.Trackable);

            Assert.That(result);
        }

        [Test]
        public void Validate_AlreadyTracked_returnsFalse()
        {
            var track = FakeTrackFactory.GetTrackWithTag("ATR424", 234, 432, 654);
            var track2 = FakeTrackFactory.GetTrackWithTag("ATR423", 200, 300, 400);
            _uut.Trackable = FakeAirspaceGenerator.GetAirspace(0, 0, 0);


            _uut.Trackable.Trackables.Add(track);

            var result = _uut.Validate(track2, _uut.Trackable);

            Assert.That(result,Is.EqualTo(false));
        }
    }
}
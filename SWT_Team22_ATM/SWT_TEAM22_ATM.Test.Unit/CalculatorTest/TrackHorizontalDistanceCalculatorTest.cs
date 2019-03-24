using NUnit.Framework;
using SWT_Team22_ATM.Updater.ICalculateTracks;

namespace SWT_TEAM22_ATM.Test.Unit
{
    [TestFixture]
    public class TrackHorizontalDistanceCalculatorTest
    {
        private TrackHorizontalDistanceCalculator _uutTrackHorizontalDistanceCalculator;

        [SetUp]
        public void TestSetup()
        {
            _uutTrackHorizontalDistanceCalculator = new TrackHorizontalDistanceCalculator();
        }

        [TestCase(3, 4, 5)]
        public void Hypotenuse_HypotenuseCalculation_CorrectCalculation(int a, int b, double expected)
        {
            var result = _uutTrackHorizontalDistanceCalculator.Hypotenuse(a, b);
            
            Assert.That(result.Equals(expected));
        }

        [TestCase(100, 200, 400, 600, 500)]
        [TestCase(400, 600, 100, 200, 500)]
        public void Calculate_CalculateRightTrackDistance_ReturnIsCorrect(int x1, int y1, int x2, int y2, int expected)
        {
            var firstTrack = FakeTrackFactory.GetTrack(x1, y1, 100);
            var secondTrack = FakeTrackFactory.GetTrack(x2, y2, 100);

            var result = _uutTrackHorizontalDistanceCalculator.Calculate(firstTrack, secondTrack);

            Assert.That(result.Equals(expected));
        }
    }
}
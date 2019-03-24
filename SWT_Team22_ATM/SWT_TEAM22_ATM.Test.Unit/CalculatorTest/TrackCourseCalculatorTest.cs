using NUnit.Framework;
using SWT_Team22_ATM.Updater.ICalculateTracks;

namespace SWT_TEAM22_ATM.Test.Unit
{
    [TestFixture]
    public class TrackCourseCalculatorTest
    {
        private TrackCourseCalculator _uutTrackCourseCalculator;
        [SetUp]
        public void TestSetup()
        {
            _uutTrackCourseCalculator = new TrackCourseCalculator();
        }

        [TestCase(0,0,1,1,45)]
        [TestCase(0,0,0,1,90)]
        [TestCase(1,1,0,0,225)]
        [TestCase(0,1,0,0,270)]
        [TestCase(0,0,-1,-1,225)]
        [TestCase(0,0,1,-1,315)]
        public void CalculateAngle_AngleCorrect_ReturnsRightAngle(int x1, int y1,int x2,int y2,int angleBetween)
        {
            var firstTrack = FakeTrackFactory.GetTrack(x1, y1, 0);
            var secondTrack = FakeTrackFactory.GetTrack(x2, y2, 0);

            var result = _uutTrackCourseCalculator.CalculateAngle(firstTrack, secondTrack);
            Assert.That(result,Is.EqualTo(angleBetween).Within(1).Percent);
        }


        [TestCase(0, 0, 0, 1, 0)]
        [TestCase(0, 0, 1, 1, 45)]
        [TestCase(0, 0, 1, 0, 90)]
        [TestCase(1, 1, 0, 0, 225)]
        [TestCase(0, 1, 0, 0, 180)]
        [TestCase(0, 0, -1, -1, 225)]
        [TestCase(0, 0, 1, -1, 135)]
        public void Calculate_AngleCorrect_ReturnsRightAngle(int x1, int y1, int x2, int y2, int angleBetween)
        {
            var firstTrack = FakeTrackFactory.GetTrack(x1, y1, 0);
            var secondTrack = FakeTrackFactory.GetTrack(x2, y2, 0);

            var result = _uutTrackCourseCalculator.Calculate(firstTrack, secondTrack);
            Assert.That(result, Is.EqualTo(angleBetween).Within(1).Percent);
        }
    }
}
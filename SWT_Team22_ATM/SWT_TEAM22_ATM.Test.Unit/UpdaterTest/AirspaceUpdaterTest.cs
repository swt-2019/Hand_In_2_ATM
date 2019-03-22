using System.Collections.Generic;
using NUnit.Framework;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Updater;

namespace SWT_TEAM22_ATM.Test.Unit.UpdaterTest
{
    [TestFixture]
    public class AirspaceUpdaterTest
    {
        private AirspaceUpdater _uutAirspaceUpdater;

        [SetUp]
        public void TestSetup()
        {
            _uutAirspaceUpdater = new AirspaceUpdater();
        }

        [Test]
        public void Update_FindWhatToUpdate_RightUpdates()
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
            _uutAirspaceUpdater.Update(firstTracks, secondTracks);
        }
    }
}
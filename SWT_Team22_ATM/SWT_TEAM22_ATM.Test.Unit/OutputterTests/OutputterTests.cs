using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SWT_Team22_ATM;
using SWT_Team22_ATM.Domains;

namespace SWT_TEAM22_ATM.Test.Unit
{
    [TestFixture]
    public class OutputterTests
    {
        private IOutputter _outputter;
        private List<ITrack> _tracks;
        private List<Condtion> _condtions;
        private Airspace _airspace;
        private FakeConsoleAirTrafficController _trafficController;
        private ILogger _logger;
        
        
        [SetUp]
        public void Outputter_Setup() 
        {
            _outputter = new AirTrafficOutputter();
           
            /*_airspace = FakeAirspaceGenerator.GetAirspace(10,10,10);
            _trafficController = new FakeConsoleAirTrafficController();
            _tracks = new List<ITrack>();
            _condtions = new List<Condtion>();
            _logger = new FileLogger();
            
            var track1 = FakeTrackFactory.GetTrackWithTag("Tag1", 1, 2, 3);
            var track2 = FakeTrackFactory.GetTrackWithTag("Tag2", 4, 5, 6);
            
            _tracks.Add(track1);
            _tracks.Add(track2);

            var condition = new Condtion {Track1 = track1, Track2 = track2};

            _condtions.Add(condition);*/
            
        }
        


        [Test]
        public void SetLoggerTest()
        {
            _outputter = new AirTrafficOutputter {Logger = new FileLogger()};


            Assert.IsInstanceOf<FileLogger>(_outputter.Logger);
        }


        [Test]
        public void SetTrafficController()
        {
            _outputter = new AirTrafficOutputter {TrafficController = new ConsoleAirTrafficController()};

            Assert.IsInstanceOf<ConsoleAirTrafficController>(_outputter.TrafficController);
        }


        /*[Test]
        public void ConditionDetectedTest()
        {
            _outputter.TrafficController = _trafficController;
            _outputter.ConditionDetected(_condtions, _airspace);

            var condition = _condtions.First();

            var compare = "Condition detected between " + condition.Track1.Tag + " & " + condition.Track2.Tag;
            
            
            StringAssert.Contains(compare,_trafficController.Condition);
        }*/
    }
}
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using SWT_Team22_ATM;
using SWT_Team22_ATM.ConditionDetector;
using SWT_Team22_ATM.Domains;

namespace SWT_TEAM22_ATM.Test.Unit
{
    [TestFixture]
    public class OutputterTests
    {
        private IOutputter _uutOutputter;
        private List<ITrack> _tracks;
        private List<ConditionEventArgs> _condtions;
        private Airspace _airspace;
        private ITrafficController _trafficController;
        private ILogger _logger;
        private string _logFile;
        
        
        [SetUp]
        public void Outputter_Setup() 
        {
            _uutOutputter = new AirTrafficOutputter();
            _airspace = FakeAirspaceGenerator.GetAirspace(100, 100, 100);
            
            _logFile = "../../Test.txt";
            


        }
        
        [TearDown]
        public void FileLogger_Cleanup()
        {
            File.Delete(_logFile);
        }
        
        
        [Test]
        public void SetLoggerTest()
        {
            _uutOutputter = new AirTrafficOutputter {Logger = new FileLogger()};


            Assert.IsInstanceOf<FileLogger>(_uutOutputter.Logger);
        }


        [Test]
        public void SetTrafficController()
        {
            _uutOutputter = new AirTrafficOutputter {TrafficController = new ConsoleAirTrafficController()};

            Assert.IsInstanceOf<ConsoleAirTrafficController>(_uutOutputter.TrafficController);
        }


        [TestCase(10)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(3)]
        public void ConditionDetectedTestLogger(int num)
        {
            
            _logger = Substitute.For<ILogger>();
            
            _trafficController = new ConsoleAirTrafficController();
                
            _uutOutputter.Logger = _logger;
            _uutOutputter.TrafficController = _trafficController;
            
            
            _uutOutputter.ConditionDetected(FakeConditionFactory.CreateConditionList(num));


            _uutOutputter.Logger.Received(num).LogCondition(Arg.Any<ITrack>(), Arg.Any<ITrack>());

        }
        
        /*
        [TestCase(10)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(3)]
        public void ConditionDetectedTestDisplay(int num)
        {
            
            _logger = new FileLogger();

            _trafficController = Substitute.For<ConsoleAirTrafficController>();
                
            _outputter.Logger = _logger;
            _outputter.TrafficController = _trafficController;
            
            _tracks = FakeTrackFactory.GetMultipleTracksWithTags(num * 2);

            _airspace.Trackables = _tracks;
            
            
            _outputter.ConditionDetected();


            _outputter.TrafficController.Received(1).DisplayTracks(_tracks);
        }
        */
        
        [TestCase(10)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(3)]
        public void UpdateTrackDisplayTest(int num)
        {
            
            _logger = new FileLogger();

            _trafficController = Substitute.For<ConsoleAirTrafficController>();
                
            _uutOutputter.Logger = _logger;
            _logger.PathToFile = _logFile;
            
            _uutOutputter.TrafficController = _trafficController;

            _tracks =  FakeTrackFactory.GetMultipleTracksWithTags(num);

            _airspace.Trackables = _tracks;
            
            
            _uutOutputter.UpdateTrackDisplay(_airspace);


            _uutOutputter.TrafficController.Received(1).DisplayTracks(_tracks);

        }


        
    }
}
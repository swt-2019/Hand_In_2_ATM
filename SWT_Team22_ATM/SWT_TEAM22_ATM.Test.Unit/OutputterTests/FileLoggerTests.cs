using System.IO;
using NUnit.Framework;
using SWT_Team22_ATM;
using SWT_Team22_ATM.Domains;
using ILogger = Castle.Core.Logging.ILogger;

namespace SWT_TEAM22_ATM.Test.Unit
{
    [TestFixture]
    public class FileLoggerTests
    {
        private SWT_Team22_ATM.ILogger _logger;
        private string _logFile;
        private ITrack _track1;
        private ITrack _track2;
        private FileStream _fileStream;
        

        [SetUp]
        public void FileLogger_Setup()
        {
            _logger = new FileLogger();
            _logFile = "../../TestLog.txt";
            
            _track1 = FakeTrackFactory.GetTrackWithTag("Tag1", 1, 2, 3);
            _track2 = FakeTrackFactory.GetTrackWithTag("Tag2", 4, 5, 6);



        }

        [TearDown]
        public void FileLogger_Cleanup()
        {
            File.Delete(_logFile);
        }


        [Test]
        public void LogConditionCreateFile_Test()
        {
            _logger.PathToFile = _logFile;
            _logger.LogCondition(_track1,_track2);
            
            Assert.True(File.Exists(_logFile));
        }
        
        
        [Test]
        public void LogCondition_Test()
        {
            _logger.PathToFile = _logFile;
            _logger.LogCondition(_track1,_track2);
            string text;
            using (var streamReader = new StreamReader(new FileStream(_logFile, FileMode.Open, FileAccess.Read)))
            {
                text = streamReader.ReadLine();
            }

            string compare = "Condition detected between " + _track1.Tag + " & " + _track2.Tag;
            
            StringAssert.Contains(compare,text);


        }

        
        

    }
}
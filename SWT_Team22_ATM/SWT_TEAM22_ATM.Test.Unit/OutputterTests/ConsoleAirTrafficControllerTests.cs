using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NSubstitute.Extensions;
using NUnit.Framework;
using SWT_Team22_ATM;
using SWT_Team22_ATM.ConditionDetector;
using SWT_Team22_ATM.Domains;

namespace SWT_TEAM22_ATM.Test.Unit
{
    [TestFixture]
    public class ConsoleAirTrafficControllerTests
    {
        private FakeConsoleAirTrafficController _uutTrafficController;
        private List<ITrack> _tracks;
        private List<ConditionEventArgs> _condtions;

        [SetUp]
        public void ConsoleAirTrafficController_Setup() 
        {
            _tracks = new List<ITrack>();
            _condtions = new List<ConditionEventArgs>();
            _uutTrafficController = new FakeConsoleAirTrafficController();
        }



        [TestCase("Test1",1,2,4)]
        [TestCase("Test2",7,7,3)]
        [TestCase("Test3",2,6,3)]
        [TestCase("Test4",3,7,3)]
        public void Traffic_Controller_Console_Display_Test(string tag, int x, int y, int z)
        {
            _tracks.Add(FakeTrackFactory.GetTrackWithTag(tag, x, y, z));
            _uutTrafficController.DisplayTracks(_tracks);

            string compare = "Tag: " + tag + "Pos X: " + x + "Pos Y: " + y;

            StringAssert.Contains(compare, _uutTrafficController.Output);
        }


        [TestCase("Test1",1,2,4,"Test1.2",1,2,4)]
        [TestCase("Test2",7,7,3,"Test2.2",8,2,4)]
        [TestCase("Test3",2,6,3,"Test3.2",2,5,7)]
        [TestCase("Test4",3,7,3,"Test4.2",1,5,1)]
        public void Traffic_Controller_Console_Display_Test_Condition(string tag1, int x1, int y1, int z1, string tag2, int x2, int y2, int z2)
        {
            var track1 = FakeTrackFactory.GetTrackWithTag(tag1, x1, y1, z1);
            var track2 = FakeTrackFactory.GetTrackWithTag(tag2, x2, y2, z2);
            
            _tracks.Add(track1);
            _tracks.Add(track2);

            var condition = new ConditionEventArgs(track1, track2);
            _condtions.Add(condition);


            
            

            _uutTrafficController.DisplayConditions(_condtions);

            var compare = "Condition detected between " + track1.Tag + " & " + track2.Tag;

            StringAssert.Contains(compare,_uutTrafficController.Condition);
        }
        
        
        
        
        
    
    
        

    }
    
}
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using SWT_Team22_ATM;
using SWT_Team22_ATM.Domains;

namespace SWT_TEAM22_ATM.Test.Unit
{
    public class FakeConsoleAirTrafficController : ITrafficController
    {
        public string Output { get; set; }
        public string Condition { get; set; } = "";
        public void DisplayTracks(List<ITrack> trackables)
        {
            var track = trackables.First();
            Output = ("Tag: " + track.Tag + "Pos X: " + track.TrackPosition.XCoordinate + "Pos Y: " + track.TrackPosition.YCoordinate);
        }                                                                              

        public void DisplayConditions(List<Condtion> condtions, List<ITrack> trackables)
        {
            Condition = ("Condition detected between " + condtions[0].Track1.Tag + " & " + condtions[0].Track2.Tag);
            DisplayTracks(trackables);
        }
    }
}
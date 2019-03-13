using System;
using System.Collections.Generic;
using System.Security.Policy;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM
{
    public class ConsoleAirTrafficController : ITrafficController
    {
        public void DisplayTracks(List<ITrack> trackables)
        {
            Console.WriteLine("All flights in airspace:");
            foreach (var track in trackables)
            {
                Console.WriteLine("Tag: " + track.Tag + "Pos X: " + track.TrackPosition.XCoordinate + "Pos Y:" + track.TrackPosition.YCoordinate);
            }
        }

        public void DisplayConditions(ITrack track1, ITrack track2, List<ITrack> trackables)
        {
            Console.WriteLine("Condition detected between " + track1.Tag + " & " + track2.Tag);
            DisplayTracks(trackables);
        }
    }
}
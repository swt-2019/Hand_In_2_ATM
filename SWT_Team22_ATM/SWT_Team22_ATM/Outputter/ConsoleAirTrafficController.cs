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

        public void DisplayConditions(List<Condtion> conditions, List<ITrack> trackables)
        {
            foreach (var condition in conditions)
            {
                Console.WriteLine("Condition detected between " + condition.Track1.Tag + " & " + condition.Track2.Tag);
            }
            
            DisplayTracks(trackables);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;

namespace SWT_TEAM22_ATM.Test.Unit
{
    public class FakeTrackFactory
    {
        public static ITrack GetTrack(int x, int y, int z)
        {
            return new Track()
            {
                Tag = "ABC",
                TimeStamp = "20151006213456789",
                TrackPosition =  new Position(x,y,z)
            };
        }

        public static ITrack GetTrackWithTime(string time, int x, int y, int z)
        {
            return new Track()
            {
                TimeStamp = time,
                TrackPosition = new Position(x, y, z)
            };
        }

        public static ITrack GetTrackWithTag(string tag,int x, int y, int z)
        {
            return new Track()
            {
                Tag = tag,
                TimeStamp = "20151006213456789",
                TrackPosition =  new Position(x,y,z)
            };
        }

        public static List<ITrack> GetMultipleTracksWithTags(int number)
        {
            var rand = new Random();
            var tracks = new List<ITrack>();

            for (int i = 0; i < number; i++)
            {
                var x = rand.Next(1, 100);
                var y = rand.Next(1, 100);
                var z = rand.Next(1, 100);


                tracks.Add(FakeTrackFactory.GetTrackWithTag("Track " + i+1, x, y, z));
               
            }

            return tracks;
            
        }

    }
}

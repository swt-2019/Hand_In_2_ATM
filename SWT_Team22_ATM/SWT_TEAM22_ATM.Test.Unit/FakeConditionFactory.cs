using System;
using System.Collections.Generic;
using SWT_Team22_ATM.Domains;

namespace SWT_TEAM22_ATM.Test.Unit
{
    public class FakeConditionFactory
    {
        public static List<Condtion> CreateConditionList(int numberOfConditions)
        {
            var rand = new Random();
            var conditions = new List<Condtion>();

            for (int i = 0; i < numberOfConditions; i++)
            {
                var x = rand.Next(1, 100);
                var y = rand.Next(1, 100);
                var z = rand.Next(1, 100);


                var track1 = FakeTrackFactory.GetTrackWithTag("Track1," + i, x, y, z);
                var track2 = FakeTrackFactory.GetTrackWithTag("Track2," + i, x+4, y+5, z-7);

                var cond = new Condtion {Track1 = track1, Track2 = track2};
                
                conditions.Add(cond);

            }

            return conditions;
        }


       
    }
}
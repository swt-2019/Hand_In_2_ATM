using System;
using System.Collections.Generic;
using SWT_Team22_ATM.ConditionDetector;
using SWT_Team22_ATM.Domains;

namespace SWT_TEAM22_ATM.Test.Unit
{
    public class FakeConditionFactory
    {
        public static List<ConditionEventArgs> CreateConditionList(int numberOfConditions)
        {
            var rand = new Random();
            var conditions = new List<ConditionEventArgs>();

            for (int i = 0; i < numberOfConditions; i++)
            {
                var x = rand.Next(1, 100);
                var y = rand.Next(1, 100);
                var z = rand.Next(1, 100);


                var track1 = FakeTrackFactory.GetTrackWithTag("Track1," + i, x, y, z);
                var track2 = FakeTrackFactory.GetTrackWithTag("Track2," + i, x+4, y+5, z-7);

                var cond = new ConditionEventArgs(track1,track2);
                
                conditions.Add(cond);

            }

            return conditions;
        }


       
    }
}
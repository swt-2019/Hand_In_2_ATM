using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.interpreter
{
    class TransponderDataInterpreter : Iinterpret
    {
        public Track interpret(string TransponderData)
        {
            // ATR423;39045;12932;14000;20151006213456789 

            string[] s = TransponderData.Split(';');

            Track t = new Track();
            Position p = new Position();

            t.Tag = s[0];


            int x;
            int y;
            if (Int32.TryParse(s[1], out x))
            {
                p.XCoordinate = x;
            }

            if (Int32.TryParse(s[2], out y))
            {
                p.YCoordinate = y;
            }

            t.TrackPosition = p;

            int a;
            if (Int32.TryParse(s[3], out a))
            {
                t.TrackPosition.ZCoordinate = a;
            }

            t.TimeStamp = s[4];

            return t;

        }
    }
}

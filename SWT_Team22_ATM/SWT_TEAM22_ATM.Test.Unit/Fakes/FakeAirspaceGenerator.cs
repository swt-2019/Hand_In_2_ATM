using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;

namespace SWT_TEAM22_ATM.Test.Unit
{
    public class FakeAirspaceGenerator
    {
        public static Airspace GetAirspace(int x, int y, int z)
        {
            return new Airspace()
            {
                AirspacePosition = new Position(x,y,z),
                VerticalStart = 500,
                VerticalEnd = 5000,
                HorizontalSize = 80000
            };
        }
    }
}

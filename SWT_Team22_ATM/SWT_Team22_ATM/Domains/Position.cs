using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Team22_ATM.Domains
{
    public class Position
    {
        public Position()
        {
            
        }
        public Position(int x, int y, int z)
        {
            XCoordinate = x;
            YCoordinate = y;
            ZCoordinate = z;
        }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int ZCoordinate { get; set; }
    }
}

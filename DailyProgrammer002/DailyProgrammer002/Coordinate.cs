using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer002
{
    class Coordinate
    {
        public int Row
        {
            public get;
            public set;
        }

        public int Column
        {
            public get;
            public set;
        }

        public Coordinate(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}

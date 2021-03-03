using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2.Lib
{
    class Point
    {
        int _x, _y;
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public List<int> GetCoord
        { get { return new List<int> { _x, _y }; } }
    }
}

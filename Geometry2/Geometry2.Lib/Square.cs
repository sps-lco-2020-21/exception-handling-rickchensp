using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2.Lib
{
    public class Square : IShape,IEquatable<Square>
    {
        int _sideLength;
        List<int> _coord1, _coord2, _coord3, _coord4;
        public Square(int side, List<int> coord)
        {
            _sideLength = side;
            Point coord1 = new Point(coord[0], coord[1]);

        }

        public bool Equals(Square s)
        {
            return _sideLength == s._sideLength;
        }
        public double Perimeter()
        {
            return _sideLength * 4;
        }
        public double Area()
        {
            return _sideLength * _sideLength;
        }

        public int NumOfSides
        {
            get { return 4; }
        }

        public int CompareTo(IShape obj)
        {
            if (obj.Area() > Area())
            {
                return -1;
            }
            else if (obj.Area() == Area())
            {
                return 0;
            }
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2.Lib
{
    public class Circle : IShape, IEquatable<Circle>
    {
        int _x;
        int _y;
        int _r;
        public Circle(int x, int y, int r)
        {
            _x = x;
            _y = y;
            _r = r;
        }

        public double Area()
        {
            return Math.PI * _r * _r;
        }

        public double Perimeter()
        {
            return 2 * Math.PI * _r;
        }

        public int NumOfSides
        { get { return 1; } }

        public bool Equals(Circle other)
        {
            return _r == other._r && _x == other._x && _y == other._y;
        }

        public bool IsIn(int pointX, int pointY)
        {
            double distance = Math.Sqrt(Math.Pow(pointX - _x, 2) + Math.Pow(pointY - _y, 2));
            return distance <= _r;
        }

        public bool PassesThrough(string equation)    //e.g. 5x-3y=8
        {
            List<string> terms = equation.Split(new char[] {'=', 'x', 'y'}, StringSplitOptions.RemoveEmptyEntries).ToList();

            int A = int.Parse(terms[0]);
            int B = int.Parse(terms[1]);
            int C = int.Parse(terms[2]);

            //distance of point to line 
            double distance = Math.Abs(A * _x + B * _y + C) / Math.Sqrt(A * A + B * B);
            if(distance <= _r)
            {
                return true;
            }

            return false;
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

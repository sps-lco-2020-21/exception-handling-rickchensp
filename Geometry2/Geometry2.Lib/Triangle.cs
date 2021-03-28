using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2.Lib
{
    public class Triangle : IShape, IEquatable<Triangle>
    {
        const int NUMBEROFSIDES = 3;

        int _sideA, _sideB, _sideC;   //private
        int _angleA, _angleB, _angleC;
        List<int> _sides = new List<int> { };
        public Triangle(int a, int b, int c)
        { 
            _sideA = a;
            _sideB = b;
            _sideC = c;

            _sides.Add(a);
            _sides.Add(b);
            _sides.Add(c);
            _sides.Sort(); //sides are sorted by length

            if(_sides[0] + _sides[1] <= _sides[2])
            {
                throw new TriangleExceptions(1, "The sidelengths were invalid when trying to construct a triangle");
            }

            //using cosine rule and sine rule
            _angleA = Convert.ToInt32(Math.Acos((double)(b * b + c * c - a * a) / (2 * b * c)) * 180 / Math.PI); 
            _angleB = Convert.ToInt32(Math.Asin((b * Math.Sin(_angleA * Math.PI/180) / a)) * 180 / Math.PI);
            _angleC = Convert.ToInt32(180 - _angleA - _angleB);
        }

        public Triangle(int e) : this(e, e, e)
        {

        }

        
        public void setSides(int a, int b, int c)
        {
            if (newSidesValid(a, b, c))
            {
                _sides[0] = a;
                _sides[1] = b;
                _sides[2] = c;
                _sides.Sort();
            }
            else throw new TriangleExceptions(2, "The sidelengths were invalid when trying to set the sides of a triangle");

        }

        public int NumOfSides
        {
            get { return 3; }     //int x = t.NumberOfSides
        }

        public double Perimeter()
        {
            return _sides.Sum();
        }

        public bool IsRightAngled
        {
            get { return _sides[0] * _sides[0] + _sides[1] * _sides[1] == _sides[2] * _sides[2]; }
        }
        public bool newSidesValid(int a, int b, int c)   //used for changing the sides
        {
            List<int> sides = new List<int> { a, b, c };
            sides.Sort();
            bool notNegative = sides.Any(x => x > 0);
            return notNegative && sides[2] < sides[1] + sides[0];
        }

        public bool IsIsosceles
        {
            get { return (_sides[0] == _sides[1] || _sides[1] == _sides[2]); }
        }

        public bool IsEquilateral
        {
            get { return (_sideA == _sideB && _sideB == _sideC); }
        }

        public List<int> ThreeSides
        {
            get { return _sides; }
        }

        public List<int> ThreeAngles
        {

            get { return new List<int> { _angleA, _angleB, _angleC }; }
        }

        public double Area()
        {
            return Convert.ToInt32(0.5 * _sideA * _sideB * Math.Sin(_angleC * (Math.PI / 180)));
        }


        public bool IsCongruent(Triangle t)
        {
            foreach (int side in t.ThreeSides)
            {
                if((ThreeSides).Contains(side))
                {
                    continue;
                }
                return false;
            }

            return true;

        }

        public bool Equals(Triangle other)
        {
            return _sides.Equals(other._sides);
        }

        public int CompareTo(IShape obj)
        {
            if(obj.Area() > Area())
            {
                return -1;
            }
            else if(obj.Area() == Area())
            {
                return 0;
            }
            return 1;
        }
    }
}

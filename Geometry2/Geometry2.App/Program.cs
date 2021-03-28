using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry2.Lib;

namespace Geometry2.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape> { };
            IShape triangle = new Triangle(6, 8, 10);
            TestTriangle();
            TestCircle();
            TestSquare();

            shapes.Add(triangle);
            IShape c1 = new Circle(2, 5, 9);
            shapes.Add(c1);
            IShape s1 = new Square(4, new List<int> { 10, 0 });
            shapes.Add(s1);

            double sumArea = shapes.Sum(x => x.Area());
            double sumPerimeter = shapes.Sum(x => x.Perimeter());

            Debug.Assert(triangle.CompareTo(s1) == 1);

            //circles
            Console.ReadKey();
        }

        private static void TestTriangle()
        {
            Triangle t = new Triangle(3, 4, 5);   //instantiation
            Triangle t2 = new Triangle(8, 10, 10);
            Triangle t3 = new Triangle(4, 5, 3);

            Debug.Assert(t.Perimeter() == 12);

            Debug.Assert(t.IsRightAngled == true);
            Debug.Assert(t.IsIsosceles == false);
            Debug.Assert(t.IsEquilateral == false);
            Debug.Assert(t.Area() == 6);

            List<int> angles = t.ThreeAngles;
            List<int> sides = t.ThreeSides;

            Debug.Assert(t.IsCongruent(t3) == true);
            Debug.Assert(t.IsCongruent(t2) == false);

            t2.setSides(7, 10, 10);
            Debug.Assert(t2.ThreeSides[0] == 7);
        }

        private static void TestCircle()
        {
            Circle c = new Circle(2, 3, 4);
            Debug.Assert(c.Area() == 16 * Math.PI);
            Debug.Assert(c.Perimeter() == 8 * Math.PI);
            Debug.Assert(c.IsIn(3, 4) == true);
            Debug.Assert(c.IsIn(10, 100) == false);
            Debug.Assert(c.PassesThrough("5x-3y=30") == false);
            Debug.Assert(c.PassesThrough("5x-3y=8") == true);
        }

        private static void TestSquare()
        {
            Square s1 = new Square(3, new List<int> { 1, 3 });
            Square s2 = new Square(3, new List<int> { 2, 2 });
            Debug.Assert(s1.Equals(s2));
        }
    }
}

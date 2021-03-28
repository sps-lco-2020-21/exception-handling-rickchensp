using System;

namespace Geometry2.Lib
{
    public interface IShape : IComparable<IShape>
    {
        int NumOfSides { get; }
        double Area();
        double Perimeter();

        
    }
}
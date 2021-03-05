using Geometry2.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Geometry2.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        [ExpectedException(typeof(TriangleExceptions))]
        public void TestTriangleConstructorException()
        {
            Triangle t = new Triangle(2, 3, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TriangleExceptions))]
        public void TestTriangleSetsidesException()
        {
            Triangle t = new Triangle(3, 4, 5);
            t.setSides(2, 3, 10);
        }
        
        [TestMethod]
        public void TestTriangleSetsides()
        {
            Triangle t = new Triangle(3, 4, 5);
            t.setSides(2, 3, 4);
            CollectionAssert.AreEqual(t.ThreeSides, new List<int> { 2, 3, 4});
        }
    }
}

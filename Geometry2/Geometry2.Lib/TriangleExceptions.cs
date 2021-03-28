using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2.Lib
{
    public class TriangleExceptions : Exception
    {
        int _codenumber;
        public TriangleExceptions(int codenumber, string msg) : base(msg)
        {
            _codenumber = codenumber;
        }

        public override string Message
        { 
            get
            {
                return $"Code  {_codenumber}: {base.Message} ";
            } 
        }



    }
}

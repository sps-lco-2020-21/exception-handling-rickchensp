using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsNew.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoubleExceptions("3.14");
            ToDoubleExceptions("double");
            ToDoubleExceptions(Convert.ToString(Double.MaxValue + 1));
            Console.ReadKey();
        }

        static void ToDoubleExceptions(string doubleStr)
        {
            double num = 0;
            try
            {
                num = Convert.ToDouble(doubleStr);
            } catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            } catch(OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine(num * 2);
            }
        }
    }
}

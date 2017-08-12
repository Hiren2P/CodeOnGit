using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MathProxy  _mathProxy = new MathProxy();
            Console.WriteLine("2 + 2 = {0}", _mathProxy.Add(2, 2));
            Console.WriteLine("2 - 2 = {0}", _mathProxy.Subtract(2, 2));
            Console.WriteLine("2 * 2 = {0}", _mathProxy.Multiply(2, 2));
            Console.WriteLine("2 / 2 = {0}", _mathProxy.Divide(2, 2));
            Console.ReadKey();
        }
    }
}

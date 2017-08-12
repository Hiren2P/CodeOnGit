using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxyPattern
{
    class Math : IMath
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            return a / b;
        }
    }

    interface IMath
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);
    }

    public class MathProxy : IMath
    {
        private Math _math = new Math();
        public int Add(int a, int b)
        {
            return _math.Add(a, b);
        }

        public int Subtract(int a, int b)
        {
            return _math.Subtract(a, b);
        }

        public int Multiply(int a, int b)
        {
            return _math.Multiply(a, b);
        }

        public int Divide(int a, int b)
        {
            return _math.Divide(a, b);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLibrary
{
    //Delegate callback example.

    class Delegates
    {
        public Delegates()
        {
            AnotherClass o = new AnotherClass();
            o.AnotherMethod(Callback);
        }
        public static void Callback(int i)
        {
            Console.WriteLine(i);
        }
    }

    class AnotherClass
    {
        public delegate void CallbackDelegate(int currentIteration);
        public void AnotherMethod(CallbackDelegate obj)
        {
            for (int i = 0; i < 1000; i++)
            {
                obj(i);
            }
        }
    }
}

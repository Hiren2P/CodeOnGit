using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cons = System.Console;
using System.Reflection;

namespace CsharpLibrary
{
    public class MixedCodes
    {
        public void CallLocalMethods()
        {
            SystemReflection();
        }

        [STAThread]
        public void SystemReflection()
        {
            Console.WriteLine("\nReflection.MethodInfo");
            MixedCodes mixedCodes = new MixedCodes();
            Type ty = mixedCodes.GetType();
            System.Reflection.MethodInfo mi = ty.GetMethod("SystemReflection");
            // Get and display the Invoke method.
            mi.Invoke(mixedCodes, new object[] { 10 });
        }
    }
}

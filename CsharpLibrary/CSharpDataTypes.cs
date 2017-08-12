using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cons = System.Console;
using System.Globalization;

namespace CsharpLibrary
{
    public class CSharpDataTypes
    {
        public static void CallLocalMethods()
        {
            Object();
            DynamicType();
            VarType();
        }

        //object datatype - which is short hand operator for System.Object which in turns is base class for all C# objects
        public static void Object()
        {
            object obj = new object();
            obj = 10;
            cons.WriteLine("obj : {0}", obj);
            cons.WriteLine("obj Type : {0}", obj.GetType());
            cons.WriteLine("obj ToString() : {0}", obj.ToString());
        }

        //Dynamic data type - for handling compile time exceptions as compared to Object
        public static void DynamicType()
        {
            dynamic dynamic = "420";
            cons.WriteLine("dynamic : {0}", dynamic.Substring(0, 1));//one should have methods idea of the data type stored in dynamic, mostly used for COM and reflection
        }

        //Can't be a parameter or return type in/for a method. Used in its scope only. Especially used for linq results
        public static void VarType()
        {
            var var = 123;
            cons.WriteLine("var type : {0}", var.GetType());
            cons.WriteLine("var ToString() : {0}", var.ToString());
        }

        //DateTime data type
        public static void DateTimeType()
        {
            DateTime dt;
            if (DateTime.TryParseExact("120430", "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                Console.WriteLine(dt.ToString());
            }
        }
    }
}

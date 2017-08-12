using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            SingletonClass sc1 = SingletonClass.GetInstance();
            SingletonClass sc2 = SingletonClass.GetInstance();
            if (sc1 == sc2)
            {
                Console.WriteLine("Objects  are same :)");
            }
            else
            {
                Console.WriteLine("Objects are not same :(");
            }
            Console.ReadKey();
        }
    }
}

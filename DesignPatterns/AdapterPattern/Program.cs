using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Hiren", "Patel", 26);
            p1.DispalyData();

            Person s1 = new Student("abc", "xyz", 12);
            s1.DispalyData();

            Console.ReadKey();
        }
    }
}

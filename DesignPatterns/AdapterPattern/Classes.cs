using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{
    /// <summary>
    /// This is target class.
    /// </summary>
    public class Person
    {
        protected string firstName;
        protected string lastName;
        protected int age;
        protected int nameLength;

        public Person(string fName, string lName, int pAge)
        {
            this.firstName = fName;
            this.lastName = lName;
            this.age = pAge;
        }

        public virtual void DispalyData()
        {
            Console.WriteLine("First name :{0}\tLast name :{1}\tAge : {2}", this.firstName, this.lastName, this.age);
        }
    }

    /// <summary>
    /// This is the adapter class which inherits target class.
    /// </summary>
    public class Student : Person
    {
        private Adaptee _adaptee;
        public Student(string fName, string lName, int pAge)
            : base(fName, lName, pAge)//This will call constructor of base class and assign object values.
        {

        }

        public override void DispalyData()
        {
            _adaptee = new Adaptee();
            nameLength = _adaptee.GetNameLength(this.firstName, this.lastName);

            base.DispalyData();
            Console.WriteLine("\tName length :{0}", nameLength);
        }
    }

    public class Adaptee
    {
        public int GetNameLength(string fName, string lName)
        {
            return (fName.Length + lName.Length);
        }
    }
}
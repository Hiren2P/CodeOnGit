using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLibrary
{
    public class DelegateAndEventHandler
    {
        public void TestHandler()
        {
            Emp objEmp = new Emp();
            objEmp.EmpIdChanged += new EventHandler(emp_IdChanged);
            objEmp.EmpNameChanged += new EventHandler(emp_NameChanged);
            objEmp.EmpCityChanged += new EventHandler(emp_CityChanged);

            objEmp.MultiDelegate += new EventHandler(emp_IdChanged);
            objEmp.MultiDelegate += new EventHandler(emp_NameChanged);
            objEmp.MultiDelegate += new EventHandler(emp_CityChanged);

            objEmp.MultiDelegate += new EventHandler(emp_IdChanged);
            objEmp.MultiDelegate += new EventHandler(emp_NameChanged);
            objEmp.multiMinusDelegate += new EventHandler(emp_CityChanged);
            objEmp.multiMinusDelegate -= new EventHandler(emp_CityChanged);

            objEmp.EID = 1;
            objEmp.EName = "Hiren";
            objEmp.City = "Kalol";
            Console.ReadKey();
        }

        //Actual method implemetation
        static void emp_IdChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Id changed");
        }

        static void emp_NameChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Name changed");
        }

        static void emp_CityChanged(object sender, EventArgs e)
        {
            Console.WriteLine("City changed");
        }
    }

    //Event handlers
    public class Emp
    {
        public event EventHandler EmpIdChanged;
        public event EventHandler EmpNameChanged;
        public event EventHandler EmpCityChanged;
        public event EventHandler MultiDelegate;
        public event EventHandler multiMinusDelegate;

        private int _eID;
        //EID
        public int EID
        {
            get { return this._eID; }
            set
            {
                this._eID = value;
                if (this.EmpIdChanged != null)
                {
                    this.EmpIdChanged(this, new EventArgs());
                }
                if (this.MultiDelegate != null)
                {
                    this.MultiDelegate(this, new EventArgs());
                }
                if (this.multiMinusDelegate != null)
                {
                    this.multiMinusDelegate(this, new EventArgs());
                }
            }
        }

        private string _eName;
        //Ename
        public string EName
        {
            get { return this._eName; }
            set
            {
                this._eName = value;
                if (this.EmpIdChanged != null)
                {
                    this.EmpIdChanged(this, new EventArgs());
                }
                if (this.MultiDelegate != null)
                {
                    this.MultiDelegate(this, new EventArgs());
                }
                if (this.multiMinusDelegate != null)
                {
                    this.multiMinusDelegate(this, new EventArgs());
                }
            }
        }

        private string _city;
        //City
        public string City
        {
            get { return this._city; }
            set
            {
                this._city = value;
                if (this.EmpIdChanged != null)
                {
                    this.EmpIdChanged(this, new EventArgs());
                }
                if (this.MultiDelegate != null)
                {
                    this.MultiDelegate(this, new EventArgs());
                }
                if (this.multiMinusDelegate != null)
                {
                    this.multiMinusDelegate(this, new EventArgs());
                }
            }
        }

        //Default Constructor
        public Emp()
        {
            //Console.WriteLine("Emp instance created");
        }
    }
}

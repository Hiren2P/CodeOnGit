using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonPattern
{
    public class SingletonClass
    {
        private static SingletonClass instance;

        public static SingletonClass GetInstance()
        {
            if (instance == null)
            {
                instance = new SingletonClass();
            }
            return instance;
        }

        protected SingletonClass()
        {
            ;
        }
    }
}

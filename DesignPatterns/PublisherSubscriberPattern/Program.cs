using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace PublisherSubscriberPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();

            IExchangeRateSubscriber subscriber1 = new Subscriber1();
            IExchangeRateSubscriber subscriber2 = new Subscriber2();

            publisher.AddSubscriber(subscriber1);
            publisher.AddSubscriber(subscriber2);

            publisher.initializeService();
            Console.ReadKey();
        }
    }
}

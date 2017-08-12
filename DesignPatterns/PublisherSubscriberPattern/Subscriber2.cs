using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublisherSubscriberPattern
{
    public class Subscriber2 : IExchangeRateSubscriber
    {
        public void UpdateRates(query currentExchangeRate, query lastExchangeRate)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("-----------------Subscriber - 2-----------------");
            Console.WriteLine("------------------------------------------------");
            DisplayUpdates(currentExchangeRate, lastExchangeRate);
        }

        /// <summary>
        /// Display updates on the screen.
        /// </summary>
        /// <param name="objQuery">Updated exchange rates instance</param>
        public void DisplayUpdates(query currentExchangeRate, query lastExchangeRate)
        {
            for (int itemCounter = 0; itemCounter < currentExchangeRate.Items[0].rate.Count(); itemCounter++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("{0} : ", ((queryResultsRate)(currentExchangeRate.Items[0].rate[itemCounter])).Name);
                if (lastExchangeRate.Items != null)
                {
                    if (((queryResultsRate)(currentExchangeRate.Items[0].rate[itemCounter])).Rate != ((queryResultsRate)(lastExchangeRate.Items[0].rate[itemCounter])).Rate)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
                Console.Write("{0}\n", ((queryResultsRate)(currentExchangeRate.Items[0].rate[itemCounter])).Rate);
            }
        }
    }
}

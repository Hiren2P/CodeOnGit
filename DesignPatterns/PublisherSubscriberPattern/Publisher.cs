using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Threading;

//Observer pattern implementation with notification approach.
namespace PublisherSubscriberPattern
{
    public class Publisher : IExchangeRatePublisher
    {
        IList<IExchangeRateSubscriber> subscribers = new List<IExchangeRateSubscriber>();
        query currentExchangeRate = new query();
        query lastExchangeRate = new query();

        Random r = new Random();//Remove this line when checking in real-time

        /// <summary>
        /// Start up function
        /// </summary>
        public void initializeService()
        {
            XElement root = XElement.Load("http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.xchange%20where%20pair%20in%20(%22USDJPY%22,%20%22USDGBP%22,%20%22USDINR%22)&env=store://datatables.org/alltableswithkeys");//Yahoo Api that returns exchange rates as XML document
            Console.Clear();
            Console.WriteLine("Last updated at : {0}", DateTime.Now.ToString());
            currentExchangeRate = (query)CreateObject(root.ToString(), new query());

            //Notify observers about the update
            notifyObservers();

            UpdateExchangeRates();
        }

        private void UpdateExchangeRates()
        {
            try
            {
                Thread.Sleep(10000);//Wait for 10 seconds between updates

                XElement root = XElement.Load("http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.xchange%20where%20pair%20in%20(%22USDJPY%22,%20%22USDGBP%22,%20%22USDINR%22)&env=store://datatables.org/alltableswithkeys");//Yahoo Api that returns exchange rates as XML document
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Last updated at : {0}", DateTime.Now.ToString());
                lastExchangeRate = currentExchangeRate;
                lastExchangeRate.Items[0].rate[r.Next(3)].Rate = "0";//Remove this line when checking in real-time
                currentExchangeRate = (query)CreateObject(root.ToString(), currentExchangeRate);

                //Notify observers about the update
                notifyObservers();

                UpdateExchangeRates();//Recursive call
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Xml to Object(Deserialization)
        /// </summary>
        /// <param name="xml">XML in string format</param>
        /// <param name="obj">Object to which XML needs to be deserialised</param>
        /// <returns>Deserialised object</returns>
        private Object CreateObject(string xml, Object obj)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                obj = xmlSerializer.Deserialize(new StringReader(xml));
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Object to XML
        /// </summary>
        /// <param name="objectToConvert">Object to be converted to XML</param>
        /// <returns>Serialised object as XML string</returns>
        private string CreateXML(Object objectToConvert)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer xmlSerializer = new XmlSerializer(objectToConvert.GetType());
                using (MemoryStream xmlStream = new MemoryStream())
                {
                    xmlSerializer.Serialize(xmlStream, objectToConvert);
                    xmlDocument.Load(xmlStream);
                    return xmlDocument.InnerXml;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        ///// <summary>
        ///// Enum of currencies
        ///// </summary>
        //enum Currencies
        //{
        //    USDINR,
        //    USDGBP,
        //    USDJPY
        //}

        ///// <summary>
        ///// Console colors enum just to notify an update has been displayed
        ///// </summary>
        //enum ConsoleColors
        //{
        //    Yellow,
        //    Blue,
        //    Green
        //}

        /// <summary>
        /// Method registers a new subscriber.
        /// </summary>
        /// <param name="subscriber">Subscriber to register</param>
        public void AddSubscriber(IExchangeRateSubscriber subscriber)
        {
            try
            {
                if (!subscribers.Contains(subscriber))
                    subscribers.Add(subscriber);
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Subscriber already registered!!!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Method unregisters the subscriber.
        /// </summary>
        /// <param name="subscriber">Subscriber to unregister</param>
        public void RemoveSubscriber(IExchangeRateSubscriber subscriber)
        {
            try
            {
                if (subscribers.Contains(subscriber))
                    subscribers.Remove(subscriber);
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Subscriber not registered yet!!!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Method notifies subscribers about change in exchange rate
        /// </summary>
        /// <param name="updatedRates"></param>
        private void notifyObservers()
        {
            foreach (IExchangeRateSubscriber subscriber in subscribers)
                subscriber.UpdateRates(currentExchangeRate, lastExchangeRate);
        }
    }
}

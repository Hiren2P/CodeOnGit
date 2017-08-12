using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublisherSubscriberPattern
{
    public interface IExchangeRatePublisher
    {
        void AddSubscriber(IExchangeRateSubscriber subscriber);
        void RemoveSubscriber(IExchangeRateSubscriber subscriber);
    }
}

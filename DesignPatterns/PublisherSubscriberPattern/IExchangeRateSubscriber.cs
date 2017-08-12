using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublisherSubscriberPattern
{
    public interface IExchangeRateSubscriber
    {
        void UpdateRates(query currentExchangeRate, query lastExchangeRate);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFLibrary;
using System.ServiceModel;
using CsharpLibrary.ArithmeticService;

namespace CsharpLibrary
{
    public class ConsumeWCFService
    {
        public static void CallServiceUsingProxy()
        {
            try
            {
                string soapHeader = "";
                ArithmeticService.ContractsClient objContract = new ArithmeticService.ContractsClient();
                int res = objContract.DivWithSoapReqRes(ref soapHeader, 1, 1);
                Console.WriteLine("Result :: {0}", res.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CallServiceUsingChannelFactory()
        {
            try
            {
                WCFLibrary.Contracts.RequestMessage objReq = new WCFLibrary.Contracts.RequestMessage();
                objReq.operand1 = 1;
                objReq.operand2 = 1;

                var channelFactory = new ChannelFactory<WCFLibrary.IContracts>("BasicHttpBinding_IContracts");
                WCFLibrary.IContracts channel = channelFactory.CreateChannel();
                WCFLibrary.Contracts.ReponseMessage response = channel.DivWithSoapReqRes(objReq);
                Console.WriteLine("Result :: ", response.result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

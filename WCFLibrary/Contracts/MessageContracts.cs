using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFLibrary.Contracts
{
    [Serializable]
    [MessageContract(IsWrapped = false)]
    public class RequestMessage
    {
        [MessageHeader]
        public string SoapHeader { get; set; }

        [MessageBodyMember(Name="value1",Namespace="www.tempuri.org")]
        public int operand1;
        [MessageBodyMember(Name = "value2", Namespace = "www.tempuri.org")]
        public int operand2;
    }

    [Serializable]
    [MessageContract(IsWrapped = false)]
    public class ReponseMessage
    {
        [MessageHeader]
        public string SoapHeader { get; set; }

        [MessageBodyMember(Name = "resultValue")]
        public int result;
    }

    [Serializable]
    [MessageContract(IsWrapped = false)]
    public class CustomMessage
    {
        [MessageHeader]
        public string SoapHeader { get; set; }

        [MessageBodyMember(Name = "dataContract")]
        public DataContracts Data;
    }
}
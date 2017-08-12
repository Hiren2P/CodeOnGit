using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFLibrary.Contracts
{
    [DataContract]
    public class DataContracts
    {
        [DataMember(Name="value1")]
        public int op1;

        [DataMember(Name = "value2")]
        public int op2;

        [DataMember(Name = "resultValue")]
        public int result;
    }
}
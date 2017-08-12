using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFaultSample" in both code and config file together.
    [ServiceContract]
    public interface IContracts
    {
        [OperationContract()]
        [FaultContract(typeof(FaultModel))]
        Contracts.ReponseMessage Add(Contracts.RequestMessage reqMessage);

        [OperationContract()]
        [FaultContract(typeof(FaultModel))]
        Contracts.ReponseMessage Sub(Contracts.RequestMessage reqMessage);

        [OperationContract()]
        [FaultContract(typeof(FaultModel))]
        Contracts.ReponseMessage Mul(Contracts.RequestMessage reqMessage);

        [OperationContract()]
        [FaultContract(typeof(FaultModel))]
        Contracts.ReponseMessage DivWithSoapReqRes(Contracts.RequestMessage reqMessage);

        [OperationContract]
        [FaultContract(typeof(FaultModel))]
        Contracts.DataContracts DivWithDataConReqRes(Contracts.DataContracts reqMessage);
    }
}

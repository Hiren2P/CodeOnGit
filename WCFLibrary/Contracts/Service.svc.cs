using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FaultSample" in code, svc and config file together.
    [ServiceBehavior]
    public class Service : IContracts
    {
        [OperationBehavior]
        [FaultContract(typeof(FaultModel))]
        public Contracts.ReponseMessage Add(Contracts.RequestMessage reqMessage)
        {
            try
            {
                Contracts.ReponseMessage objResponse = new Contracts.ReponseMessage();
                objResponse.result = reqMessage.operand1 + reqMessage.operand2;
                return objResponse;
            }
            catch (Exception ex)
            {
                FaultModel objFault = new FaultModel();
                objFault.ErrorMessageForUser = "ADD() Operation terminated";
                objFault.ExceptionMessage = Convert.ToString(ex.Message);
                objFault.InnerException = ex.GetBaseException().ToString();
                objFault.StackTrace = Environment.StackTrace;
                throw new FaultException<FaultModel>(objFault, ex.ToString());
            }
        }

        [OperationBehavior]
        [FaultContract(typeof(FaultModel))]
        public Contracts.ReponseMessage Sub(Contracts.RequestMessage reqMessage)
        {
            try
            {
                Contracts.ReponseMessage objResponse = new Contracts.ReponseMessage();
                objResponse.result = reqMessage.operand1 - reqMessage.operand2;
                return objResponse;
            }
            catch (Exception ex)
            {
                FaultModel objFault = new FaultModel();
                objFault.ErrorMessageForUser = "SUB() Operation terminated";
                objFault.ExceptionMessage = Convert.ToString(ex.Message);
                objFault.InnerException = ex.GetBaseException().ToString();
                objFault.StackTrace = Environment.StackTrace;
                throw new FaultException<FaultModel>(objFault, ex.ToString());
            }
        }

        [OperationBehavior]
        public Contracts.ReponseMessage Mul(Contracts.RequestMessage reqMessage)
        {
            try
            {
                Contracts.ReponseMessage objResponse = new Contracts.ReponseMessage();
                objResponse.result = reqMessage.operand1 * reqMessage.operand2;
                return objResponse;
            }
            catch (Exception ex)
            {
                FaultModel objFault = new FaultModel();
                objFault.ErrorMessageForUser = "MUL() Operation terminated";
                objFault.ExceptionMessage = Convert.ToString(ex.Message);
                objFault.InnerException = ex.GetBaseException().ToString();
                objFault.StackTrace = Environment.StackTrace;
                throw new FaultException<FaultModel>(objFault, ex.ToString());
            }
        }

        [OperationBehavior]
        [FaultContract(typeof(FaultModel))]
        public Contracts.ReponseMessage DivWithSoapReqRes(Contracts.RequestMessage reqMessage)
        {
            try
            {
                Contracts.ReponseMessage objResponse = new Contracts.ReponseMessage();
                objResponse.result = reqMessage.operand1 / reqMessage.operand2;
                return objResponse;
            }
            catch (Exception ex)
            {
                FaultModel objFault = new FaultModel();
                objFault.ErrorMessageForUser = "DIV() Operation terminated";
                objFault.ExceptionMessage = Convert.ToString(ex.Message);
                objFault.InnerException = ex.GetBaseException().ToString();
                objFault.StackTrace = Environment.StackTrace;
                throw new FaultException<FaultModel>(objFault, ex.ToString());
            }
        }

        [OperationBehavior]
        [FaultContract(typeof(FaultModel))]
        public Contracts.DataContracts DivWithDataConReqRes(Contracts.DataContracts reqMessage)
        {
            try
            {
                Contracts.DataContracts objResponse = new Contracts.DataContracts();
                objResponse.result = reqMessage.op1 / reqMessage.op2;
                return objResponse;
            }
            catch (Exception ex)
            {
                FaultModel objFault = new FaultModel();
                objFault.ErrorMessageForUser = "DIV() Operation terminated";
                objFault.ExceptionMessage = Convert.ToString(ex.Message);
                objFault.InnerException = ex.GetBaseException().ToString();
                objFault.StackTrace = Environment.StackTrace;
                throw new FaultException<FaultModel>(objFault, ex.ToString());
            }
        }
    }
}

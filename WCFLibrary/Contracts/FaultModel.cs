using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace WCFLibrary
{
    [DataContract]
    public class FaultModel
    {
        private string _errorMessageForUser;
        private string _exceptionMessage;
        private string _innerException;
        private string _stackTrace;

        [DataMember]
        //Error message for user on screen
        public string ErrorMessageForUser
        {
            get
            {
                if (_errorMessageForUser == null)
                    return string.Empty;
                else
                    return _errorMessageForUser;
            }
            set
            {
                _errorMessageForUser = value;
            }
        }

        [DataMember]
        //Actual exception message
        public string ExceptionMessage
        {

            get
            {
                if (_exceptionMessage == null)
                    return string.Empty;
                else
                    return _exceptionMessage;
            }
            set
            {
                _exceptionMessage = value;
            }
        }

        [DataMember]
        //Inner exception
        public string InnerException
        {
            get
            {
                if (_innerException == null)
                    return string.Empty;
                else
                    return _innerException;
            }
            set
            {
                _innerException = value;
            }
        }

        [DataMember]
        //Stack trace
        public string StackTrace
        {
            get
            {
                if (_stackTrace == null)
                    return string.Empty;
                else
                    return _stackTrace;
            }
            set
            {
                _stackTrace = value;
            }
        }
    }
}
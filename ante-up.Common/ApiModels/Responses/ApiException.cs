using System;

namespace ante_up.Common.ApiModels.Responses
{
    public class ApiException : Exception 
    {
        public int ErrorCode { get;  }
        public string ErrorMessage { get; }
        
        public ApiException(int errorCode, string errorMessage) 
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}
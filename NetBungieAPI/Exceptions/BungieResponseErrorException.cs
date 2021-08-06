using System;
using System.Collections.Generic;
using NetBungieAPI.Models;

namespace NetBungieAPI.Exceptions
{
    public class BungieResponseErrorException : Exception
    {
        public PlatformErrorCodes ErrorCode { get; }
        public string ErrorStatus { get; }
        public string Message { get; }
        public Dictionary<string, string> MessageData { get; }
        
        public BungieResponseErrorException(
            PlatformErrorCodes errorCode, 
            string errorStatus,
            string message,
            Dictionary<string, string> messageData)
        {
            ErrorCode = errorCode;
            ErrorStatus = errorStatus;
            Message = message;
            MessageData = messageData;
        }
    }
}
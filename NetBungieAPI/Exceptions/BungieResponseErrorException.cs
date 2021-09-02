﻿using System;
using System.Collections.Generic;
using NetBungieAPI.Models;

namespace NetBungieAPI.Exceptions
{
    /// <summary>
    /// Exception, based of <see cref="BungieResponse{T}"/>
    /// </summary>
    public class BungieResponseErrorException : Exception
    {
        public PlatformErrorCodes ErrorCode { get; }
        public string ErrorStatus { get; }
        public string ResponseMessage { get; }
        public Dictionary<string, string> MessageData { get; }

        public BungieResponseErrorException(
            PlatformErrorCodes errorCode,
            string errorStatus,
            string responseMessage,
            Dictionary<string, string> messageData)
        {
            ErrorCode = errorCode;
            ErrorStatus = errorStatus;
            ResponseMessage = responseMessage;
            MessageData = messageData;
        }
    }
}
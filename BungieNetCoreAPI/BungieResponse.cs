using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI
{
    public class BungieResponse<T>
    {
        public T Response { get; }
        public PlatformErrorCodes ErrorCode { get; }
        public int ThrottleSeconds { get; }
        public string ErrorStatus { get; }
        public string Message { get; }
        public Dictionary<string, string> MessageData { get; }
        public string DetailedErrorTrace { get; }

        [JsonConstructor]
        private BungieResponse(T Response, PlatformErrorCodes ErrorCode, int ThrottleSeconds, string ErrorStatus, string Message, Dictionary<string, string> MessageData, string DetailedErrorTrace)
        {
            this.Response = Response;
            this.ErrorCode = ErrorCode;
            this.ThrottleSeconds = ThrottleSeconds;
            this.ErrorStatus = ErrorStatus;
            this.Message = Message;
            this.MessageData = MessageData;
            this.DetailedErrorTrace = DetailedErrorTrace;
        }
    }
}

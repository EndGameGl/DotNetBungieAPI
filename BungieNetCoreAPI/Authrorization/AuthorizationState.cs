using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Authrorization
{
    public class AuthorizationState
    {
        public string State { get; private set; }
        public bool DidReceiveCallback { get; private set; }
        public DateTime LinkHandoutTime { get; private set; }
        public DateTime? CallbackReceiveTime { get; private set; }
        public string Code { get; private set; }
        public bool HasCode => Code != null;

        public static AuthorizationState GetNewAuth() =>
            new AuthorizationState()
            {
                State = RandomInstance.GetRandomString(20),
                DidReceiveCallback = false,
                LinkHandoutTime = DateTime.Now,
                CallbackReceiveTime = null,
                Code = null
            };

        public void ReceiveCode(string code)
        {
            CallbackReceiveTime = DateTime.Now;
            Code = code;
        }
        public void RerollState()
        {
            State = RandomInstance.GetRandomString(20);
        }
    }
}

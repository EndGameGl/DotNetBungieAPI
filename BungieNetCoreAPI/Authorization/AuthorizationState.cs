using System;

namespace NetBungieAPI.Authorization
{
    /// <summary>
    /// Class for tracking state of authorization code
    /// </summary>
    public class AuthorizationState
    {
        /// <summary>
        /// Authorization state nonce
        /// </summary>
        public string State { get; private set; }
        /// <summary>
        /// Whether this awaiter already received it's code
        /// </summary>
        public bool DidReceiveCallback { get; private set; }
        /// <summary>
        /// When this awaiter was created
        /// </summary>
        public DateTime LinkHandoutTime { get; private set; }
        /// <summary>
        /// When this awaiter received code
        /// </summary>
        public DateTime? CallbackReceiveTime { get; private set; }
        /// <summary>
        /// Received code
        /// </summary>
        public string Code { get; private set; }
        /// <summary>
        /// Whether this awaiter has receiver code
        /// </summary>
        public bool HasCode => Code != null;

        /// <summary>
        /// Creates new authorization code awaiter
        /// </summary>
        /// <returns></returns>
        public static AuthorizationState GetNewAuth() =>
            new AuthorizationState()
            {
                State = RandomInstance.GetRandomString(50),
                DidReceiveCallback = false,
                LinkHandoutTime = DateTime.Now,
                CallbackReceiveTime = null,
                Code = null
            };

        /// <summary>
        /// Receives and handles code
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <exception cref="Exception"></exception>
        public void ReceiveCode(string code, string state)
        {
            if (State != state)
                throw new Exception("State you provided doesn't match awaiter state.");
            CallbackReceiveTime = DateTime.Now;
            DidReceiveCallback = true;
            Code = code;
        }
    }
}

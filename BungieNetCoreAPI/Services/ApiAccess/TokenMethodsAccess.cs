using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Services.ApiAccess
{
    public class TokenMethodsAccess : ITokenMethodsAccess
    {
        private IHttpClientInstance _httpClient;
        internal TokenMethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }
    }
}

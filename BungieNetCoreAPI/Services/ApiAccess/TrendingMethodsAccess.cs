using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Services.ApiAccess
{
    public class TrendingMethodsAccess : ITrendingMethodsAccess
    {
        private IHttpClientInstance _httpClient;
        internal TrendingMethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }
    }
}

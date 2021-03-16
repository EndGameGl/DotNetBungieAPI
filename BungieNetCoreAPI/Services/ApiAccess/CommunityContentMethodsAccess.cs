using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI
{
    public class CommunityContentMethodsAccess : ICommunityContentMethodsAccess
    {
        private IHttpClientInstance _httpClient;
        internal CommunityContentMethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }
    }
}

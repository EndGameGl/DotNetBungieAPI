using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Services.ApiAccess
{
    public class GroupV2MethodsAccess : IGroupV2MethodsAccess
    {
        private IHttpClientInstance _httpClient;
        internal GroupV2MethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }
    }
}

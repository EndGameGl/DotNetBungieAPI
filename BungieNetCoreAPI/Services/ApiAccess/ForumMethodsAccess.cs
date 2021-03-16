using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Services.ApiAccess
{
    public class ForumMethodsAccess : IForumMethodsAccess
    {
        private IHttpClientInstance _httpClient;
        internal ForumMethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }
    }
}

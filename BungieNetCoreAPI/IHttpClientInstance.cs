using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetBungieApi
{
    public interface IHttpClientInstance
    {
        void AddAcceptHeader(string headerValue);
        void AddHeader(string header, string headerValue);
        void RemoveHeader(string header);
        Task<HttpResponseMessage> Get(string query);
    }
}

using System.Net.Http;

namespace NetBungieAPI.Services.Default.ServiceConfigurations
{
    public class DotNetBungieApiHttpClientConfiguration
    {
        public HttpClient HttpClient { get; internal set; } = new HttpClient();

        public void UseExternalHttpClient(HttpClient httpClient)
        {
            HttpClient = Conditions.NotNull(httpClient);
        }
    }
}
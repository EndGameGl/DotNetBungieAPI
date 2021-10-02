using System.Net.Http;

namespace DotNetBungieAPI.Services.Default.ServiceConfigurations
{
    public sealed class DotNetBungieApiHttpClientConfiguration
    {
        public HttpClient HttpClient { get; internal set; } = new HttpClient();

        public void UseExternalHttpClient(HttpClient httpClient)
        {
            HttpClient = Conditions.NotNull(httpClient);
        }
    }
}
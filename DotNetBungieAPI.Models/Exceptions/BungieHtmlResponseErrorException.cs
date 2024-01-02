using System.Net;

namespace DotNetBungieAPI.Models.Exceptions;

public class BungieHtmlResponseErrorException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public string Html { get; }

    public BungieHtmlResponseErrorException(HttpStatusCode statusCode, string html)
        : base("Received unexpected HTML response from bungie.net")
    {
        StatusCode = statusCode;
        Html = html;
    }
}

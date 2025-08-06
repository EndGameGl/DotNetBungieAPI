using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions;

/// <summary>
///     <see cref="System.Net.Http.HttpClient" /> wrapper for this library
/// </summary>
public interface IDotNetBungieApiHttpClient
{
    /// <summary>
    ///     Gets an auth token from bungie.net
    /// </summary>
    /// <param name="code">Code for the token</param>
    /// <returns></returns>
    Task<AuthorizationTokenData> GetAuthorizationToken(string code);

    /// <summary>
    ///     Renews auth token whenever possible
    /// </summary>
    /// <param name="oldToken">Token to update</param>
    /// <returns></returns>
    Task<AuthorizationTokenData> RenewAuthorizationToken(AuthorizationTokenData oldToken);

    /// <summary>
    ///     Gets auth link for bungie.net with provided client Id and state
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    string GetAuthLink(int clientId, string state);

    /// <summary>
    ///     Downloads json data from certain url
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    Task<string> DownloadJsonDataFromCdnAsync(string url);

    /// <summary>
    ///     Downloads a file with provided query from https://www.bungie.net and puts it to a certain path
    /// </summary>
    /// <param name="query"></param>
    /// <param name="savePath"></param>
    /// <returns></returns>
    Task DownloadFileFromCdnAsync(string query, string savePath);

    /// <summary>
    ///     Makes an HTTP GET request to https://www.bungie.net/Platform
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <param name="token"></param>
    /// <param name="authToken"></param>
    /// <returns></returns>
    Task<BungieResponse<T>> GetFromBungieNetPlatform<T>(string query, CancellationToken token, string? authToken = null);

    /// <summary>
    ///     Makes an HTTP POST request to https://www.bungie.net/Platform
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <param name="token"></param>
    /// <param name="content"></param>
    /// <param name="authToken"></param>
    /// <returns></returns>
    Task<BungieResponse<T>> PostToBungieNetPlatform<T>(string query, CancellationToken token, Stream? content = null, string? authToken = null);

    /// <summary>
    ///     Makes an HTTP GET request to https://stats.bungie.net/Platform
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <param name="token"></param>
    /// <param name="authToken"></param>
    /// <returns></returns>
    Task<BungieResponse<T>> GetFromBungieNetStatsPlatform<T>(string query, CancellationToken token, string? authToken = null);

    /// <summary>
    ///     Makes a request to certain path and returns response stream
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    Task<(Stream ContentStream, long? TotalLength)> GetStreamFromWebSourceAsync(string path);
}

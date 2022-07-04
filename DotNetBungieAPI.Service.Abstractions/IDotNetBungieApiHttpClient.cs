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
    ValueTask<AuthorizationTokenData> GetAuthorizationToken(
        string code);

    /// <summary>
    ///     Renews auth token whenever possible
    /// </summary>
    /// <param name="oldToken">Token to update</param>
    /// <returns></returns>
    ValueTask<AuthorizationTokenData> RenewAuthorizationToken(
        AuthorizationTokenData oldToken);

    string GetAuthLink(
        int clientId,
        string state);

    ValueTask<string> DownloadJsonDataFromCdnAsync(
        string url);

    Task DownloadFileStreamFromCdnAsync(
        string query,
        string savePath);

    ValueTask<BungieResponse<T>> GetFromBungieNetPlatform<T>(
        string query,
        CancellationToken token,
        string authToken = null);

    ValueTask<BungieResponse<T>> PostToBungieNetPlatform<T>(
        string query,
        CancellationToken token,
        Stream content = null,
        string authToken = null);

    ValueTask<BungieResponse<T>> GetFromBungieNetStatsPlatform<T>(
        string query,
        CancellationToken token,
        string authToken = null);

    ValueTask<(Stream ContentStream, long? TotalLength)> GetStreamFromWebSourceAsync(
        string path);
}
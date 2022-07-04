using System.Runtime.CompilerServices;
using System.Threading;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Social;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Extensions;

public static class IAsyncEnumerableExtensions
{
    public static async IAsyncEnumerable<PlatformFriendResponse> GetPlatformFriendList(
        this ISocialMethodsAccess socialMethodsAccess,
        int maxPages,
        PlatformFriendType friendPlatform,
        AuthorizationTokenData authorizationToken,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var currentPage = 0;
        var hasMoreToGet = true;
        while (currentPage < maxPages && hasMoreToGet)
        {
            var response = await socialMethodsAccess.GetPlatformFriendList(
                friendPlatform,
                authorizationToken,
                currentPage,
                cancellationToken);

            if (!response.IsSuccessfulResponseCode || response.Response is null)
                throw response.ToException();

            hasMoreToGet = response.Response.HasMore;
            currentPage = response.Response.CurrentPage + 1;
            yield return response.Response;
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Exceptions;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Applications;
using NetBungieAPI.Models.Social;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services.ApiAccess
{
    public class SocialMethodsAccess : ISocialMethodsAccess
    {
        private readonly IConfigurationService _configuration;
        private readonly IHttpClientInstance _httpClient;

        public SocialMethodsAccess(
            IHttpClientInstance httpClient, 
            IConfigurationService configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }


        public async ValueTask<BungieResponse<BungieFriendListResponse>> GetFriendList(
            AuthorizationTokenData authData, 
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(ApplicationScopes.ReadUserData))
                throw new InsufficientScopeException(ApplicationScopes.ReadUserData);
            return await _httpClient.GetFromBungieNetPlatform<BungieFriendListResponse>("/Social/Friends/", token, authData.AccessToken);
        }

        public async ValueTask<BungieResponse<BungieFriendRequestListResponse>> GetFriendRequestList(AuthorizationTokenData authData, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(ApplicationScopes.ReadUserData))
                throw new InsufficientScopeException(ApplicationScopes.ReadUserData);
            return await _httpClient.GetFromBungieNetPlatform<BungieFriendRequestListResponse>("/Social/Friends/Requests/", token, authData.AccessToken);
        }

        public async ValueTask<BungieResponse<bool>> IssueFriendRequest(string membershipId, AuthorizationTokenData authData, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(ApplicationScopes.BnetWrite))
                throw new InsufficientScopeException(ApplicationScopes.BnetWrite);
            
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Social/Friends/Add/")
                .AddUrlParam(membershipId)
                .Build();
            
            return await _httpClient.PostToBungieNetPlatform<bool>(url, token, authToken: authData.AccessToken);
        }

        public async ValueTask<BungieResponse<bool>> AcceptFriendRequest(string membershipId, AuthorizationTokenData authData, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(ApplicationScopes.BnetWrite))
                throw new InsufficientScopeException(ApplicationScopes.BnetWrite);
            
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Social/Friends/Requests/Accept/")
                .AddUrlParam(membershipId)
                .Build();
            
            return await _httpClient.PostToBungieNetPlatform<bool>(url, token, authToken: authData.AccessToken);
        }

        public async ValueTask<BungieResponse<bool>> DeclineFriendRequest(string membershipId, AuthorizationTokenData authData, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(ApplicationScopes.BnetWrite))
                throw new InsufficientScopeException(ApplicationScopes.BnetWrite);
            
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Social/Friends/Requests/Decline/")
                .AddUrlParam(membershipId)
                .Build();
            
            return await _httpClient.PostToBungieNetPlatform<bool>(url, token, authToken: authData.AccessToken);
        }

        public async ValueTask<BungieResponse<bool>> RemoveFriend(string membershipId, AuthorizationTokenData authData, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(ApplicationScopes.BnetWrite))
                throw new InsufficientScopeException(ApplicationScopes.BnetWrite);
            
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Social/Friends/Remove/")
                .AddUrlParam(membershipId)
                .Build();
            
            return await _httpClient.PostToBungieNetPlatform<bool>(url, token, authToken: authData.AccessToken);
        }

        public async ValueTask<BungieResponse<bool>> RemoveFriendRequest(string membershipId, AuthorizationTokenData authData, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(ApplicationScopes.BnetWrite))
                throw new InsufficientScopeException(ApplicationScopes.BnetWrite);
            
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Social/Friends/Requests/Remove/")
                .AddUrlParam(membershipId)
                .Build();
            
            return await _httpClient.PostToBungieNetPlatform<bool>(url, token, authToken: authData.AccessToken);
        }

        public async ValueTask<BungieResponse<PlatformFriendResponse>> GetPlatformFriendList(
            PlatformFriendType friendPlatform, 
            AuthorizationTokenData authData, 
            int page = 0,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Social/PlatformFriends/")
                .AddUrlParam(((int)friendPlatform).ToString())
                .AddUrlParam(page.ToString())
                .Build();
            
            return await _httpClient.GetFromBungieNetPlatform<PlatformFriendResponse>(url, token, authData.AccessToken);
        }
    }
}
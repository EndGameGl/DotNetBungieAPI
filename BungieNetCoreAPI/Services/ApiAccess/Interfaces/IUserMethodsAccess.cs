using NetBungieAPI.Models;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.User;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IUserMethodsAccess
    {
        /// <summary>
        /// Loads a bungienet user by membership id.
        /// </summary>
        /// <param name="id">The requested Bungie.net membership id.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GeneralUser>> GetBungieNetUserById(long id, CancellationToken token = default);

        /// <summary>
        /// Returns a list of possible users based on the search string
        /// </summary>
        /// <param name="query">The search string.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GeneralUser[]>> SearchUsers(string query, CancellationToken token = default);

        /// <summary>
        /// Returns a list of credential types attached to the requested account
        /// </summary>
        /// <param name="id">The user's membership id</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<CredentialTypeForAccount[]>> GetCredentialTypesForTargetAccount(long id,
            CancellationToken token = default);

        /// <summary>
        /// Returns a list of all available user themes.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<UserTheme[]>> GetAvailableThemes(CancellationToken token = default);

        /// <summary>
        /// Returns a list of accounts associated with the supplied membership ID and membership type. This will include all linked accounts (even when hidden) if supplied credentials permit it.
        /// </summary>
        /// <param name="id">The membership ID of the target user.</param>
        /// <param name="membershipType">Type of the supplied membership ID.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataById(long id,
            BungieMembershipType membershipType, CancellationToken token = default);

        /// <summary>
        /// Returns a list of accounts associated with signed in user. This is useful for OAuth implementations that do not give you access to the token response.
        /// </summary>
        /// /// <param name="id">Current user ID, needed to get auth values</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<UserMembershipData>>
            GetMembershipDataForCurrentUser(AuthorizationTokenData authToken, CancellationToken token = default);

        /// <summary>
        /// Gets any hard linked membership given a credential. Only works for credentials that are public (just SteamID64 right now). Cross Save aware.
        /// </summary>
        /// <param name="credential">The credential to look up. Must be a valid SteamID64.</param>
        /// <param name="credentialType">The credential type. 'SteamId' is the only valid value at present.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(long credential,
            BungieCredentialType credentialType = BungieCredentialType.SteamId, CancellationToken token = default);
    }
}
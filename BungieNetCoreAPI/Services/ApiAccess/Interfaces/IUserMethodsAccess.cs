using NetBungieAPI.Models;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.User;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IUserMethodsAccess
    {
        ValueTask<BungieResponse<GeneralUser>> GetBungieNetUserById(long id, CancellationToken token = default);
        ValueTask<BungieResponse<GeneralUser[]>> SearchUsers(string query, CancellationToken token = default);
        ValueTask<BungieResponse<CredentialTypeForAccount[]>> GetCredentialTypesForTargetAccount(long id, CancellationToken token = default);
        ValueTask<BungieResponse<UserTheme[]>> GetAvailableThemes(CancellationToken token = default);
        ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataById(long id, BungieMembershipType membershipType, CancellationToken token = default);
        ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataForCurrentUser(long id, CancellationToken token = default);
        ValueTask<BungieResponse<HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(long credential, BungieCredentialType credentialType = BungieCredentialType.SteamId, CancellationToken token = default);
    }
}

using NetBungieAPI.Bungie;
using NetBungieAPI.User;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IUserMethodsAccess
    {
        Task<BungieResponse<GeneralUser>> GetBungieNetUserById(long id);
        Task<BungieResponse<GeneralUser[]>> SearchUsers(string query);
        Task<BungieResponse<BungieNetUserAccountCredentialType[]>> GetCredentialTypesForTargetAccount(long id);
        Task<BungieResponse<BungieUserTheme[]>> GetAvailableThemes();
        Task<BungieResponse<BungieNetUserWithMemberships>> GetMembershipDataById(long id, BungieMembershipType membershipType);
        Task<BungieResponse<BungieNetUserWithMemberships>> GetMembershipDataForCurrentUser();
        Task<BungieResponse<DestinyHardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(long credential, BungieCredentialType credentialType = BungieCredentialType.SteamId);
    }
}

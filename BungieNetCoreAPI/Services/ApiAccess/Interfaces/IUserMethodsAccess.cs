using NetBungieAPI.User;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IUserMethodsAccess
    {
        Task<BungieResponse<GeneralUser>> GetBungieNetUserById(long id);
        Task<BungieResponse<GeneralUser[]>> SearchUsers(string query);
        Task<BungieResponse<CredentialTypeForAccount[]>> GetCredentialTypesForTargetAccount(long id);
        Task<BungieResponse<UserTheme[]>> GetAvailableThemes();
        Task<BungieResponse<UserMembershipData>> GetMembershipDataById(long id, BungieMembershipType membershipType);
        Task<BungieResponse<UserMembershipData>> GetMembershipDataForCurrentUser(long id);
        Task<BungieResponse<HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(long credential, BungieCredentialType credentialType = BungieCredentialType.SteamId);
    }
}

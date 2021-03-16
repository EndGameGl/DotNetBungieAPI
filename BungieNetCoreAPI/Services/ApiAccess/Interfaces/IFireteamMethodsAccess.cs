using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IFireteamMethodsAccess
    {
        Task<BungieResponse<int>> GetActivePrivateClanFireteamCount(long groupId);
    }
}

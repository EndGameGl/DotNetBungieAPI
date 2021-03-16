using NetBungieAPI.Bungie.Applications;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IAppMethodsAccess
    {
        Task<BungieResponse<BungieApplication[]>> GetBungieApplications();
        Task<BungieResponse<ApiUsage>> GetApplicationApiUsage(int applicationId);
    }
}

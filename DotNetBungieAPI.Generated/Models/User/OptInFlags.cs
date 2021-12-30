using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.User;

[System.Flags]
public enum OptInFlags : long
{
    None = 0,
    Newsletter = 1,
    System = 2,
    Marketing = 4,
    UserResearch = 8,
    CustomerService = 16,
    Social = 32,
    PlayTests = 64,
    PlayTestsLocal = 128,
    Careers = 256
}

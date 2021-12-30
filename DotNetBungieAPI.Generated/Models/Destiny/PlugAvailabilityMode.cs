using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public enum PlugAvailabilityMode : int
{
    Normal = 0,
    UnavailableIfSocketContainsMatchingPlugCategory = 1,
    AvailableIfSocketContainsMatchingPlugCategory = 2
}

using DotNetBungieAPI.Models.Destiny.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.Activities;

namespace DotNetBungieAPI.Data.Models.Activities;

public class DestinyActivityData
{
    public DestinyActivity RuntimeActivityData { get; init; }
    public DestinyActivityDefinition ActivityDefinition { get; init; }
    
}
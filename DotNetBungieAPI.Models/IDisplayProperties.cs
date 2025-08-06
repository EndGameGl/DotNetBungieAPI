using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models;

public interface IDisplayProperties 
{
    DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
}
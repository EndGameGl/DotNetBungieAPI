using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     Common interface for Destiny 2 definitions that have display properties
/// </summary>
public interface IDisplayProperties
{
    /// <summary>
    ///     Definition display properties
    /// </summary>
    DestinyDisplayPropertiesDefinition DisplayProperties { get; }
}

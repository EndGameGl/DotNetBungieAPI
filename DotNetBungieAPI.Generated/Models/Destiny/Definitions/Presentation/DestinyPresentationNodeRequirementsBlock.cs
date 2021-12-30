using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

/// <summary>
///     Presentation nodes can be restricted by various requirements. This defines the rules of those requirements, and the message(s) to be shown if these requirements aren't met.
/// </summary>
public sealed class DestinyPresentationNodeRequirementsBlock
{

    /// <summary>
    ///     If this node is not accessible due to Entitlements (for instance, you don't own the required game expansion), this is the message to show.
    /// </summary>
    [JsonPropertyName("entitlementUnavailableMessage")]
    public string EntitlementUnavailableMessage { get; init; }
}

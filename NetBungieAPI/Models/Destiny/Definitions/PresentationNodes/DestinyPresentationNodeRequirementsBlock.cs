using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.PresentationNodes
{
    public sealed record
        DestinyPresentationNodeRequirementsBlock : IDeepEquatable<DestinyPresentationNodeRequirementsBlock>
    {
        [JsonPropertyName("entitlementUnavailableMessage")]
        public string EntitlementUnavailableMessage { get; init; }

        public bool DeepEquals(DestinyPresentationNodeRequirementsBlock other)
        {
            return other != null && EntitlementUnavailableMessage == other.EntitlementUnavailableMessage;
        }
    }
}
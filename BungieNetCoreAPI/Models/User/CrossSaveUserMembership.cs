using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public record CrossSaveUserMembership : UserMembership
    {
        [JsonPropertyName("crossSaveOverride")]
        public BungieMembershipType СrossSaveOverride { get; init; }

        [JsonPropertyName("applicableMembershipTypes")]
        public ReadOnlyCollection<BungieMembershipType> ApplicableMembershipTypes { get; init; } = Defaults.EmptyReadOnlyCollection<BungieMembershipType>();

        [JsonPropertyName("isPublic")]
        public bool IsPublic { get; init; }
    }
}

using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;

namespace DotNetBungieAPI.Models.User
{
    /// <summary>
    ///     Very basic info about a user as returned by the Account server, but including CrossSave information.
    /// </summary>
    public record CrossSaveUserMembership : UserMembership
    {
        /// <summary>
        ///     If there is a cross save override in effect, this value will tell you the type that is overridding this one.
        /// </summary>
        [JsonPropertyName("crossSaveOverride")]
        public BungieMembershipType СrossSaveOverride { get; init; }

        /// <summary>
        ///     The list of Membership Types indicating the platforms on which this Membership can be used.
        ///     <para />
        ///     Not in Cross Save = its original membership type. Cross Save Primary = Any membership types it is overridding, and
        ///     its original membership type Cross Save Overridden = Empty list
        /// </summary>
        [JsonPropertyName("applicableMembershipTypes")]
        public ReadOnlyCollection<BungieMembershipType> ApplicableMembershipTypes { get; init; } =
            ReadOnlyCollections<BungieMembershipType>.Empty;

        /// <summary>
        ///     If True, this is a public user membership.
        /// </summary>
        [JsonPropertyName("isPublic")]
        public bool IsPublic { get; init; }
    }
}
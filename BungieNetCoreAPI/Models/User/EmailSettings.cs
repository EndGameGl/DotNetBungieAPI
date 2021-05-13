using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    /// <summary>
    /// The set of all email subscription/opt-in settings and definitions.
    /// </summary>
    public sealed record EmailSettings
    {
        /// <summary>
        /// Keyed by the name identifier of the opt-in definition.
        /// </summary>
        [JsonPropertyName("optInDefinitions")]
        public ReadOnlyDictionary<string, EmailOptInDefinition> OptInDefinitions { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, EmailOptInDefinition>();

        /// <summary>
        /// Keyed by the name identifier of the Subscription definition.
        /// </summary>
        [JsonPropertyName("subscriptionDefinitions")]
        public ReadOnlyDictionary<string, EmailSubscriptionDefinition> SubscriptionDefinitions { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, EmailSubscriptionDefinition>();

        /// <summary>
        /// Keyed by the name identifier of the View definition.
        /// </summary>
        [JsonPropertyName("views")]
        public ReadOnlyDictionary<string, EmailViewDefinition> Views { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, EmailViewDefinition>();
    }
}
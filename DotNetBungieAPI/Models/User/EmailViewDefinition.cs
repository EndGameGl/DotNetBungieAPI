using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;

namespace DotNetBungieAPI.Models.User
{
    /// <summary>
    ///     Represents a data-driven view for Email settings. Web/Mobile UI can use this data to show new EMail settings
    ///     consistently without further manual work.
    /// </summary>
    public sealed record EmailViewDefinition
    {
        /// <summary>
        ///     The identifier for this view.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; }

        /// <summary>
        ///     The ordered list of settings to show in this view.
        /// </summary>
        [JsonPropertyName("viewSettings")]
        public ReadOnlyCollection<EmailViewDefinitionSetting> ViewSettings { get; init; } =
            ReadOnlyCollections<EmailViewDefinitionSetting>.Empty;
    }
}
namespace DotNetBungieAPI.Models.Destiny.Components
{
    /// <summary>
    ///     The base class for any component-returning object that may need to indicate information about the state of the
    ///     component being returned.
    /// </summary>
    public abstract record ComponentResponse
    {
        [JsonPropertyName("privacy")] public ComponentPrivacySetting Privacy { get; init; }

        /// <summary>
        ///     If true, this component is disabled.
        /// </summary>
        [JsonPropertyName("disabled")]
        public bool? IsDisabled { get; init; }
    }
}
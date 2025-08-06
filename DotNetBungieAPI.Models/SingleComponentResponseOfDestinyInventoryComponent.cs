namespace DotNetBungieAPI.Models;

public sealed class SingleComponentResponseOfDestinyInventoryComponent
{
    [JsonPropertyName("data")]
    public Destiny.Entities.Inventory.DestinyInventoryComponent? Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}

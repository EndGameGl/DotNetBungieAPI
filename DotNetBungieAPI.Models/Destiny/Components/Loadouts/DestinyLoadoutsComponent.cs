namespace DotNetBungieAPI.Models.Destiny.Components.Loadouts;

public sealed class DestinyLoadoutsComponent
{
    [JsonPropertyName("loadouts")]
    public Destiny.Components.Loadouts.DestinyLoadoutComponent[]? Loadouts { get; init; }
}

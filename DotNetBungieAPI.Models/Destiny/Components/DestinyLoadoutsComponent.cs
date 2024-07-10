namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinyLoadoutsComponent
{
    [JsonPropertyName("loadouts")]
    public ReadOnlyCollection<DestinyLoadoutComponent> Loadouts { get; init; } =
        ReadOnlyCollections<DestinyLoadoutComponent>.Empty;
}

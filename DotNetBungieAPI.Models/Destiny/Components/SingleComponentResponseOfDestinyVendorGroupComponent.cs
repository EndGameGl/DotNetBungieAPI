namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyVendorGroupComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public DestinyVendorGroupComponent Data { get; init; }
}

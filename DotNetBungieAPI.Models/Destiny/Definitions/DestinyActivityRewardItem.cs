namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyActivityRewardItem
{
    [JsonPropertyName("itemQuantity")]
    public Destiny.DestinyItemQuantity? ItemQuantity { get; init; }

    [JsonPropertyName("uiStyle")]
    public string UiStyle { get; init; }
}

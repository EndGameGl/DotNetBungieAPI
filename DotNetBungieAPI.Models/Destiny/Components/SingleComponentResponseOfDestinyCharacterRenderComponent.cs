namespace DotNetBungieAPI.Models.Destiny.Components;

public class SingleComponentResponseOfDestinyCharacterRenderComponent
{
    [JsonPropertyName("data")]
    public DestinyCharacterRenderComponent Data { get; init; }
}

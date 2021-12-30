using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

public sealed class DestinyItemPerksComponent
{

    [JsonPropertyName("perks")]
    public List<Destiny.Perks.DestinyPerkReference> Perks { get; init; }
}

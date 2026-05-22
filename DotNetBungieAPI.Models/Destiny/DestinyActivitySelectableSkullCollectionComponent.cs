namespace DotNetBungieAPI.Models.Destiny;

public sealed class DestinyActivitySelectableSkullCollectionComponent
{
    [JsonPropertyName("selectableSkullCollectionHash")]
    public DefinitionHashPointer<Destiny.Definitions.Activities.DestinyActivitySelectableSkullCollectionDefinition> SelectableSkullCollectionHash { get; init; }

    [JsonPropertyName("selectableSkulls")]
    public Destiny.DestinyActivitySkullComponent[]? SelectableSkulls { get; init; }
}

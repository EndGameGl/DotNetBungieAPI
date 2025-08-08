namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

public sealed class DestinyActivitySelectableSkull
{
    [JsonPropertyName("requiredTraitHash")]
    public DefinitionHashPointer<Destiny.Definitions.Traits.DestinyTraitDefinition> RequiredTraitHash { get; init; }

    [JsonPropertyName("requiredTraitExistence")]
    public bool RequiredTraitExistence { get; init; }

    [JsonPropertyName("isEmptySkull")]
    public bool IsEmptySkull { get; init; }

    [JsonPropertyName("loadoutRestrictionHash")]
    public DefinitionHashPointer<Destiny.Definitions.Activities.DestinyActivityLoadoutRestrictionDefinition> LoadoutRestrictionHash { get; init; }

    [JsonPropertyName("activitySkull")]
    public Destiny.Definitions.Activities.DestinyActivitySkull? ActivitySkull { get; init; }
}

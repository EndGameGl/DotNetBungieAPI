namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Activities;

public class DestinyActivitySelectableSkull
{
    [Destiny2Definition<Destiny.Definitions.Traits.DestinyTraitDefinition>("Destiny.Definitions.Traits.DestinyTraitDefinition")]
    [JsonPropertyName("requiredTraitHash")]
    public uint? RequiredTraitHash { get; set; }

    [JsonPropertyName("requiredTraitExistence")]
    public bool? RequiredTraitExistence { get; set; }

    [JsonPropertyName("isEmptySkull")]
    public bool? IsEmptySkull { get; set; }

    [Destiny2Definition<Destiny.Definitions.Activities.DestinyActivityLoadoutRestrictionDefinition>("Destiny.Definitions.Activities.DestinyActivityLoadoutRestrictionDefinition")]
    [JsonPropertyName("loadoutRestrictionHash")]
    public uint? LoadoutRestrictionHash { get; set; }

    [JsonPropertyName("activitySkull")]
    public Destiny.Definitions.Activities.DestinyActivitySkull? ActivitySkull { get; set; }
}

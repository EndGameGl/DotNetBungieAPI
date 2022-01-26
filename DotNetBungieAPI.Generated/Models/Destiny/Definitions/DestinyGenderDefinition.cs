namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Gender is a social construct, and as such we have definitions for Genders. Right now there happens to only be two, but we'll see what the future holds.
/// </summary>
public class DestinyGenderDefinition : IDeepEquatable<DestinyGenderDefinition>
{
    /// <summary>
    ///     This is a quick reference enumeration for all of the currently defined Genders. We use the enumeration for quicker lookups in related data, like DestinyClassDefinition.genderedClassNames.
    /// </summary>
    [JsonPropertyName("genderType")]
    public Destiny.DestinyGender GenderType { get; set; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }

    public bool DeepEquals(DestinyGenderDefinition? other)
    {
        return other is not null &&
               GenderType == other.GenderType &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }
}
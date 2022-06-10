namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Defines a Character Class in Destiny 2. These are types of characters you can play, like Titan, Warlock, and Hunter.
/// </summary>
public class DestinyClassDefinition
{
    /// <summary>
    ///     In Destiny 1, we added a convenience Enumeration for referring to classes. We've kept it, though mostly for posterity. This is the enum value for this definition's class.
    /// </summary>
    [JsonPropertyName("classType")]
    public Destiny.DestinyClass ClassType { get; set; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     A localized string referring to the singular form of the Class's name when referred to in gendered form. Keyed by the DestinyGender.
    /// </summary>
    [JsonPropertyName("genderedClassNames")]
    public Dictionary<Destiny.DestinyGender, string> GenderedClassNames { get; set; }

    [JsonPropertyName("genderedClassNamesByGenderHash")]
    public Dictionary<uint, string> GenderedClassNamesByGenderHash { get; set; }

    /// <summary>
    ///     Mentors don't really mean anything anymore. Don't expect this to be populated.
    /// </summary>
    [JsonPropertyName("mentorVendorHash")]
    public uint MentorVendorHash { get; set; }

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
}

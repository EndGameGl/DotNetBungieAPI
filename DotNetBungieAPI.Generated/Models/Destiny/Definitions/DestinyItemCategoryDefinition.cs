namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     In an attempt to categorize items by type, usage, and other interesting properties, we created DestinyItemCategoryDefinition: information about types that is assembled using a set of heuristics that examine the properties of an item such as what inventory bucket it's in, its item type name, and whether it has or is missing certain blocks of data.
/// <para />
///     This heuristic is imperfect, however. If you find an item miscategorized, let us know on the Bungie API forums!
/// <para />
///     We then populate all of the categories that we think an item belongs to in its DestinyInventoryItemDefinition.itemCategoryHashes property. You can use that to provide your own custom item filtering, sorting, aggregating... go nuts on it! And let us know if you see more categories that you wish would be added!
/// </summary>
public class DestinyItemCategoryDefinition : IDeepEquatable<DestinyItemCategoryDefinition>
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     If True, this category should be visible in UI. Sometimes we make categories that we don't think are interesting externally. It's up to you if you want to skip on showing them.
    /// </summary>
    [JsonPropertyName("visible")]
    public bool Visible { get; set; }

    /// <summary>
    ///     If True, this category has been deprecated: it may have no items left, or there may be only legacy items that remain in it which are no longer relevant to the game.
    /// </summary>
    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    /// <summary>
    ///     A shortened version of the title. The reason why we have this is because the Armory in German had titles that were too long to display in our UI, so these were localized abbreviated versions of those categories. The property still exists today, even though the Armory doesn't exist for D2... yet.
    /// </summary>
    [JsonPropertyName("shortTitle")]
    public string ShortTitle { get; set; }

    /// <summary>
    ///     The janky regular expression we used against the item type to try and discern whether the item belongs to this category.
    /// </summary>
    [JsonPropertyName("itemTypeRegex")]
    public string ItemTypeRegex { get; set; }

    /// <summary>
    ///     If the item in question has this category, it also should have this breaker type.
    /// </summary>
    [JsonPropertyName("grantDestinyBreakerType")]
    public Destiny.DestinyBreakerType GrantDestinyBreakerType { get; set; }

    /// <summary>
    ///     If the item is a plug, this is the identifier we expect to find associated with it if it is in this category.
    /// </summary>
    [JsonPropertyName("plugCategoryIdentifier")]
    public string PlugCategoryIdentifier { get; set; }

    /// <summary>
    ///     If the item type matches this janky regex, it does *not* belong to this category.
    /// </summary>
    [JsonPropertyName("itemTypeRegexNot")]
    public string ItemTypeRegexNot { get; set; }

    /// <summary>
    ///     If the item belongs to this bucket, it does belong to this category.
    /// </summary>
    [JsonPropertyName("originBucketIdentifier")]
    public string OriginBucketIdentifier { get; set; }

    /// <summary>
    ///     If an item belongs to this category, it will also receive this item type. This is now how DestinyItemType is populated for items: it used to be an even jankier process, but that's a story that requires more alcohol.
    /// </summary>
    [JsonPropertyName("grantDestinyItemType")]
    public Destiny.DestinyItemType GrantDestinyItemType { get; set; }

    /// <summary>
    ///     If an item belongs to this category, it will also receive this subtype enum value.
    /// <para />
    ///     I know what you're thinking - what if it belongs to multiple categories that provide sub-types?
    /// <para />
    ///     The last one processed wins, as is the case with all of these "grant" enums. Now you can see one reason why we moved away from these enums... but they're so convenient when they work, aren't they?
    /// </summary>
    [JsonPropertyName("grantDestinySubType")]
    public Destiny.DestinyItemSubType GrantDestinySubType { get; set; }

    /// <summary>
    ///     If an item belongs to this category, it will also get this class restriction enum value.
    /// <para />
    ///     See the other "grant"-prefixed properties on this definition for my color commentary.
    /// </summary>
    [JsonPropertyName("grantDestinyClass")]
    public Destiny.DestinyClass GrantDestinyClass { get; set; }

    /// <summary>
    ///     The traitId that can be found on items that belong to this category.
    /// </summary>
    [JsonPropertyName("traitId")]
    public string TraitId { get; set; }

    /// <summary>
    ///     If this category is a "parent" category of other categories, those children will have their hashes listed in rendering order here, and can be looked up using these hashes against DestinyItemCategoryDefinition.
    /// <para />
    ///     In this way, you can build up a visual hierarchy of item categories. That's what we did, and you can do it too. I believe in you. Yes, you, Carl.
    /// <para />
    ///     (I hope someone named Carl reads this someday)
    /// </summary>
    [JsonPropertyName("groupedCategoryHashes")]
    public List<uint> GroupedCategoryHashes { get; set; }

    /// <summary>
    ///     All item category hashes of "parent" categories: categories that contain this as a child through the hierarchy of groupedCategoryHashes. It's a bit redundant, but having this child-centric list speeds up some calculations.
    /// </summary>
    [JsonPropertyName("parentCategoryHashes")]
    public List<uint> ParentCategoryHashes { get; set; }

    /// <summary>
    ///     If true, this category is only used for grouping, and should not be evaluated with its own checks. Rather, the item only has this category if it has one of its child categories.
    /// </summary>
    [JsonPropertyName("groupCategoryOnly")]
    public bool GroupCategoryOnly { get; set; }

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

    public bool DeepEquals(DestinyItemCategoryDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               Visible == other.Visible &&
               Deprecated == other.Deprecated &&
               ShortTitle == other.ShortTitle &&
               ItemTypeRegex == other.ItemTypeRegex &&
               GrantDestinyBreakerType == other.GrantDestinyBreakerType &&
               PlugCategoryIdentifier == other.PlugCategoryIdentifier &&
               ItemTypeRegexNot == other.ItemTypeRegexNot &&
               OriginBucketIdentifier == other.OriginBucketIdentifier &&
               GrantDestinyItemType == other.GrantDestinyItemType &&
               GrantDestinySubType == other.GrantDestinySubType &&
               GrantDestinyClass == other.GrantDestinyClass &&
               TraitId == other.TraitId &&
               GroupedCategoryHashes.DeepEqualsListNaive(other.GroupedCategoryHashes) &&
               ParentCategoryHashes.DeepEqualsListNaive(other.ParentCategoryHashes) &&
               GroupCategoryOnly == other.GroupCategoryOnly &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }
}
namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyPlugItemCraftingRequirements : IDeepEquatable<DestinyPlugItemCraftingRequirements>
{
    [JsonPropertyName("unlockRequirements")]
    public List<Destiny.Definitions.DestinyPlugItemCraftingUnlockRequirement> UnlockRequirements { get; set; }

    /// <summary>
    ///     If the plug has a known level requirement, it'll be available here.
    /// </summary>
    [JsonPropertyName("requiredLevel")]
    public int? RequiredLevel { get; set; }

    [JsonPropertyName("materialRequirementHashes")]
    public List<uint> MaterialRequirementHashes { get; set; }

    public bool DeepEquals(DestinyPlugItemCraftingRequirements? other)
    {
        return other is not null &&
               UnlockRequirements.DeepEqualsList(other.UnlockRequirements) &&
               RequiredLevel == other.RequiredLevel &&
               MaterialRequirementHashes.DeepEqualsListNaive(other.MaterialRequirementHashes);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPlugItemCraftingRequirements? other)
    {
        if (other is null) return;
        if (!UnlockRequirements.DeepEqualsList(other.UnlockRequirements))
        {
            UnlockRequirements = other.UnlockRequirements;
            OnPropertyChanged(nameof(UnlockRequirements));
        }
        if (RequiredLevel != other.RequiredLevel)
        {
            RequiredLevel = other.RequiredLevel;
            OnPropertyChanged(nameof(RequiredLevel));
        }
        if (!MaterialRequirementHashes.DeepEqualsListNaive(other.MaterialRequirementHashes))
        {
            MaterialRequirementHashes = other.MaterialRequirementHashes;
            OnPropertyChanged(nameof(MaterialRequirementHashes));
        }
    }
}
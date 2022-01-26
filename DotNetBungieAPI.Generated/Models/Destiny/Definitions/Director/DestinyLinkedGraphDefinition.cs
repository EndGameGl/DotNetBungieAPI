namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     This describes links between the current graph and others, as well as when that link is relevant.
/// </summary>
public class DestinyLinkedGraphDefinition : IDeepEquatable<DestinyLinkedGraphDefinition>
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("unlockExpression")]
    public Destiny.Definitions.DestinyUnlockExpressionDefinition UnlockExpression { get; set; }

    [JsonPropertyName("linkedGraphId")]
    public uint LinkedGraphId { get; set; }

    [JsonPropertyName("linkedGraphs")]
    public List<Destiny.Definitions.Director.DestinyLinkedGraphEntryDefinition> LinkedGraphs { get; set; }

    [JsonPropertyName("overview")]
    public string Overview { get; set; }

    public bool DeepEquals(DestinyLinkedGraphDefinition? other)
    {
        return other is not null &&
               Description == other.Description &&
               Name == other.Name &&
               (UnlockExpression is not null ? UnlockExpression.DeepEquals(other.UnlockExpression) : other.UnlockExpression is null) &&
               LinkedGraphId == other.LinkedGraphId &&
               LinkedGraphs.DeepEqualsList(other.LinkedGraphs) &&
               Overview == other.Overview;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyLinkedGraphDefinition? other)
    {
        if (other is null) return;
        if (Description != other.Description)
        {
            Description = other.Description;
            OnPropertyChanged(nameof(Description));
        }
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (!UnlockExpression.DeepEquals(other.UnlockExpression))
        {
            UnlockExpression.Update(other.UnlockExpression);
            OnPropertyChanged(nameof(UnlockExpression));
        }
        if (LinkedGraphId != other.LinkedGraphId)
        {
            LinkedGraphId = other.LinkedGraphId;
            OnPropertyChanged(nameof(LinkedGraphId));
        }
        if (!LinkedGraphs.DeepEqualsList(other.LinkedGraphs))
        {
            LinkedGraphs = other.LinkedGraphs;
            OnPropertyChanged(nameof(LinkedGraphs));
        }
        if (Overview != other.Overview)
        {
            Overview = other.Overview;
            OnPropertyChanged(nameof(Overview));
        }
    }
}
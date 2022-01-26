namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Where the sausage gets made. Unlock Expressions are the foundation of the game's gating mechanics and investment-related restrictions. They can test Unlock Flags and Unlock Values for certain states, using a sufficient amount of logical operators such that unlock expressions are effectively Turing complete.
/// <para />
///     Use UnlockExpressionParser to evaluate expressions using an IUnlockContext parsed from Babel.
/// </summary>
public class DestinyUnlockExpressionDefinition : IDeepEquatable<DestinyUnlockExpressionDefinition>
{
    /// <summary>
    ///     A shortcut for determining the most restrictive gating that this expression performs. See the DestinyGatingScope enum's documentation for more details.
    /// </summary>
    [JsonPropertyName("scope")]
    public Destiny.DestinyGatingScope Scope { get; set; }

    public bool DeepEquals(DestinyUnlockExpressionDefinition? other)
    {
        return other is not null &&
               Scope == other.Scope;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyUnlockExpressionDefinition? other)
    {
        if (other is null) return;
        if (Scope != other.Scope)
        {
            Scope = other.Scope;
            OnPropertyChanged(nameof(Scope));
        }
    }
}
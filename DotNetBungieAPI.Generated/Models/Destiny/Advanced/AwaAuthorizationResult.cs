namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public class AwaAuthorizationResult : IDeepEquatable<AwaAuthorizationResult>
{
    /// <summary>
    ///     Indication of how the user responded to the request. If the value is "Approved" the actionToken will contain the token that can be presented when performing the advanced write action.
    /// </summary>
    [JsonPropertyName("userSelection")]
    public Destiny.Advanced.AwaUserSelection UserSelection { get; set; }

    [JsonPropertyName("responseReason")]
    public Destiny.Advanced.AwaResponseReason ResponseReason { get; set; }

    /// <summary>
    ///     Message to the app developer to help understand the response.
    /// </summary>
    [JsonPropertyName("developerNote")]
    public string DeveloperNote { get; set; }

    /// <summary>
    ///     Credential used to prove the user authorized an advanced write action.
    /// </summary>
    [JsonPropertyName("actionToken")]
    public string ActionToken { get; set; }

    /// <summary>
    ///     This token may be used to perform the requested action this number of times, at a maximum. If this value is 0, then there is no limit.
    /// </summary>
    [JsonPropertyName("maximumNumberOfUses")]
    public int MaximumNumberOfUses { get; set; }

    /// <summary>
    ///     Time, UTC, when token expires.
    /// </summary>
    [JsonPropertyName("validUntil")]
    public DateTime? ValidUntil { get; set; }

    /// <summary>
    ///     Advanced Write Action Type from the permission request.
    /// </summary>
    [JsonPropertyName("type")]
    public Destiny.Advanced.AwaType Type { get; set; }

    /// <summary>
    ///     MembershipType from the permission request.
    /// </summary>
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    public bool DeepEquals(AwaAuthorizationResult? other)
    {
        return other is not null &&
               UserSelection == other.UserSelection &&
               ResponseReason == other.ResponseReason &&
               DeveloperNote == other.DeveloperNote &&
               ActionToken == other.ActionToken &&
               MaximumNumberOfUses == other.MaximumNumberOfUses &&
               ValidUntil == other.ValidUntil &&
               Type == other.Type &&
               MembershipType == other.MembershipType;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(AwaAuthorizationResult? other)
    {
        if (other is null) return;
        if (UserSelection != other.UserSelection)
        {
            UserSelection = other.UserSelection;
            OnPropertyChanged(nameof(UserSelection));
        }
        if (ResponseReason != other.ResponseReason)
        {
            ResponseReason = other.ResponseReason;
            OnPropertyChanged(nameof(ResponseReason));
        }
        if (DeveloperNote != other.DeveloperNote)
        {
            DeveloperNote = other.DeveloperNote;
            OnPropertyChanged(nameof(DeveloperNote));
        }
        if (ActionToken != other.ActionToken)
        {
            ActionToken = other.ActionToken;
            OnPropertyChanged(nameof(ActionToken));
        }
        if (MaximumNumberOfUses != other.MaximumNumberOfUses)
        {
            MaximumNumberOfUses = other.MaximumNumberOfUses;
            OnPropertyChanged(nameof(MaximumNumberOfUses));
        }
        if (ValidUntil != other.ValidUntil)
        {
            ValidUntil = other.ValidUntil;
            OnPropertyChanged(nameof(ValidUntil));
        }
        if (Type != other.Type)
        {
            Type = other.Type;
            OnPropertyChanged(nameof(Type));
        }
        if (MembershipType != other.MembershipType)
        {
            MembershipType = other.MembershipType;
            OnPropertyChanged(nameof(MembershipType));
        }
    }
}
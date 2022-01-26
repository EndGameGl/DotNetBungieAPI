namespace DotNetBungieAPI.Generated.Models.User.Models;

public class GetCredentialTypesForAccountResponse : IDeepEquatable<GetCredentialTypesForAccountResponse>
{
    [JsonPropertyName("credentialType")]
    public BungieCredentialType CredentialType { get; set; }

    [JsonPropertyName("credentialDisplayName")]
    public string CredentialDisplayName { get; set; }

    [JsonPropertyName("isPublic")]
    public bool IsPublic { get; set; }

    [JsonPropertyName("credentialAsString")]
    public string CredentialAsString { get; set; }

    public bool DeepEquals(GetCredentialTypesForAccountResponse? other)
    {
        return other is not null &&
               CredentialType == other.CredentialType &&
               CredentialDisplayName == other.CredentialDisplayName &&
               IsPublic == other.IsPublic &&
               CredentialAsString == other.CredentialAsString;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GetCredentialTypesForAccountResponse? other)
    {
        if (other is null) return;
        if (CredentialType != other.CredentialType)
        {
            CredentialType = other.CredentialType;
            OnPropertyChanged(nameof(CredentialType));
        }
        if (CredentialDisplayName != other.CredentialDisplayName)
        {
            CredentialDisplayName = other.CredentialDisplayName;
            OnPropertyChanged(nameof(CredentialDisplayName));
        }
        if (IsPublic != other.IsPublic)
        {
            IsPublic = other.IsPublic;
            OnPropertyChanged(nameof(IsPublic));
        }
        if (CredentialAsString != other.CredentialAsString)
        {
            CredentialAsString = other.CredentialAsString;
            OnPropertyChanged(nameof(CredentialAsString));
        }
    }
}
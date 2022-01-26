namespace DotNetBungieAPI.Generated.Models.Entities;

public class EntityActionResult : IDeepEquatable<EntityActionResult>
{
    [JsonPropertyName("entityId")]
    public long EntityId { get; set; }

    [JsonPropertyName("result")]
    public Exceptions.PlatformErrorCodes Result { get; set; }

    public bool DeepEquals(EntityActionResult? other)
    {
        return other is not null &&
               EntityId == other.EntityId &&
               Result == other.Result;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(EntityActionResult? other)
    {
        if (other is null) return;
        if (EntityId != other.EntityId)
        {
            EntityId = other.EntityId;
            OnPropertyChanged(nameof(EntityId));
        }
        if (Result != other.Result)
        {
            Result = other.Result;
            OnPropertyChanged(nameof(Result));
        }
    }
}
namespace DotNetBungieAPI.Models.Defaults;

public class ReadOnlyCollections<T>
{
    public static ReadOnlyCollection<T> Empty { get; } = new(Array.Empty<T>());
}

namespace DotNetBungieAPI.Defaults;

internal class ReadOnlyCollections<T>
{
    internal static ReadOnlyCollection<T> Empty { get; } = new(Array.Empty<T>());
}
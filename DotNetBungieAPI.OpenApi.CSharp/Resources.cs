namespace DotNetBungieAPI.OpenApi.CSharp;

internal static class Resources
{
    internal static readonly Dictionary<string, string> TypeMappings = new()
    {
        { "integer", "int" },
        { "int64", "long" },
        { "int32", "int" },
        { "int16", "short" },
        { "uint32", "uint" },
        { "byte", "byte" },
    };
}

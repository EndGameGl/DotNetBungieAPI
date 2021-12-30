namespace DotNetBungieAPI.OpenApi.Extensions;

public static class StringExtensions
{
    public static string GetFullTypeName(this string relativePath) => relativePath.Split('/').Last();

    public static string GetTypeName(this string relativePath) => relativePath.Split('.').Last();
}
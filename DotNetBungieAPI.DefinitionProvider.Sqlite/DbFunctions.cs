using System.Reflection;

namespace DotNetBungieAPI.DefinitionProvider.Sqlite;

public static class DbFunctions
{
    internal static readonly MethodInfo LikeMethod = typeof(DbFunctions).GetMethod("Like")!;

    public static bool Like(this string textProp, string text)
    {
        return true;
    }
}

using System.Text;

namespace DotNetBungieAPI.HashReferences.Generator;

internal static class StringBuilderExtensions
{
    internal static void AppendLineIndented(this StringBuilder stringBuilder, int level, string text)
    {
        stringBuilder.AppendLine(StringExtensions.GetIndentedString(level, text));
    }

    internal static async Task WriteAsyncAndClear(this TextWriter writer, StringBuilder builder)
    {
        await writer.WriteAsync(builder.ToString());
        builder.Clear();
    }
}
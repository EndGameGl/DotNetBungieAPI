namespace DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers;

public abstract class BaseDefinitionHandler
{
    protected void ValidateAndAddValue(
        Dictionary<string, uint> definitionCacheLookup,
        string? key,
        uint value
    )
    {
        key ??= value.ToString();

        key = string.Join("", key.Split(Helpers.ForbiddenSymbols, StringSplitOptions.TrimEntries));

        if (string.IsNullOrWhiteSpace(key))
            key = value.ToString();

        if (char.IsDigit(key[0]))
            key = $"H{key}";

        var sameEntriesAmount = definitionCacheLookup.Keys.Count(x =>
        {
            if (x.Count(ch => ch == '_') > 1)
            {
                var indexOfLastUnderscore = x.LastIndexOf('_');
                if (indexOfLastUnderscore == x.Length)
                {
                    return x.Split("_")[0] == key;
                }

                if (char.IsDigit(x[indexOfLastUnderscore + 1]))
                {
                    var foundKey = x[..(indexOfLastUnderscore - 1)];
                    return foundKey == key;
                }

                return x == key;
            }

            return x.Split("_")[0] == key;
        });

        definitionCacheLookup.Add(sameEntriesAmount > 0 ? $"{key}_{value}" : key, value);
    }

    protected async Task WriteCommentaryAsync(
        TextWriter textWriter,
        int indentLevel,
        string description
    )
    {
        if (!string.IsNullOrEmpty(description))
        {
            await textWriter.WriteLineAsync(
                StringExtensions.GetIndentedString(indentLevel, "/// <summary>")
            );
            if (description.Contains('\n'))
            {
                var lines = description.Split("\n", StringSplitOptions.RemoveEmptyEntries);
                var arrayLength = lines.Length;
                for (var i = 0; i < arrayLength; i++)
                {
                    await textWriter.WriteLineAsync(
                        StringExtensions.GetIndentedString(
                            indentLevel,
                            $"/// {StringExtensions.GetIndentedString(1, lines[i])}"
                        )
                    );

                    if (i < arrayLength)
                        await textWriter.WriteLineAsync(
                            StringExtensions.GetIndentedString(indentLevel, "/// <para/>")
                        );
                }
            }
            else
            {
                await textWriter.WriteLineAsync(
                    StringExtensions.GetIndentedString(
                        indentLevel,
                        $"/// {StringExtensions.GetIndentedString(1, description)}"
                    )
                );
            }

            await textWriter.WriteLineAsync(
                StringExtensions.GetIndentedString(indentLevel, "/// </summary>")
            );
        }
    }
}

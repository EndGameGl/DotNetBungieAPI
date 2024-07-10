namespace DotNetBungieAPI.HashReferences.Generator;

internal static class Helpers
{
    internal const string Namespace = "DotNetBungieAPI.HashReferences";
    internal const string ClassName = "DefinitionHashes";
    internal const char OpenCurvyBrackets = '{';
    internal const char CloseCurvyBrackets = '}';
    internal const char Tabulation = (char)9;

    internal static readonly string[] ForbiddenSymbols =
    {
        " ",
        ":",
        "-",
        "\\",
        "/",
        "(",
        ")",
        "'",
        ".",
        "[",
        "]",
        "\"",
        "?",
        ",",
        "",
        "…",
        "!",
        "%",
        "+",
        "#",
        "{",
        "}",
        " ",
        "—",
        "~",
        "|",
        ";",
        "–",
        "=",
        "&",
        ">",
        "¡"
    };

    internal static readonly string NewLine = Environment.NewLine;
}

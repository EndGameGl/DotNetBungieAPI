using System.Diagnostics;
using System.Reflection;
using System.Text;
using DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers.Interfaces;
using DotNetBungieAPI.Service.Abstractions;
using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.HashReferences.Generator;

public class DefinitionHashReferencesGenerator
{
    private readonly string _path;
    private readonly ILogger _logger;
    private readonly IBungieClient _bungieClient;

    private readonly IDefinitionHandler[] _handlers;

    public DefinitionHashReferencesGenerator(
        IBungieClient bungieClient,
        string path,
        ILogger logger
    )
    {
        _bungieClient = bungieClient;
        _path = path;
        _logger = logger;
        _handlers = Assembly
            .GetAssembly(typeof(DefinitionHashReferencesGenerator))!
            .DefinedTypes.Where(x => x.ImplementedInterfaces.Contains(typeof(IDefinitionHandler)))
            .Select(x => (IDefinitionHandler)Activator.CreateInstance(x)!)
            .ToArray()!;
    }

    public async Task Generate()
    {
        RunInitialValidation();

        var stringBuilder = new StringBuilder();

        var sw = Stopwatch.StartNew();

        for (var i = 0; i < _handlers.Length; i++)
        {
            var handler = _handlers[i];
            stringBuilder.Clear();
            await CreateDefinitions(handler, stringBuilder);
        }

        sw.Stop();
        _logger.LogInformation(
            "Generated all hash references in {time} ms",
            sw.ElapsedMilliseconds
        );
    }

    private void RunInitialValidation()
    {
        if (!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
        }
    }

    private async Task CreateDefinitions(IDefinitionHandler handler, StringBuilder stringBuilder)
    {
        var sw = Stopwatch.StartNew();
        var filePath = Path.Combine(_path, $"DefinitionHashes.{handler.FileSubName}.cs");
        await using TextWriter textWriter = new StreamWriter(filePath, false);

        var indentLevel = 0;
        stringBuilder.AppendLine($"namespace {Helpers.Namespace}");
        stringBuilder.AppendLine($"{Helpers.OpenCurvyBrackets}");

        await textWriter.WriteAsyncAndClear(stringBuilder);
        indentLevel++;

        stringBuilder.AppendLineIndented(
            indentLevel,
            $"public static partial class {Helpers.ClassName}"
        );
        stringBuilder.AppendLineIndented(indentLevel, $"{Helpers.OpenCurvyBrackets}");

        await textWriter.WriteAsyncAndClear(stringBuilder);
        indentLevel++;

        stringBuilder.AppendLineIndented(indentLevel, $"public static class {handler.ClassName}");
        stringBuilder.AppendLineIndented(indentLevel, $"{Helpers.OpenCurvyBrackets}");
        await textWriter.WriteAsyncAndClear(stringBuilder);
        indentLevel++;

        await handler.Generate(_bungieClient, textWriter, stringBuilder, indentLevel);

        indentLevel--;
        stringBuilder.AppendLineIndented(indentLevel, $"{Helpers.CloseCurvyBrackets}");
        indentLevel--;
        stringBuilder.AppendLineIndented(indentLevel, $"{Helpers.CloseCurvyBrackets}");
        indentLevel--;
        stringBuilder.AppendLineIndented(indentLevel, $"{Helpers.CloseCurvyBrackets}");

        await textWriter.WriteAsyncAndClear(stringBuilder);
        sw.Stop();

        _logger.LogInformation(
            "Finished generating for {DefinitionType} in {Ms} ms",
            handler.FileSubName,
            sw.ElapsedMilliseconds
        );
    }
}

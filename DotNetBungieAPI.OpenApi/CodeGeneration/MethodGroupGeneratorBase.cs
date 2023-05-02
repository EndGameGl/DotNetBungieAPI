using DotNetBungieAPI.OpenApi.Metadata;

namespace DotNetBungieAPI.OpenApi.CodeGeneration;

public abstract class MethodGroupGeneratorBase
{
    public abstract string FileExtension { get; }
    public StreamWriter Writer { get; internal set; }

    public abstract Task GenerateMethodGroupAsync(string groupName, List<MethodData> methods);

    protected async Task WriteAsync(string text)
    {
        await Writer.WriteAsync(text);
    }

    protected async Task WriteAsync(char text)
    {
        await Writer.WriteAsync(text);
    }

    protected async Task WriteLineAsync()
    {
        await Writer.WriteLineAsync();
    }

    protected async Task WriteLineAsync(string text)
    {
        await Writer.WriteLineAsync(text);
    }

    protected async Task WriteLineAsync(char text)
    {
        await Writer.WriteLineAsync(text);
    }
}

using System.Text;
using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers.Interfaces;

public interface IDefinitionHandler
{
    string FileSubName { get; }
    string ClassName { get; }

    Task Generate(
        IBungieClient bungieClient,
        TextWriter textWriter,
        StringBuilder stringBuilder,
        int indentation);
}
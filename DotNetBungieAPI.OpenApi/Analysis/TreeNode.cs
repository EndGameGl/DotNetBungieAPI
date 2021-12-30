using System.Diagnostics;

namespace DotNetBungieAPI.OpenApi.Analysis;

[DebuggerDisplay("{DebuggerDisplay}")]
public class TreeNode
{
    public Dictionary<string, TreeNode> Nodes { get; }
    public string Name { get; set; }
    public bool IsType { get; set; }
    public bool IsFolder { get; set; }

    public TreeNode()
    {
        Nodes = new Dictionary<string, TreeNode>();
    }

    public void AddKey(string path)
    {
        var elements = path.Split('.');
        if (elements.Length == 1)
        {
            Nodes.TryAdd(elements[0], new TreeNode() { IsType = true, Name = elements[0], IsFolder = false });
        }
        else
        {
            var leftovers = elements[1..];
            Nodes.TryAdd(elements[0], new TreeNode() { IsType = false, Name = elements[0], IsFolder = true });
            Nodes[elements[0]].AddKey(string.Join('.', leftovers));
        }
    }

    private string DebuggerDisplay => $"{(IsFolder ? "Folder" : "Type")} : {Name}";
}
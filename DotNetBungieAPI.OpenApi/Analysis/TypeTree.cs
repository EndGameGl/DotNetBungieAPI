namespace DotNetBungieAPI.OpenApi.Analysis;

public class TypeTree
{
    public Dictionary<string, TreeNode> Nodes { get; }

    public TypeTree()
    {
        Nodes = new Dictionary<string, TreeNode>();
    }

    public void CreateSchemasTypeTree(Models.OpenApi openApi)
    {
        var modelTypes = openApi.Components.Schemas.Keys.ToList();

        foreach (var type in modelTypes)
        {
            AddKey(type);
        }
    }

    private void AddKey(string path)
    {
        var elements = path.Split('.');
        if (elements.Length == 1)
        {
            Nodes.TryAdd(
                elements[0],
                new TreeNode()
                {
                    IsType = true,
                    Name = elements[0],
                    IsFolder = false,
                }
            );
        }
        else
        {
            var leftovers = elements[1..];
            Nodes.TryAdd(
                elements[0],
                new TreeNode()
                {
                    IsType = false,
                    Name = elements[0],
                    IsFolder = true,
                }
            );
            Nodes[elements[0]].AddKey(string.Join('.', leftovers));
        }
    }
}

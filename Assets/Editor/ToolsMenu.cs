using UnityEditor;
using static System.IO.Directory;
using static System.IO. Path;
using static UnityEditor.AssetDatabase;
using static UnityEngine.Application;

public static class ToolsMenu
{

    [MenuItem("EncaPlugins/Setup/Create Default Folders")]
    public static void CreateDefaultFolders()
    {
        CreateDirectories(dataPath,"Scripts","Art","Scenes");
        Refresh();
    }

    private static void CreateDirectories(string root, params string[] directoryList)
    {
        foreach (var directory in directoryList)
        {
            CreateDirectory(Combine(root, directory));
        }
    }

}

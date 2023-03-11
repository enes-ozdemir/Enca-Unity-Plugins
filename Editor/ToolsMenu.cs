using UnityEditor;
using UnityEngine;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEditor.AssetDatabase;
using static UnityEngine.Application;

namespace Enca
{
    public static class ToolsMenu
    {
        [MenuItem("EncaPlugins/Setup/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            CreateDirectories(dataPath, "_Scripts", "Art", "Scenes", "Plugins");
            Refresh();
        }

        [MenuItem("EncaPlugins/Setup/Create Default GameObjects")]
        public static void CreateDefaultGameObjects()
        {
            string[] objectNames = {"Managers", "Setup", "Environment", "Canvasses", "Systems"};
            AddEmptyGameObjectsToScene(objectNames);
        }

        private static void AddEmptyGameObjectsToScene(string[] names)
        {
            foreach (var name in names)
            {
                new GameObject("-------------------");
                new GameObject(name);
            }
        }

        private static void CreateDirectories(string root, params string[] directoryList)
        {
            foreach (var directory in directoryList)
            {
                CreateDirectory(Combine(root, directory));
            }
        }
    }
}
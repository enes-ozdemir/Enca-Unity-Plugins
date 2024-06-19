using UnityEditor;
using UnityEngine;
using System.IO;

public class GitIgnoreUtility : Editor
{
    private const string GitignoreFilePath = ".gitignore";

    [MenuItem("Assets/Add to .gitignore", false, 20)]
    private static void AddToGitignore()
    {
        var path = GetSelectedPathOrFallback();
        if (string.IsNullOrEmpty(path))
        {
            Debug.LogError("No valid file or folder selected.");
            return;
        }

        var relativePath = GetRelativePath(path);

        if (!File.Exists(GitignoreFilePath))
            File.Create(GitignoreFilePath).Dispose();

        using (StreamWriter sw = File.AppendText(GitignoreFilePath))
        {
            sw.WriteLine(relativePath);
        }

        Debug.Log($"{relativePath} has been added to {GitignoreFilePath}");
    }

    private static string GetSelectedPathOrFallback()
    {
        var path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (string.IsNullOrEmpty(path))
            path = "Assets";

        if (File.Exists(path))
            return path;

        if (Directory.Exists(path))
            return path + "/";

        return null;
    }

    private static string GetRelativePath(string path)
    {
        var projectPath = Path.GetFullPath(Application.dataPath).Replace("\\", "/");
        if (path.StartsWith(projectPath))
            path = path.Substring(projectPath.Length + 1);
        return path;
    }

    [MenuItem("Assets/Add to .gitignore", true)]
    private static bool AddToGitignoreValidation() => Selection.activeObject != null;
}
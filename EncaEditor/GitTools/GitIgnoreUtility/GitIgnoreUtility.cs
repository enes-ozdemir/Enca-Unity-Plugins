using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GitIgnoreUtility : Editor
{
    private const string GitignoreFilePath = ".gitignore";
    internal static Action OnGitignoreUpdated;

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

        OnGitignoreUpdated?.Invoke();
        Debug.Log($"{relativePath} has been added to {GitignoreFilePath}");
    }

    [MenuItem("Assets/Remove from .gitignore", false, 21)]
    private static void RemoveFromGitignore()
    {
        var path = GetSelectedPathOrFallback();
        if (string.IsNullOrEmpty(path))
        {
            Debug.LogError("No valid file or folder selected.");
            return;
        }

        var relativePath = GetRelativePath(path);

        if (!File.Exists(GitignoreFilePath))
        {
            Debug.LogError($"{GitignoreFilePath} does not exist.");
            return;
        }

        var entries = new List<string>(File.ReadAllLines(GitignoreFilePath));
        if (entries.Contains(relativePath))
        {
            entries.Remove(relativePath);
            File.WriteAllLines(GitignoreFilePath, entries);
            Debug.Log($"{relativePath} has been removed from {GitignoreFilePath}");
            OnGitignoreUpdated?.Invoke();
        }
        else
        {
            Debug.LogWarning($"{relativePath} is not in {GitignoreFilePath}");
        }
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
    private static bool AddToGitignoreValidation()
    {
        var path = GetSelectedPathOrFallback();
        var relativePath = GetRelativePath(path);
        return Selection.activeObject != null && !IsInGitignore(relativePath);
    }

    [MenuItem("Assets/Remove from .gitignore", true)]
    private static bool RemoveFromGitignoreValidation()
    {
        var path = GetSelectedPathOrFallback();
        var relativePath = GetRelativePath(path);
        return Selection.activeObject != null && IsInGitignore(relativePath);
    }

    private static bool IsInGitignore(string relativePath)
    {
        if (File.Exists(GitignoreFilePath))
        {
            var entries = new List<string>(File.ReadAllLines(GitignoreFilePath));
            return entries.Contains(relativePath);
        }
        return false;
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GitIgnoreUtility : Editor
{
    private static string gitignoreFilePath;
    //todo add default gitIgnore

    static GitIgnoreUtility()
    {
        gitignoreFilePath = EditorPrefs.GetString("GitignoreFilePath", ".gitignore");
        UpdateSettings(gitignoreFilePath);
    }

    internal static Action OnGitignoreUpdated;

    public static void UpdateSettings(string newGitignoreFilePath)
    {
        gitignoreFilePath = newGitignoreFilePath;
    }

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

        EnsureGitignoreFileExists();

        using (StreamWriter sw = File.AppendText(gitignoreFilePath))
        {
            sw.WriteLine(relativePath);
        }

        OnGitignoreUpdated?.Invoke();
        Debug.Log($"{relativePath} has been added to {gitignoreFilePath}");
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

        if (!File.Exists(gitignoreFilePath))
        {
            Debug.LogError($"{gitignoreFilePath} does not exist.");
            return;
        }

        var entries = new List<string>(File.ReadAllLines(gitignoreFilePath));
        if (entries.Contains(relativePath))
        {
            entries.Remove(relativePath);
            File.WriteAllLines(gitignoreFilePath, entries);
            Debug.Log($"{relativePath} has been removed from {gitignoreFilePath}");
            OnGitignoreUpdated?.Invoke();
        }
        else
        {
            Debug.LogWarning($"{relativePath} is not in {gitignoreFilePath}");
        }
    }

    private static void EnsureGitignoreFileExists()
    {
        if (!File.Exists(gitignoreFilePath))
        {
            var defaultGitignoreFullPath = Path.Combine(Application.dataPath, "../", "Assets/YourPackageName/Editor/DefaultGitignore/.gitignore");
            if (File.Exists(defaultGitignoreFullPath))
            {
                File.Copy(defaultGitignoreFullPath, gitignoreFilePath);
                Debug.Log($"{gitignoreFilePath} has been created using the default template.");
            }
            else
            {
                File.Create(gitignoreFilePath).Dispose();
                Debug.Log($"{gitignoreFilePath} has been created as an empty file.");
            }
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
        if (File.Exists(gitignoreFilePath))
        {
            var entries = new List<string>(File.ReadAllLines(gitignoreFilePath));
            return entries.Contains(relativePath);
        }
        return false;
    }
}

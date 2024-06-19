using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

[InitializeOnLoad]
public class GitignoreOverlay
{
    private static GUIContent folderIgnoredIcon;
    private static HashSet<string> gitignoreEntries = new HashSet<string>(); 

    static GitignoreOverlay()
    {
        folderIgnoredIcon = EditorGUIUtility.IconContent("d_winbtn_mac_close_h@2x");
        UpdateGitignoreEntries();
        EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemGUI;
        GitIgnoreUtility.OnGitignoreUpdated += UpdateGitignoreEntries;
        AssetDatabase.Refresh();
    }
    
    private static void UpdateGitignoreEntries()
    {
        gitignoreEntries.Clear();
        if (File.Exists(".gitignore"))
        {
            string[] entries = File.ReadAllLines(".gitignore");
            foreach (string entry in entries)
            {
                string trimmedEntry = entry.Trim();
                if (!string.IsNullOrEmpty(trimmedEntry))
                {
                    // Convert to relative path if necessary
                    if (!trimmedEntry.StartsWith("Assets/"))
                    {
                        trimmedEntry = "Assets/" + trimmedEntry;
                    }
                    gitignoreEntries.Add(trimmedEntry);
                }
            }
        }
    }

    private static void OnProjectWindowItemGUI(string guid, Rect selectionRect)
    {
        string path = AssetDatabase.GUIDToAssetPath(guid);
        
        if (IsInGitignore(path))
        {
            Rect iconRect = new Rect(selectionRect.x + selectionRect.width - 16, selectionRect.y, 16, 16);
            GUI.Label(iconRect, folderIgnoredIcon);
        }
    }

    private static bool IsInGitignore(string path)
    {
        foreach (string entry in gitignoreEntries)
        {
            if (entry.EndsWith("/"))
            {
                // Handle folder entries ending with '/'
                if (path.Equals(entry.TrimEnd('/')) || path.StartsWith(entry))
                {
                    return true;
                }
            }
            else
            {
                // Handle file or other entries
                if (path.Equals(entry) || path.StartsWith(entry))
                {
                    return true;
                }
            }
        }
        return false;
    }
}

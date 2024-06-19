using System.IO;
using UnityEditor;
using UnityEngine;

public class GitignoreSettingsWindow : EditorWindow
{
    private string _gitignoreFilePath = ".gitignore";
    
    [MenuItem("Tools/Gitignore Settings")]
    public static void ShowWindow()
    {
        GetWindow<GitignoreSettingsWindow>("Gitignore Settings");
    }

    private void OnEnable()
    {
        _gitignoreFilePath = EditorPrefs.GetString("GitignoreFilePath", ".gitignore");
    }

    private void OnGUI()
    {
        GUILayout.Label("Gitignore Settings", EditorStyles.boldLabel);

        // Gitignore file path
        GUILayout.Label("Gitignore File Path", EditorStyles.label);
        _gitignoreFilePath = GUILayout.TextField(_gitignoreFilePath);
        if (GUILayout.Button("Browse"))
        {
            string path = EditorUtility.OpenFilePanel("Select .gitignore file", "", "");
            if (!string.IsNullOrEmpty(path))
            {
                _gitignoreFilePath = path;
            }
        }


        if (GUILayout.Button("Save Settings"))
        {
            SaveSettings();
        }

        // Open .gitignore file
        if (GUILayout.Button("Open .gitignore File"))
        {
            if (File.Exists(_gitignoreFilePath))
            {
                EditorUtility.OpenWithDefaultApp(_gitignoreFilePath);
            }
            else
            {
                EditorUtility.DisplayDialog("Error", "The specified .gitignore file does not exist.", "OK");
            }
        }
    }

    private void SaveSettings()
    {
        EditorPrefs.SetString("GitignoreFilePath", _gitignoreFilePath);
        GitIgnoreUtility.UpdateSettings(_gitignoreFilePath);
    }
}
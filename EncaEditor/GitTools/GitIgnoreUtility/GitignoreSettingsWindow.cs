using System.IO;
using UnityEditor;
using UnityEngine;

public class GitignoreSettingsWindow : EditorWindow
{
    private string _gitignoreFilePath = ".gitignore";

    private static readonly string DefaultGitIgnoreFilePath = Path.Combine(
        Application.dataPath, "../Packages/Enca Plugin/EncaEditor/GitTools/Resources/.gitignore"
    );

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
        DrawGitignoreFilePathField();
        DrawBrowseButton();
        DrawCreateNewDefaultGitIgnoreButton();
        DrawSaveSettingsButton();
        DrawOpenGitignoreFileButton();
    }

    private void DrawGitignoreFilePathField()
    {
        GUILayout.Label("Gitignore File Path", EditorStyles.label);
        _gitignoreFilePath = GUILayout.TextField(_gitignoreFilePath);
    }

    private void DrawBrowseButton()
    {
        if (GUILayout.Button("Browse"))
        {
            var path = EditorUtility.OpenFilePanel("Select .gitignore file", "", "");
            if (!string.IsNullOrEmpty(path)) _gitignoreFilePath = path;
        }
    }

    private void DrawCreateNewDefaultGitIgnoreButton()
    {
        if (GUILayout.Button("Create New Default GitIgnore"))
        {
            if (!File.Exists(_gitignoreFilePath))
                CreateNewGitIgnoreFile();
            else
                HandleExistingGitIgnoreFile();
        }
    }

    private void CreateNewGitIgnoreFile()
    {
        File.WriteAllText(_gitignoreFilePath, File.ReadAllText(DefaultGitIgnoreFilePath));
    }

    private void HandleExistingGitIgnoreFile()
    {
        var userConfirmedOverwrite  = EditorUtility.DisplayDialog(
            "Create New default Unity .gitignore",
            "Attention!! .gitignore file already exists for this project. Do you want to overwrite it? \nYou will lose all of your custom entries inside the .gitIgnore File.",
            "Yes", "No"
        );

        if (!userConfirmedOverwrite) return;
        
        CreateNewGitIgnoreFile();
        GitIgnoreUtility.OnGitignoreUpdated?.Invoke();
    }

    private void DrawSaveSettingsButton()
    {
        if (GUILayout.Button("Save Settings")) SaveSettings();
    }

    private void DrawOpenGitignoreFileButton()
    {
        if (GUILayout.Button("Open .gitignore File"))
        {
            if (File.Exists(_gitignoreFilePath))
                EditorUtility.OpenWithDefaultApp(_gitignoreFilePath);
            else
                EditorUtility.DisplayDialog("Error", "The specified .gitignore file does not exist.", "OK");
        }
    }

    private void SaveSettings()
    {
        EditorPrefs.SetString("GitignoreFilePath", _gitignoreFilePath);
        GitIgnoreUtility.UpdateSettings(_gitignoreFilePath);
    }
}
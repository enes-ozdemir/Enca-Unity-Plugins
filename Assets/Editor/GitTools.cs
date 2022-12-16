using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Application;

public static class GitTools
{
    private static string fileName = ".gitignore";
    
    static string[] lines = { "# Ignore assets", "/[Aa]ssets/Art",};
    
    [MenuItem("EncaPlugins/Git/Add Art Folder To Git Ignore")]
    public static void AddArtFolderToGitIgnore()
    {

        var assetFolder = dataPath;
        var rootFolder =   assetFolder.Remove(assetFolder.LastIndexOf("/") + 1);
        
        DirectoryInfo d = new DirectoryInfo(rootFolder);
        foreach (var file in d.GetFiles(".gitignore"))
        {
            Debug.Log("Got it"+file);
            var currentContent = new StreamReader(file.ToString()).ReadToEnd();
            //TextWriter streamWriter = new StreamWriter(file.ToString());
            foreach (var line in lines)
            {
                currentContent += line;
            }

            try
            {
                File.AppendAllText(file.ToString(),currentContent);
                // streamWriter.WriteLine(currentContent);

            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                throw;
            }
        }
   
    }

    

}
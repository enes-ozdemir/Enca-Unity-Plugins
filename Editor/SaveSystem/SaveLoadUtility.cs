using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Enca.SaveSystem
{
    public static class SaveLoadUtility
    {
        public static async Task SaveAsync(SaveData saveData)
        {
            var json = JsonUtility.ToJson(saveData);
            await File.WriteAllTextAsync(saveData.path, json);
        }

        public static async Task LoadAsync(SaveData saveData)
        {
            if (File.Exists(saveData.path))
            {
                var json = await File.ReadAllTextAsync(saveData.path);
                JsonUtility.FromJsonOverwrite(json, saveData);
            }
        }

        public static void InitializeSaveData(SaveData saveData, string fileNamePrefix, int slotID = 0)
        {
            if (string.IsNullOrEmpty(saveData.uniqueID))
                saveData.uniqueID = Guid.NewGuid().ToString();
            saveData.path = Application.persistentDataPath + "/" + fileNamePrefix + "_Slot" + slotID + "_" +
                            saveData.uniqueID + ".json";
        }
    }
}
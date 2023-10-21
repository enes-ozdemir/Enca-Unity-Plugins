using System;
using UnityEngine;

namespace Enca.SaveSystem
{
    public class SaveData : ScriptableObject
    {
        public string version = VersionManager.CurrentVersion;
        public string timestamp;
        public string path;
        public string uniqueID;

        public void GenerateUniqueID()
        {
            uniqueID = Guid.NewGuid().ToString();
        }
    }
}
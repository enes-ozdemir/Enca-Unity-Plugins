using System.Threading.Tasks;
using UnityEngine;

namespace Enca.SaveSystem
{
    public class Enemy : MonoBehaviour, ISaveable
    {
        public SaveData enemySaveData;

        private void Start()
        {
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            SaveLoadUtility.InitializeSaveData(enemySaveData, "Enemy", 1);
        
            await OnLoadAsync();
        }

        public async Task OnSaveAsync()
        {
            await SaveLoadUtility.SaveAsync(enemySaveData);
        }

        public async Task OnLoadAsync()
        {
            await SaveLoadUtility.LoadAsync(enemySaveData);
        }
        
        private void OnDisable()
        {
            SaveLoadManager.OnSaveAsync -= OnSaveAsync;
            SaveLoadManager.OnLoadAsync -= OnLoadAsync;
        }
        private void OnEnable()
        {
            SaveLoadManager.OnSaveAsync += OnSaveAsync;
            SaveLoadManager.OnLoadAsync += OnLoadAsync;
        }
    }

}
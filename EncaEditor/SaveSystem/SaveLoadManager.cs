using System.Threading.Tasks;

namespace Enca.SaveSystem
{
    public static class SaveLoadManager
    {
        public delegate Task SaveLoadActionAsync();

        public static event SaveLoadActionAsync OnSaveAsync;
        public static event SaveLoadActionAsync OnLoadAsync;
        public static int CurrentSaveSlot { get; private set; } = 0;

        private static void SetSaveSlot(int slotID) => CurrentSaveSlot = slotID;

        public static async Task SaveAllAsync(int slotID = 0)
        {
            SetSaveSlot(slotID);
            if (OnSaveAsync != null) await OnSaveAsync.Invoke();
        }

        public static async Task LoadAllAsync(int slotID = 0)
        {
            SetSaveSlot(slotID);
            if (OnLoadAsync != null) await OnLoadAsync.Invoke();
        }
    }
}
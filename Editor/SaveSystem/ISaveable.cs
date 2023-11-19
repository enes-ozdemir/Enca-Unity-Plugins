using System.Threading.Tasks;
using UnityEngine;

namespace Enca.SaveSystem
{
    public interface ISaveable
    {
        async Task OnSaveAsync(SaveData saveData);
        async Task<SaveData> OnLoadAsync();
    }

}
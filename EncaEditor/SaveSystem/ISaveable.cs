using System.Threading.Tasks;
using UnityEngine;

namespace Enca.SaveSystem
{
    public interface ISaveable
    {
        Task OnSaveAsync();
        Task OnLoadAsync();
    }

}
using AppTime.Models;
using Avalonia.Media.Imaging;
using System.Collections.Generic;

namespace AppTime.Stores.AppProcessStores
{
    public interface IAppProcessStore : IStore<List<AppProcess>>
    {
        void UpdateState();

        void AddProcess(string processName, string processFileName, Bitmap icon);
    }
}

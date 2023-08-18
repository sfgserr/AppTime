using AppTime.Models;
using System.Collections.Generic;

namespace AppTime.Stores.AppProcessStores
{
    public interface IAppProcessStore : IStore
    {
        List<AppProcess> AppProcesses { get; set; }

        void UpdateState();

        void AddProcess(string processName);
    }
}

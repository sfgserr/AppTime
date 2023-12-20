using AppTime.Services.AppProcessServices;
using AppTime.Stores.AppProcessStores;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace AppTime.BackgroundWorkers
{
    public class SpendTimeWorker
    {
        private readonly IAppProcessStore _appProcessStore;
        private readonly IAppProcessService _appProcessService;

        public SpendTimeWorker(IAppProcessStore appProcessStore, IAppProcessService appProcessService)
        {
            _appProcessStore = appProcessStore;
            _appProcessService = appProcessService;
        }

        public void StartWork(int index)
        {
            Timer timer = new Timer(SpendTime, index, 0, 60000);
        }

        private void SpendTime(object? state)
        {
            int index = (int)state;

            if (index >= _appProcessStore.State.Count)
                return;

            if (_appProcessService.GetCurrentProcesses().Any(pr => pr.ProcessName == _appProcessStore.State[index].Name))
            {
                _appProcessStore.State[index].AddTime(60);
                _appProcessStore.UpdateState();
            }
        }
    }
}

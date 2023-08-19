﻿using AppTime.Services.AppProcessServices;
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
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += SpendTime;

            bgWorker.RunWorkerAsync(index);
        }

        private void SpendTime(object sender, DoWorkEventArgs e)
        {
            int index = (int)e.Argument;

            while (true)
            {
                if (index >= _appProcessStore.State.Count)
                    break;

                if (_appProcessService.GetCurrentProcesses().Any(pr => pr.ProcessName == _appProcessStore.State[index].Name))
                {   
                    _appProcessStore.State[index].AddTime(1);
                    _appProcessStore.UpdateState();
                    Thread.Sleep(900);
                }
            }
        }
    }
}

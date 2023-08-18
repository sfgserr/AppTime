using AppTime.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace AppTime.Stores.AppProcessStores
{
    public class AppProcessStore : IAppProcessStore
    {
        public event Action StateChanged;

        private List<AppProcess> _appProcesses = new List<AppProcess>();

        public List<AppProcess> State
        {
            get => _appProcesses;
            set
            {
                _appProcesses = value;
                StateChanged?.Invoke();
            }
        }

        public void UpdateState()
        {
            StateChanged?.Invoke();
        }

        public void AddProcess(string processName, string processFileName)
        {
            Bitmap icon = Icon.ExtractAssociatedIcon(processFileName).ToBitmap();

            AppProcess process = new AppProcess() { Name = processName };

            using (MemoryStream ms = new MemoryStream())
            {
                icon.Save(ms, ImageFormat.Png);
                ms.Position = 0;

                process.Icon = new Avalonia.Media.Imaging.Bitmap(ms);
            }

            State.Add(process);

            StateChanged?.Invoke();
        }
    }
}

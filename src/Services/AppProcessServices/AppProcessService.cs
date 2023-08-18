using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using AppTime.Models;
using System.Threading.Tasks;
using AppTime.Services.JsonServices;
using AppTime.Stores.StateSerializers;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace AppTime.Services.AppProcessServices
{
    public class AppProcessService : IAppProcessService
    {
        const string _path = "Processes.json";

        private readonly IJsonService _jsonService;
        private readonly IStateSerializer _stateSerializer;

        public AppProcessService(IJsonService jsonService, IStateSerializer stateSerializer)
        {
            _jsonService = jsonService;
            _stateSerializer = stateSerializer;
        }

        public Avalonia.Media.Imaging.Bitmap GetProcessIconByName(string processFileName)
        {
            Bitmap icon = Icon.ExtractAssociatedIcon(processFileName).ToBitmap();

            using (MemoryStream ms = new MemoryStream())
            {
                icon.Save(ms, ImageFormat.Png);
                ms.Position = 0;

                return new Avalonia.Media.Imaging.Bitmap(ms);
            }
        }

        public List<Process> GetCurrentProcesses()
        {
            return Process.GetProcesses()
                          .Where(p => (long)p.MainWindowHandle != 0)
                          .ToList();
        }

        public async Task<List<AppProcess>> GetTrackedProcesses()
        {
            try
            {
                List<AppProcess> processes = await _jsonService.DeserializeAsync<List<AppProcess>>(_path);
                processes.ForEach(p => p.Icon = GetProcessIconByName(p.FileName));
                return processes;
            }
            catch
            {   
                return null;
            }
        }

        public async Task SaveProcesses()
        {
            await _stateSerializer.SerializeState(_path);
        }
    }
}

using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using AppTime.Models;
using System.Threading.Tasks;
using AppTime.Services.JsonServices;

namespace AppTime.Services.AppProcessServices
{
    public class AppProcessService : IAppProcessService
    {
        const string _path = "Processes.json";

        private readonly IJsonService _jsonService;

        public AppProcessService(IJsonService jsonService)
        {
            _jsonService = jsonService;
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
                return await _jsonService.DeserializeAsync<List<AppProcess>>(_path);
            }
            catch
            {
                return null;
            }
        }
    }
}

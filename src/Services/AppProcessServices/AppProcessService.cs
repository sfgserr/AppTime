using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using AppTime.Models;
using System.Threading.Tasks;
using AppTime.Services.JsonServices;
using AppTime.Stores.StateSerializers;

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

        public async Task SaveProcesses()
        {
            await _stateSerializer.SerializeState(_path);
        }
    }
}

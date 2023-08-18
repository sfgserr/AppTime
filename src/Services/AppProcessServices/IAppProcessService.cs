using AppTime.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AppTime.Services.AppProcessServices
{
    public interface IAppProcessService 
    {
        List<Process> GetCurrentProcesses();

        Task<List<AppProcess>> GetTrackedProcesses();
    }
}

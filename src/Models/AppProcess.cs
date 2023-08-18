
using AppTime.Helpers;

namespace AppTime.Models
{
    public class AppProcess
    {
        public string Name { get; set; } = string.Empty;
        public int TimeSpentInSeconds { get; set; } = 0;
        public string SpentTime { get; set; } = string.Empty;

        public void AddTime(int seconds)
        {
            TimeSpentInSeconds += seconds;
            SpentTime = TimeSpentInSeconds.ConvertIntToTimeFormat();
        }
    }
}

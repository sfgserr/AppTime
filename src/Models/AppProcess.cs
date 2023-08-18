using AppTime.Helpers;
using Avalonia.Media.Imaging;
using System.Text.Json.Serialization;

namespace AppTime.Models
{
    public class AppProcess
    {
        public string Name { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public int TimeSpentInSeconds { get; set; } = 0;
        public string SpentTime { get; set; } = string.Empty;
        [JsonIgnore]
        public Bitmap Icon { get; set; }

        public void AddTime(int seconds)
        {
            TimeSpentInSeconds += seconds;
            SpentTime = TimeSpentInSeconds.ConvertIntToTimeFormat();
        }
    }
}

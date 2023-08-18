using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppTime.Services.JsonServices
{
    public class JsonService : IJsonService
    {
        public async Task SerializeAsync<T>(T obj, string path)
        {
            if (File.Exists(path))
                await File.WriteAllTextAsync(path, "");

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, obj);
            }
        }

        public async Task<T> DeserializeAsync<T>(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                return await JsonSerializer.DeserializeAsync<T>(fs);
            }
        }
    }
}

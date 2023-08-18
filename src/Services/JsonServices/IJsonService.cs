using System.Threading.Tasks;

namespace AppTime.Services.JsonServices
{
    public interface IJsonService
    {
        Task SerializeAsync<T>(T obj, string path);

        Task<T> DeserializeAsync<T>(string path);
    }
}

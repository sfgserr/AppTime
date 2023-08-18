using AppTime.Services.JsonServices;
using System.Threading.Tasks;

namespace AppTime.Stores.StateSerializers
{
    public class StateSerializer<T> : IStateSerializer
    {
        private readonly IStore<T> _store;
        private readonly IJsonService _jsonService;

        public StateSerializer(IStore<T> store, IJsonService jsonService)
        {
            _store = store;
            _jsonService = jsonService;
        }

        public async Task SerializeState(string path)
        {
            await _jsonService.SerializeAsync(_store.State, path);
        }
    }
}

using System.Threading.Tasks;

namespace AppTime.Stores.StateSerializers
{
    public interface IStateSerializer
    {
        Task SerializeState(string path);
    }
}

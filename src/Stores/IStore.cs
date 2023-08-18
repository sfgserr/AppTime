using System;

namespace AppTime.Stores
{
    public interface IStore<T>
    {
        event Action StateChanged;

        T State { get; set; }
    }
}

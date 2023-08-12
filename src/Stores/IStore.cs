using System;

namespace AppTime.Stores
{
    public interface IStore
    {
        event Action StateChanged;
    }
}

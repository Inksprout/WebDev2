using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineplexWebsite.Repositories.Contracts
{
    public interface ISessionRepository
    {
        T Get<T>(string key);
        void Set<T>(string key, T data);
        void Remove(string key);
    }
}

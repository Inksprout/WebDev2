using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineplexWebsite.Repositories.Contracts;
using CineplexWebsite.Extensions;
using Microsoft.AspNetCore.Http;

namespace CineplexWebsite.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public T Get<T>(string key)
        {
            return _httpContextAccessor.HttpContext.Session.Get<T>(key);
        }

        public void Set<T>(string key, T data)
        {
            _httpContextAccessor.HttpContext.Session.Set<T>(key, data);
        }

        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Session.Remove(key);
        }
    }
}

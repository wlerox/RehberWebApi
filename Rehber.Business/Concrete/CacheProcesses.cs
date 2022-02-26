using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Rehber.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Business.Concrete
{
    public class CacheProcesses : ICacheProcesses
    {
        private readonly IDistributedCache _distributedCache;

        public CacheProcesses(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task DeletePersonFromCache(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }

        public async Task<string> GetAllPersonFromCache()
        {
            var personsFromCache = await _distributedCache.GetStringAsync("allPerson");
            //var persons = JsonConvert.DeserializeObject<List<T>>(personsFromCache);
            return personsFromCache;
        }

        public async Task<string> GetPersonWithDetailFromCache(string key)
        {
            var personFromCache = await _distributedCache.GetStringAsync(key);
            //var person = JsonConvert.DeserializeObject<T>(personFromCache);
            return personFromCache;
        }

        public async Task SetAllPersonToCache(string value)
        {
            //var personsConvertToString = JsonConvert.SerializeObject(allPerson);
            await _distributedCache.SetStringAsync("allPerson",value);
        }

        public async Task SetPersonWithDetailToCache(string person, string key)
        {
            //var personConvertToString = JsonConvert.SerializeObject(person);
            await _distributedCache.SetStringAsync(key, person);
        }
    }
}

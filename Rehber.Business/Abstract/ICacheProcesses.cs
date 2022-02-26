using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Business.Abstract
{
    public interface ICacheProcesses
    {
        Task<string> GetAllPersonFromCache();
        Task<string> GetPersonWithDetailFromCache(string key);
        Task SetAllPersonToCache(string value);
        Task SetPersonWithDetailToCache(string person, string key);
        Task DeletePersonFromCache(string key);
    }
}

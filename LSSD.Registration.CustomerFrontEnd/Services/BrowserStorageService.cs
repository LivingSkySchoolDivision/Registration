using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSSD.Registration.CustomerFrontEnd.Services
{
    public class BrowserStorageService
    {
        private ILocalStorageService _localStorageService;

        public BrowserStorageService(ILocalStorageService LocalStorageService) 
        {
            this._localStorageService = LocalStorageService;
        }

        /// <summary>
        /// Returns the specified object from local storage, or a new instance of that kind of object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <returns></returns>
        public async Task<T> GetOrNew<T>(string Key) where T : new()
        {
            return await _localStorageService.GetItemAsync<T>(Key) ?? new T();
        }

        /// <summary>
        /// Returns the specified object from local storage, or the default value for that type (null, in most cases).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <returns></returns>
        public async Task<T> Get<T>(string Key)
        {
            return await _localStorageService.GetItemAsync<T>(Key) ?? default(T);
        }


        public async Task Set<T>(string Key, T Object)
        {
            await _localStorageService.SetItemAsync(Key, Object);
        }

        public async Task Clear()
        {
            await _localStorageService.ClearAsync();
        }

    }
}

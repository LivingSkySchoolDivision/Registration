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

        public async Task<T> GetItem<T>(string Key) where  T : new()
        { 
            try
            {
                return await _localStorageService.GetItemAsync<T>(Key);
            }
            catch { }

            return new T();
        }

        public async Task SetItem<T>(string Key, T Object)
        {
            await _localStorageService.SetItemAsync(Key, Object);
        }

        public async Task Clear()
        {
            await _localStorageService.ClearAsync();
        }

    }
}

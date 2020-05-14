using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSSD.Registration.CustomerFrontEnd.Services
{

    // I would love to be able to just directly inject the ILocalStorageService directly into this file,
    // but that doesn't appear to work, so for now we need to get it as a parameter.

    public class BrowserStorageHelper
    {
        public async Task<T> GetItem<T>(ILocalStorageService StorageService, string Key) where  T : new()
        {
            try
            {
                return await StorageService.GetItemAsync<T>(Key);
            }
            catch { }

            return new T();
        }

        public async Task SetItem<T>(ILocalStorageService StorageService, string Key, T Object)
        {
            await StorageService.SetItemAsync(Key, Object);
        }

        public async Task Clear(ILocalStorageService StorageService)
        {
            await StorageService.ClearAsync();
        }

    }
}

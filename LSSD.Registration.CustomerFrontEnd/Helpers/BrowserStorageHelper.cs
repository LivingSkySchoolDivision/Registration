using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSSD.Registration.CustomerFrontEnd.Helpers
{
    public static class BrowserStorageHelper
    {
        public static async Task<T> GetItem<T>(ILocalStorageService StorageService, string Key) where  T : new()
        {
            try
            {
                return await StorageService.GetItemAsync<T>(Key);
            }
            catch { }

            return new T();
        }

        public static async Task SetItem<T>(ILocalStorageService StorageService, string Key, T Object)
        {
            await StorageService.SetItemAsync(Key, Object);
        }

        public static async Task Clear(ILocalStorageService StorageService)
        {
            await StorageService.ClearAsync();
        }

    }
}

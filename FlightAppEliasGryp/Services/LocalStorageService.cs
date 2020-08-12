using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace FlightAppEliasGryp.Services
{
    public class LocalStorageService<T>
    {
        private StorageFolder folder = ApplicationData.Current.LocalFolder;

        public async Task SaveFileInStorage(string filename, T file, CreationCollisionOption strategy)
        {
            var newFile = await folder.CreateFileAsync(filename, strategy);
            var text = JsonConvert.SerializeObject(file);
            await FileIO.WriteTextAsync(newFile, text);
        }

        public async Task<T> GetFileFromStorage(string filename)
        {
            if (!(await folder.TryGetItemAsync(filename) is IStorageFile file)) { return default(T); }
            else
            {
                var text = await FileIO.ReadTextAsync(file);
                return JsonConvert.DeserializeObject<T>(text);
            }
        }
    }
}

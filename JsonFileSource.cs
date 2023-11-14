using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7_FileJsonSerialise_Due14Nov.Interfaces;

namespace Week7_FileJsonSerialise_Due14Nov
{
    internal class JsonFileSource<T> : ICustomCollectionFileBasedSource<T>
    {
        public string FilePath 
        { 
            get;
            init;
        }

        public JsonFileSource(string filePath)
        {
            FilePath = filePath;
        }
        /// <summary>
        /// Fetch from file and return the collection
        /// </summary>
        /// <returns></returns>
        public async Task<IList<T>> FetchAsync()
        {
            using StreamReader sr = new(FilePath);
            var jsonStr = await sr.ReadToEndAsync();
            var collection = JsonConvert.DeserializeObject<IList<T>>(jsonStr);
            return collection == null ? new List<T>() : collection;
        }
        /// <summary>
        /// Serializes the object and saves to the file
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public async Task StoreAsync(IList<T> items)
        {
            var jsonStr = JsonConvert.SerializeObject(items);
            await File.WriteAllTextAsync(FilePath,jsonStr);
        }
    }
}

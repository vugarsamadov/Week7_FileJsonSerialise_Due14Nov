using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7_FileJsonSerialise_Due14Nov.Interfaces
{
    internal interface ICustomCollectionSource<T>
    {
        public Task StoreAsync(IList<T> items);
        public Task<IList<T>> FetchAsync();
    }
}

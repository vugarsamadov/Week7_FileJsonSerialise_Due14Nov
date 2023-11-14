using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7_FileJsonSerialise_Due14Nov.Interfaces
{
    internal interface ICustomCollectionFileBasedSource<T> : ICustomCollectionSource<T>
    {
        public string FilePath { get; init; }
    }
}

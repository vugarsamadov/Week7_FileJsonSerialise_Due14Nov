using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7_FileJsonSerialise_Due14Nov.Interfaces;

namespace Week7_FileJsonSerialise_Due14Nov
{
    internal abstract class CustomSourceCollection<T>
    {
        private IList<T> _items { get; set; }

        public ReadOnlyCollection<T> Items
        {
            get => _items.AsReadOnly();
        }

        public ICustomCollectionSource<T> Source { get; init; }


        public CustomSourceCollection(ICustomCollectionSource<T> source)
        {
            _items = new List<T>();
            Source = source;
        }

        public CustomSourceCollection(IList<T> items,ICustomCollectionSource<T> source)
        {
            _items = items;
            Source = source;
        }

        public async Task<T> GetAtAsync(int i)
        {
            await EnsureSyncWithSource();
            return _items[i];
        }
        public async Task SetAsync(int i, T t)
        {
            await EnsureSyncWithSource();
            _items[i] = t;
            await SaveChangesAsync();
        }

        /// <summary>
        /// Stores changes to source
        /// </summary>
        /// <returns></returns>
        public async Task SaveChangesAsync()
        {
            await Source.StoreAsync(_items);
        }

        /// <summary>
        /// Fetches the source and updates _items
        /// </summary>
        /// <returns></returns>
        public async Task EnsureSyncWithSource()
        {
            _items = await Source.FetchAsync();
        }

        /// <summary>
        /// Clears and updates Source
        /// </summary>
        /// <returns></returns>
        public async Task ClearAsync()
        {
            //await EnsureSyncWithSource();
            _items.Clear();
            await SaveChangesAsync();
        }

        /// <summary>
        /// Adds and updates Source
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task AddAsync(T item)
        {
            if (item == null) return;
            await EnsureSyncWithSource();
            _items.Add(item);
            await SaveChangesAsync();
        }

        public void AddRange(T[] items)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes element and updates Source
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(T item)
        {
            await EnsureSyncWithSource();
            var result = _items.Remove(item);

            if(result)
                await SaveChangesAsync();
            
            return result;
        }

        /// <summary>
        /// Finds the element that passes given predicate
        /// </summary>
        /// <param name="p"></param>
        /// <returns> Index of element that matches the predicate</returns>
        /// <exception cref="Exception">If more than one element passes predicate throws exception</exception>
        public async Task<int> MySingleOrDefaultAsync(Predicate<T> p)
        {
            await EnsureSyncWithSource();

            int indx = 0;
            bool found = false;
            for (int i = 0; i < Items.Count; i++)
            {
                if (p(_items[i]))
                {
                    if(found)
                        throw new Exception("Multiple items with ");
                    indx = i;
                }
            }
            return indx;
        }

        public async Task<IList<T>> FetchAndGetItemsAsync()
        {
            await EnsureSyncWithSource();
            return Items;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Collections_Generics
{
    public class GenericClass<T> : IGetItem<T>, ISetItem<T>, ISwapItems<T>
    {
        private readonly int _maxSize;
        private T[] _items;

        public GenericClass(T[] items)
        {
            this._maxSize = items.Length;
            this._items = items;
        }

        public T GetItem(int index)
        {
            if (index > _maxSize - 1)
                throw new InvalidOperationException("Index > maxSize - 1");

            if (index < 0)
                throw new InvalidOperationException("Index < 0");

            return _items[index];
        }

        public void SetItem(T item, int index)
        {
            if (index > _maxSize - 1)
                throw new InvalidOperationException("Index > maxSize - 1");

            if (index < 0)
                throw new InvalidOperationException("Index < 0");

            _items[index] = item;
        }

        public void SwapItems(int firstIndex, int secondIndex)
        {
            if (firstIndex > _maxSize - 1 || secondIndex > _maxSize - 1)
                throw new InvalidOperationException("firstIndex or secondIndex > maxSize - 1");

            if (firstIndex < 0 || secondIndex < 0)
                throw new InvalidOperationException("firstIndex < 0 || secondIndex < 0");

            T temp = _items[firstIndex];
            _items[firstIndex] = _items[secondIndex];
            _items[secondIndex] = temp;
        }

        public void SwapItems(T firstItem, T secondItem)
        {
            if (!_items.Contains(firstItem) || !_items.Contains(secondItem))
                throw new InvalidOperationException("Item not found");

            var indexItem1 = _items.Select((element, index) => new { element, index }).FirstOrDefault(x => x.element.Equals(firstItem));
            var indexItem2 = _items.Select((element, index) => new { element, index }).FirstOrDefault(x => x.element.Equals(secondItem));

            var temp = _items[indexItem1.index];
            _items[indexItem1.index] = _items[indexItem2.index];
            _items[indexItem2.index] = temp;
        }
    }
}

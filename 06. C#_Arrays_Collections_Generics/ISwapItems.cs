using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Collections_Generics
{
    public interface ISwapItems<T>
    {
        void SwapItems(int firstIndex, int secondIndex);
        void SwapItems(T firstItem, T secondItem);
    }
}

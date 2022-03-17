using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Collections_Generics
{
    public interface ISetItem<in T>
    {
        void SetItem(T item, int index);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Collections_Generics
{
    public class Arrays_Collections_Generics
    {
        static void Main(string[] args)
        {
            var genericClass = new GenericClass<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 });
            Console.WriteLine(genericClass.GetItem(2));

            genericClass.SetItem(3, 0);
            Console.WriteLine(genericClass.GetItem(0));

            genericClass.SwapItems(firstItem: 5, secondItem: 7);
            Console.WriteLine(genericClass.GetItem(7));
        }


        //Create a generic Collection class (using array []) having following operations
        //Get item at given index
        //Set item at given index
        //Swap two items(either by indexes or by items or both)

        //In the previously made real world object modelling application:
        //Add Nullable Properties/Fields
        //Add Enums
        //Add Collections and Dictionaries
        //Implement Generic Repository Pattern

    }
}

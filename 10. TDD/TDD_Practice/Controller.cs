using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Practice
{
    public class Controller
    {
        private List<Cat> catList;

        public Controller(List<Cat> initialCatList)
        {
            catList = initialCatList;
        }

        public Cat GetCatById(int catId)
        {
            try
            {
                var cat = catList[catId];
                return cat;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw;
            }
        }

        public void EditCat(int catId, Cat newCat)
        {
            try
            {
                if (newCat is null)
                    throw new ArgumentNullException(nameof(newCat));

                catList[catId] = newCat;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw;
            }
        }

        public void AddCat(Cat newCat)
        {
            if (newCat is null)
                throw new ArgumentNullException(nameof(newCat));

            catList.Add(newCat);
        }
    }
}

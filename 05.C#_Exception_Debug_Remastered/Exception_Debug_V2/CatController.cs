using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Debug_V2
{
    public class CatController
    {
        public Cat GetCatById(int catId)
        {
            // EF Core - SQL Server
            try
            {
                var cat = CatFromDB(catId);
                return cat;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Console.WriteLine("Request finished - closing");
            }
        }



        private Cat CatFromDB(int id)
        {
            Cat[] cats = new Cat[] { new Cat { PetName = "Ozzy", Age = 2, Gender = Gender.Male, Breed = Breed.British },
                                     new Cat { PetName = "Sushi", Age = 3, Gender = Gender.Male, Breed = Breed.British },
                                     new Cat { PetName = "Whiskey", Age = 4, Gender = Gender.Male, Breed = Breed.ScottishFold },
                                     new Cat { PetName = "Amun", Age = 1, Gender = Gender.Male, Breed = Breed.Sphynx }};

            return cats[id];
        }
    }
}

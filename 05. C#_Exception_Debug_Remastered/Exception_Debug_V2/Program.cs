using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Debug_V2
{
    public class Program
    {
        static void Main(string[] args)
        {

#if DEBUG
            Console.WriteLine("Debug mode is enabled!");
#endif
#if NET5_0_OR_GREATER
            Console.WriteLine("App running on NET5.0 OR GREATER!");
#endif

            Console.WriteLine("We will simulate a part of the PetLove application");
            Console.WriteLine("Enter an id of a cat you would like to see from DB:");

            int catId = 0;
            Cat catReceived;

            try
            {
                catId = int.Parse(Console.ReadLine());

                CatController catController = new CatController();
                try
                {
                    catReceived = catController.GetCatById(catId);
                    Console.WriteLine($"Greetings from {catReceived.PetName}! Age: {catReceived.Age}, Gender: {catReceived.Gender}, Breed: {catReceived.Breed}");
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter a valid id!");
            }

        }
    }
}

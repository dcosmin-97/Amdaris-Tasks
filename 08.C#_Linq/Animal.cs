using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public List<Animal> Animals { get; set; }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Email} {Country} {City} => has {Animals.Count} animals";
        }
    }

    public class Animal
    {
        public int AnimalId { get; set; }
        public string PetName { get; set; }
        public AnimalGender Gender { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"{AnimalId} {PetName} {Gender} {Age} belongs to user: {UserId}";
        }
    }

    public enum AnimalGender
    {
        male,
        female
    }

    public class Cat : Animal
    {
        public CatBreeds CatBreed { get; set; }
    }

    public enum CatBreeds
    {
        British,
        Bengal,
        Bombay,
        Sphynx
    }

    public class Dog : Animal
    {
        public DogBreeds DogBreed { get; set; }
    }

    public enum DogBreeds
    {
        Beagle,
        Bichon,
        Boxer,
        Bulldog
    }
}

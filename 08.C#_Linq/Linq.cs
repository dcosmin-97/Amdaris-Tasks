using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public static class Linq
    {
        public static void Main(string[] args)
        {
            Filtering();
        }


        private static void PrintCollection<T>(IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        public static void Filtering()
        {
            // Where (deffered execution)
            var higherStudents = _students.Where(student => student.Year > 2);
            var ownersRomania = _users.Where(user => user.Country == "Romania");
            var ownersMultiplePets = _users.Where(user => user.Animals.Count > 1);


            // Where with classic syntax
            var higherStudentsV2 = from students in _students
                                where students.Year > 2
                                select students;
            var ownersRomaniaV2 = from users in _users
                                where users.Country == "Romania"
                                select users;
            var ownersMultiplePetsV2 = from users in _users
                                       where users.Animals.Count > 1
                                       select users;


            // Skip 
            var allButFirstThree = _animals.Skip(8);


            // SkipWhile -> skip cu conditie
            // Important! -> Skip while va verifica pana conditia indeplinita este false, apoi nu mai verifica
            var result = _students.SkipWhile(student => student.Year == 3);
            var usersOutsideRomania = _users.SkipWhile(user => user.Country == "Romania");


            // Take

            //// TakeWhile

            //// Chunk
            //var chunkedResult = _students.Chunk(3);

            //// OfType
            //var homeStudents = _students.OfType<HomeStudent>();
        }































        private static readonly IEnumerable<User> _users = CreateUserList();
        private static IEnumerable<User> CreateUserList()
        {
            return new List<User>
            {
                new User { Id = 0, FirstName = "Jon", LastName = "Snow", Email = "jonsnow@gmail.com", Country = "Romania", City = "Bucharest",
                    Animals = new List<Animal> { new Cat() {AnimalId = 0, PetName = "Ozzy", Gender = AnimalGender.male, Age = 1, CatBreed = CatBreeds.British, UserId = 0 } }},

                new User { Id = 1, FirstName = "Mark", LastName = "Twain", Email = "marktwain@gmail.com", Country = "Romania", City = "Bucharest",
                    Animals = new List<Animal> { new Cat() {AnimalId = 1, PetName = "Gigi", Gender = AnimalGender.female, Age = 2, CatBreed = CatBreeds.British, UserId = 1 } }},

                new User { Id = 2, FirstName = "Cristiano", LastName = "Ronaldo", Email = "cristache@gmail.com", Country = "Bulgaria", City = "Sofia",
                    Animals = new List<Animal> { new Dog() {AnimalId = 2, PetName = "Jon", Gender = AnimalGender.male, Age = 3, DogBreed = DogBreeds.Beagle, UserId = 2 },
                                                 new Dog() {AnimalId = 3, PetName = "Jinny", Gender = AnimalGender.female, Age = 1, DogBreed = DogBreeds.Bulldog, UserId = 2 }} },

                new User { Id = 3, FirstName = "Steve", LastName = "Jobs", Email = "stevejobs@gmail.com", Country = "Germany", City = "Frankfurt",
                    Animals = new List<Animal> { new Cat() { AnimalId = 4, PetName = "Pufy", Gender = AnimalGender.female, Age = 1, CatBreed = CatBreeds.Sphynx, UserId = 3 },
                                                 new Cat() { AnimalId = 5, PetName = "Whisky", Gender = AnimalGender.female, Age = 2, CatBreed = CatBreeds.Bengal, UserId = 3}} },

                new User { Id = 4, FirstName = "Adam", LastName = "Einstein", Email = "adameinstein@gmail.com", Country = "Romania", City = "Targoviste",
                    Animals = new List<Animal> { new Dog() {AnimalId = 6, PetName = "Buffy", Gender = AnimalGender.male, Age = 5, DogBreed = DogBreeds.Bichon, UserId = 4 } }},

                new User { Id = 5, FirstName = "Maia", LastName = "Sandu", Email = "maiasandu@gmail.com", Country = "Romania", City = "Sinaia",
                    Animals = new List<Animal> { new Dog() {AnimalId = 7, PetName = "Zoe", Gender = AnimalGender.female, Age = 4, DogBreed = DogBreeds.Boxer, UserId = 5 } }},

                new User { Id = 6, FirstName = "Adam", LastName = "Gontier", Email = "adamgontier@gmail.com", Country = "Romania", City = "Timisoara",
                    Animals = new List<Animal> { new Dog() {AnimalId = 8, PetName = "Zoey", Gender = AnimalGender.female, Age = 3, DogBreed = DogBreeds.Bulldog, UserId = 6 },
                                                 new Dog() {AnimalId = 9, PetName = "King", Gender = AnimalGender.female, Age = 1, DogBreed = DogBreeds.Bulldog, UserId = 6 }}},

                new User { Id = 7, FirstName = "Bill", LastName = "Gates", Email = "billgates@gmail.com", Country = "Romania", City = "Targoviste",
                    Animals = new List<Animal> { new Cat() {AnimalId = 10, PetName = "Muri", Gender = AnimalGender.male, Age = 10, CatBreed = CatBreeds.Bombay, UserId = 7 } }},

                new User { Id = 8, FirstName = "Winston", LastName = "Churchill", Email = "winstonchurchill@gmail.com", Country = "Romania", City = "Pucioasa",
                    Animals = new List<Animal> { new Cat() {AnimalId = 11, PetName = "Mari", Gender = AnimalGender.female, Age = 12, CatBreed = CatBreeds.Sphynx, UserId = 8 } }},

                new User { Id = 9, FirstName = "Frozen", LastName = "Elsa", Email = "frozenelsa99@gmail.com", Country = "Romania", City = "Targoviste",
                    Animals = new List<Animal> { new Cat() {AnimalId = 12, PetName = "Mury", Gender = AnimalGender.male, Age = 10, CatBreed = CatBreeds.Bombay, UserId = 9 } }},

                new User { Id = 10, FirstName = "Billy", LastName = "Man", Email = "billyman@gmail.com", Country = "Romania", City = "Bucharest",
                    Animals = new List<Animal> { new Dog() {AnimalId = 13, PetName = "Zoro", Gender = AnimalGender.female, Age = 15, DogBreed = DogBreeds.Boxer, UserId = 10 } }},
            };
        }

        private static readonly IEnumerable<Animal> _animals = CreateAnimalsList();
        private static IEnumerable<Animal> CreateAnimalsList()
        {
            return new List<Animal>
            {
                new Cat() {AnimalId = 0, PetName = "Ozzy", Gender = AnimalGender.male, Age = 1, CatBreed = CatBreeds.British, UserId = 0 },
                new Cat() {AnimalId = 1, PetName = "Gigi", Gender = AnimalGender.female, Age = 2, CatBreed = CatBreeds.British, UserId = 1 },
                new Dog() {AnimalId = 2, PetName = "Jon", Gender = AnimalGender.male, Age = 3, DogBreed = DogBreeds.Beagle, UserId = 2 },
                new Dog() {AnimalId = 3, PetName = "Jinny", Gender = AnimalGender.female, Age = 1, DogBreed = DogBreeds.Bulldog, UserId = 2 },
                new Cat() { AnimalId = 4, PetName = "Pufy", Gender = AnimalGender.female, Age = 1, CatBreed = CatBreeds.Sphynx, UserId = 3 },
                new Cat() { AnimalId = 5, PetName = "Whisky", Gender = AnimalGender.female, Age = 2, CatBreed = CatBreeds.Bengal, UserId = 3},
                new Dog() {AnimalId = 6, PetName = "Buffy", Gender = AnimalGender.male, Age = 5, DogBreed = DogBreeds.Bichon, UserId = 4 },
                new Dog() {AnimalId = 7, PetName = "Zoe", Gender = AnimalGender.female, Age = 4, DogBreed = DogBreeds.Boxer, UserId = 5 },
                new Dog() {AnimalId = 8, PetName = "Zoey", Gender = AnimalGender.female, Age = 3, DogBreed = DogBreeds.Bulldog, UserId = 6 },
                new Dog() {AnimalId = 9, PetName = "King", Gender = AnimalGender.female, Age = 1, DogBreed = DogBreeds.Bulldog, UserId = 6 },
                new Cat() {AnimalId = 10, PetName = "Muri", Gender = AnimalGender.male, Age = 10, CatBreed = CatBreeds.Bombay, UserId = 7 },
                new Cat() {AnimalId = 11, PetName = "Mari", Gender = AnimalGender.female, Age = 12, CatBreed = CatBreeds.Sphynx, UserId = 8 },
                new Cat() {AnimalId = 12, PetName = "Mury", Gender = AnimalGender.male, Age = 10, CatBreed = CatBreeds.Bombay, UserId = 9 },
                new Dog() {AnimalId = 13, PetName = "Zoro", Gender = AnimalGender.female, Age = 15, DogBreed = DogBreeds.Boxer, UserId = 10 }
            };
        }


        private static readonly IEnumerable<Student> _students = CreateStudentsList();
        private static IEnumerable<Student> CreateStudentsList()
        {
            return new List<Student>
            {
                new Student { FirstName = "Jon", LastName = "Snow", Year = 2, HasAPartTimeJob = false, Age = 20, FacultyId = "1"},
                new Student { FirstName = "Mark", LastName = "Twain", Year = 2, HasAPartTimeJob = false , Age = 21, FacultyId = "1"},
                new Student { FirstName = "Cristiano", LastName = "Ronaldo", Year = 3, HasAPartTimeJob = false, Age = 21 , FacultyId = "4"},
                new Student { FirstName = "Steve", LastName = "Jobs", Year = 4, HasAPartTimeJob = true, Age = 18, FacultyId = "3" },
                new Student { FirstName = "Adam", LastName = "Einstein", Year = 2, HasAPartTimeJob = true, Age = 19, FacultyId = "3"},
                new Student { FirstName = "Maia", LastName = "Sandu", Year = 2, HasAPartTimeJob = true , Age = 24, FacultyId = "2"},
                new HomeStudent { FirstName = "Adam", LastName = "Gontier", Year = 3, HasAPartTimeJob = false, Address = "Selimbar, Sibiu, Ana Aslan 11", Age = 29, FacultyId = "1"},
                new HomeStudent { FirstName = "Bill", LastName = "Gates", Year = 3, HasAPartTimeJob = false, Address = "Timisoara, Strada Victoria", Age = 19, FacultyId = "5"},
                new Student { FirstName = "Winston", LastName = "Churchill", Year = 1, HasAPartTimeJob = true, Age = 30 , FacultyId = "4"},
                new Student { FirstName = "Matei", LastName = "Basarab", Year = 1, HasAPartTimeJob = false , Age = 22, FacultyId = "5"},
                new Student { FirstName = "Radu", LastName = "Stati", Year = 2, HasAPartTimeJob = true , Age = 25, FacultyId = "2"},
            };
        }

        private static readonly IEnumerable<Faculty> _faculties = CreateFacultiesList();
        private static IEnumerable<Faculty> CreateFacultiesList()
        {
            return new List<Faculty>
            {
                new Faculty { Name = "IT", Id = "1", HeadMaster = "Mike Tyson",
                    Students = new List<Student> { new Student() { FirstName = "s1" }, new Student { FirstName = "s2"} } },
                new Faculty { Name = "Marketing", Id = "2", HeadMaster = "Jonas Renkse",
                    Students = new List<Student> { new Student() { FirstName = "s3" }, new Student { FirstName = "s4"} } },
                new Faculty { Name = "Economy", Id = "3", HeadMaster = "Mark Zukerberg",
                    Students = new List<Student> { new Student() { FirstName = "s5" }, new Student { FirstName = "s6"} }},
                new Faculty { Name = "Math", Id = "4", HeadMaster = "Alfred Nobel" },
                new Faculty { Name = "Agriculture", Id = "5", HeadMaster = "Ned Stark" },
            };
        }
    }

    
}

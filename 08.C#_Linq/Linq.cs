using Linq.Extensions;
using System;
using System.Collections;
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
            //Joins();

            string petName = "Ozzy";
            if (petName.IsNameGood())
                Console.WriteLine("Name updated!");

            int[] testArray = { 1, 2, 3, 4 };
            Func<int, bool> predicate = number => number >= 3;
            var result = testArray.ArrayFilter<int>(predicate);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


            List<string> testList = new List<string>() { "Ozzy", "Mery", "gigel", "trump", "Mog", "OnlyName" };
            Func<string, bool> predicate1 = name => name.Length >= 4;
            Func<string, bool> predicate2 = name => char.IsUpper(name[0]);
            var result2 = testList.ListFilter<string>(predicate1, predicate2);

            var result3 = testList.ListFilter2((name, count) => name.Length >= count);
            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }
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


            // Skip -> afiseaza restul
            // Opusul lui Take
            var allButFirstThree = _animals.Skip(8);


            // SkipWhile -> skip cu conditie
            // Important! -> Skip while va verifica pana conditia indeplinita este false, apoi nu mai verifica
            var result = _students.SkipWhile(student => student.Year == 3);
            var usersOutsideRomania = _users.SkipWhile(user => user.Country == "Romania");


            // Take
            // used to fetch the first “n” number of elements from the data source
            var first3animals = _animals.Take(3);


            // TakeWhile
            // Diferenta intre TakeWhile si Where in Linq? 
            // Where - aplica conditia pe toata lista de elemente, in timp ce takeWhile se opreste la primul bool = false;
            var usersOutsideRomaniaV2 = _users.TakeWhile(user => user.Country == "Romania");


            // Chunk
            // Definitie - imparte datasetul in parti egale de cate N elemente
            // Returneaza subseturi de cate N elemente 
            var chunkedResult = _users.Chunk(3);
            foreach (var subset in chunkedResult)
            {
                //PrintCollection(subset);
            }


            // OfType
            // Returneaza doar elementele care contin tipul de date specificat
            var dogsFromAnimals = _animals.OfType<Dog>();
        }

        public static void Ordering()
        {
            // OrderBy, ThenBy
            // ordoneaza crescator, apoi criterii secundare
            var orderedByYear = _students.OrderBy(x => x.Year).ThenBy(x => x.FirstName).ThenBy(x => x.LastName);
            var usersOrderedByNoOfAnimals = _users.OrderBy(x => x.Animals.Count).ThenBy(x => x.Email);


            // OrderByDescending, ThenByDescending
            var orderedByYearV2 = _students.OrderByDescending(x => x.Year).ThenBy(x => x.FirstName).ThenBy(x => x.LastName);
            var usersOrderedByNoOfAnimalsV2 = _users.OrderByDescending(x => x.Animals.Count).ThenByDescending(x => x.Email);


            // OrderByDescending, ThenByDescending -> old
            var usersOrderedByNoOfAnimalsV3 = from users in _users
                                              orderby users.Animals.Count() descending
                                              select users;


            // Reverse
            var reverseUsers = _users.Reverse();
        }

        public static void Quantifiers()
        {
            // Any
            // It will always return a bool
            bool anyUser = _users.Any(x => x.Country == "Romania");

            // All
            // It will always return a bool
            bool allUsers = _users.All(x => x.Animals.Count > 0);

            // Contains
            // It will always return a bool
            var dog13 = new Dog() { AnimalId = 13, PetName = "Zoro", Gender = AnimalGender.female, Age = 15, DogBreed = DogBreeds.Boxer, UserId = 10 };
            bool containsDog = _animals.Contains(dog13);

            // SequenceEqual
            // It will always return a bool
            bool sequenceEqual = _users.SequenceEqual(_usersForSequence); // it is true
        }

        public static void Projection()
        {
            // Select (anonymus types)
            // returns only a specific type
            // putem returna o lista care contine doar firstName si sa aplicam anumite conditii
            var firstNames = _users.Where(x => x.Animals.Count > 1).Select(x => x.FirstName);
            var emails = _users.Select(x => x.Email);


            // SelectMany
            // putem returna lista din interiorul unui item
            // putem returna toate animalele de la toti userii
            // in interiorul clasei User, avem o lista de animale
            var allStudents = _faculties.SelectMany(x => x.Students);
            var allAnimals = _users.SelectMany(x => x.Animals);
           
            PrintCollection(allAnimals);
        }

        public static void Grouping()
        {
            // GroupBy
            // putem grupa in key value pair dupa un criteriu
            var groupedAnimalsByGender = _animals.GroupBy(x => x.Gender);

            // se va face un key pentru fiecare criteriu din Gender
            foreach (var gender in groupedAnimalsByGender)
            {
                Console.WriteLine(gender.Key);
                foreach (var animal in gender)
                {
                    Console.WriteLine(animal);
                }
            }

            // group cats by breed
            var groupedCatsByBreed = _animals.OfType<Cat>().GroupBy(x => x.CatBreed);

            // se va face un key pentru fiecare criteriu din Gender
            foreach (var breed in groupedCatsByBreed)
            {
                Console.WriteLine(breed.Key);
                foreach (var animal in breed)
                {
                    Console.WriteLine(animal);
                }
            }
        }

        public static void Generation()
        {
            // DefaultIfEmpty
            // Daca nu gaseste elemente, putem predefini un default value
            var defaultUser = new User
            {
                Id = 0,
                FirstName = "Jon",
                LastName = "Snow",
                Email = "jonsnow@gmail.com",
                Country = "Romania",
                City = "Bucharest",
                Animals = new List<Animal> { new Cat() { AnimalId = 0, PetName = "Ozzy", Gender = AnimalGender.male, Age = 1, CatBreed = CatBreeds.British, UserId = 0 } }
            };
            var multipleAnimalUsers = _users.Where(x => x.Animals.Count > 2).DefaultIfEmpty(defaultUser);

            // Empty
            var emptyUser = Enumerable.Empty<User>();

            // Range
            // Generate a sequence of integers from 1 to 10
            // and then select their squares.
            IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);

            // Repeat
            var repeat = Enumerable.Repeat(defaultUser, 10).ToList();

            PrintCollection(repeat);
        }

        public static void ElementOperators()
        {
            // First, FirstOrDefault
            // returns first element and we can also add a condition
            // if no element is found, a default value will be returned
            var first = _users.First(x => x.City == "Pucioasa");
            var firstDefault = _users.FirstOrDefault(x => x.City == "Branesti");

            // Last, LastOrDefault
            var last = _users.Last(x => x.City == "Targoviste");
            var lastDefault = _users.LastOrDefault(x => x.City == "Branesti");

            // Single, SingleOrDefault
            // daca exista mai multe cu ac conditie, va returna eroare
            //var single = _users.Single(x => x.City == "Targoviste"); // error
            var single = _users.Single(x => x.Id == 0);
            var singleDefault = _users.SingleOrDefault(x => x.Id == 20);

            // ElementAt, ElementAtOrDefault
            // dupa index
            var elementAt = _users.ElementAt(10);
            var elementAtDefault = _users.ElementAtOrDefault(20);

            Console.WriteLine(elementAtDefault);
        }

        public static void DataConversion()
        {
            // Cast (throws InvalidCastException if unable to cast an item in the collection)
            ArrayList list = new ArrayList
            {
                10,
                20,
                30
            };
            IEnumerable<int> result = list.Cast<int>();

            // ToDictionary (simply by a key or with element selector)
            Dictionary<int, User> _dict = _users.ToDictionary(x => x.Id);

            foreach (KeyValuePair<int, User> kvp in _dict)
            {
                Console.WriteLine($"Key: {kvp.Key} and value: {kvp.Value.ToString()}");
            }

            // ToLookup
            // Seamana cu Group by, doar ca exista o diferenta
            // Group by - deferred execution
            // ToLookup - immediate execution
            var lookup = _animals.ToLookup(x => x.Gender);
            foreach (var gender in lookup)
            {
                Console.WriteLine(gender.Key);
                foreach (var animal in gender)
                {
                    Console.WriteLine(animal);
                }
            }
        }

        public static void Aggregation()
        {
            // Aggregate
            // together the values of multiple rows as the input
            // return a single value
            var allNames = _students.Aggregate("", (previewsResult, student) => previewsResult + student.FirstName, allNames => allNames);
            var allEmails = _animals.Aggregate("", (finalOutput, animal) => finalOutput + animal.PetName, allNames => allNames);

            // Average
            // average age
            var averageAge = _animals.Average(x => x.Age);
            // average animals count
            var averageAnimalsCount = _users.Average(x => x.Animals.Count);

            // Count, LongCount
            var count = _animals.Count(x => x.Age > 1);
            var longCount = _users.LongCount(x => x.Country == "Romania");

            // Max, MaxBy
            // return the maximum value
            var maxAnimalId = _animals.Max(x => x.AnimalId);
            // return the IEnumerable type that contains the max value
            var maxAnimalIdBy = _animals.MaxBy(x => x.AnimalId);

            // Min, MinBy
            // return the minimum value
            var minAge = _animals.Min(x => x.Age);
            // return the IEnumerable type that contains the min value
            var minAgeBy = _animals.MinBy(x => x.Age);

            // Sum
            // numara totalul de animale pe care il detin toti userii
            var sum = _users.Sum(x => x.Animals.Count);
            // suma id-urilor
            var sum2 = _users.Sum(x => x.Id);
            // suma varstelor 
            var sum3 = _animals.Sum(x => x.Age);

            Console.WriteLine(averageAnimalsCount);
        }

        public static void SetOperations()
        {
            // Distinct, DistinctBy
            // returneaza elementele unice
            var distinct = _animals.Distinct();
            // unice dupa un criteriu ( default returneaza primele elemente distince in ordine )
            var distinctBy = _users.DistinctBy(x => x.Animals.Count);

            // Except, ExeceptBy
            // except - elementele care sunt in primul, dar nu sunt in al 2-lea
            var except = _users.Select(x => x.FirstName).Except(_usersDistinct.Select(x => x.FirstName));
            // except dupa id
            var exceptBy = _users.ExceptBy(_usersDistinct.Select(x => x.Id), x => x.Id);

            // Intersect, IntersectBy
            // elemente comune
            var intersect = _users.Select(x => x.FirstName).Intersect(_usersDistinct.Select(x => x.FirstName));
            // intersectare dupa id
            var intersectBy = _users.IntersectBy(_usersDistinct.Select(x => x.Id), x => x.Id);

            // Union, UnionBy (distinct union)
            // se adauga in continuarea primului element
            // la union, duplicatele se elimina
            // Union operator is also used to concatenate two sequences into one sequence by removing the duplicate elements.
            var union = _users.Union(_usersDistinct);
            var unionBy = _users.UnionBy(_usersDistinct, x => x.Id);

            // Union By -> simple example
            //Planet[] firstFivePlanetsFromTheSun =
            //{
            //    Planet.Mercury,
            //    Planet.Venus,
            //    Planet.Earth,
            //    Planet.Mars,
            //    Planet.Jupiter
            //};

            //Planet[] lastFivePlanetsFromTheSun =
            //{
            //    Planet.Mars,
            //    Planet.Jupiter,
            //    Planet.Saturn,
            //    Planet.Uranus,
            //    Planet.Neptune
            //};

            //      foreach (Planet planet in
            //      firstFivePlanetsFromTheSun.UnionBy(
            //      lastFivePlanetsFromTheSun, planet => planet))
            //      {
            //          Console.WriteLine(planet);
            //      }

            //     This code produces the following output:
            //     Planet { Name = Mercury, Type = Rock, OrderFromSun = 1 }
            //     Planet { Name = Venus, Type = Rock, OrderFromSun = 2 }
            //     Planet { Name = Earth, Type = Rock, OrderFromSun = 3 }
            //     Planet { Name = Mars, Type = Rock, OrderFromSun = 4 }
            //     Planet { Name = Jupiter, Type = Gas, OrderFromSun = 5 }
            //     Planet { Name = Saturn, Type = Gas, OrderFromSun = 6 }
            //     Planet { Name = Uranus, Type = Liquid, OrderFromSun = 7 }
            //     Planet { Name = Neptune, Type = Liquid, OrderFromSun = 8 }


            // Intersect By -> elemente comune
            //        foreach (Planet planet in
            //                 firstFivePlanetsFromTheSun.IntersectBy(
            //                 lastFivePlanetsFromTheSun, planet => planet))
            //        {
            //            Console.WriteLine(planet);
            //        }

            // This code produces the following output:
            //     Planet { Name = Mars, Type = Rock, OrderFromSun = 4 }
            //     Planet { Name = Jupiter, Type = Gas, OrderFromSun = 5 }



            // Concat (non distinct)
            // duplicatele raman
            var all = _users.Concat(_usersDistinct);

            PrintCollection(union);
        }

        public static void Joins()
        {
            // denumirea facultatii pt fiecare student
            // am unit student cu faculty id, am intors numele facultatii
            var facultyNameByStudent = _students.Join(
                _faculties,
                student => student.FacultyId,
                faculty => faculty.Id,
                (student, faculty) => new {student.FirstName, faculty.Name});
            // putem intoarce un tip anonim

            var facultiesByStudent = from student in _students
                                     join faculty in _faculties on student.FacultyId equals faculty.Id
                                     select new { student.FirstName, faculty.Name };


            // headmaster fiecare student
            var facultyHeadMasterByStudent = _students.Join(
                _faculties,
                student => student.FacultyId,
                faculty => faculty.Id,
                (student, faculty) => faculty.HeadMaster);

            // tara din care se afla stapanul fiecarui animal
            var countryPerAnimal = _animals.Join(
                _users,
                animal => animal.UserId,
                user => user.Id,
                (animal, user) => user.Country);

            // tara din care se afla stapanul fiecarui animal de sex feminin cu varsta > 1
            var countryPerAnimalFemales = from animal in _animals
                                          join user in _users on animal.UserId equals user.Id
                                          where animal.Gender == AnimalGender.female && animal.Age > 1
                                          select new { animal.PetName, animal.Age, user.Country };


            // group by 
            // studentii se grupeaza dupa numele facultatii
            var studentsByFaculty = from faculty in _faculties
                                    join student in _students on faculty.Id equals student.FacultyId into studentsGroup
                                    select new { faculty.Name, studentsGroup };

            //foreach (var studentGroup in studentsByFaculty)
            //{
            //    Console.WriteLine(studentGroup.Name);
            //    foreach (var student in studentGroup.studentsGroup)
            //    {
            //        Console.WriteLine(student);
            //    }

            //}


            // sa grupam animalele dupa tara stapanului din care face parte
            var groupAnimalsByUserCountry = from user in _users
                                            join animals in _animals on user.Id equals animals.UserId into animalsByCountry
                                            select new { user.Country, animalsByCountry };

            //foreach (var animalsByCountry in groupAnimalsByUserCountry)
            //{
            //    Console.WriteLine(animalsByCountry.Country);
            //    foreach (var item in animalsByCountry.animalsByCountry)
            //    {
            //        Console.WriteLine(item);
            //    }

            //}

            // sa se gaseasca toti userii dintr-o tara specifica care au typeOf specificat de animal si care au gender diferit de gender specificat
            // optional acelasi breed
            var possibleMatches = _users.Where(user => user.Country == "Romania")
                .SelectMany(x => x.Animals)
                .OfType<Cat>()
                .Where(x => x.Gender != AnimalGender.female);



            var zipTest = _users.Zip(_animals, (first, second) => first + " -------- " + second);

            PrintCollection(zipTest);
        }



















        private static readonly IEnumerable<User> _users = CreateUserList(0, 11);
        private static readonly IEnumerable<User> _usersDistinct = CreateUserList(2, 3);
        private static readonly IEnumerable<User> _usersForSequence = _users.Where(x => x.Animals.Count > 0);
        private static IEnumerable<User> CreateUserList(int index, int count)
        {
            var Users =  new List<User>
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

                new User { Id = 6, FirstName = "Znn", LastName = "Gontier", Email = "adamgontier@gmail.com", Country = "Romania", City = "Timisoara",
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

            return Users.GetRange(index, count);
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

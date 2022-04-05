using System;
using System.Collections.Generic;
using Xunit;

namespace TDD_Practice.XUnit
{
    public class ControllerTestXUnit
    {
        private List<Cat> initialCats = new List<Cat>() {new Cat { PetName = "Ozzy", Age = 2, Gender = Gender.Male, Breed = Breed.British },
                                                     new Cat { PetName = "Sushi", Age = 3, Gender = Gender.Male, Breed = Breed.British },
                                                     new Cat { PetName = "Whiskey", Age = 4, Gender = Gender.Male, Breed = Breed.ScottishFold },
                                                     new Cat { PetName = "Amun", Age = 1, Gender = Gender.Male, Breed = Breed.Sphynx } };

        [Fact]
        public void GetCatById_IdValid_ReturnsCat()
        {
            // Arrange -> set up everything to be ready
            var controller = new Controller(initialCats);

            // Act
            var returnedCat = controller.GetCatById(0);

            // Assert
            Assert.NotNull(returnedCat);
            Assert.Equal(returnedCat.PetName, initialCats[0].PetName);
            Assert.Equal(returnedCat.Age, initialCats[0].Age);
            Assert.Equal(returnedCat.Gender, initialCats[0].Gender);
            Assert.Equal(returnedCat.Breed, initialCats[0].Breed);
        }

        [Fact]
        public void GetCatById_IdOutOfRange_ThrowException()
        {
            // Arrange -> set up everything to be ready
            var controller = new Controller(initialCats);

            // Assert + ACT
            Assert.Throws<ArgumentOutOfRangeException>(() => controller.GetCatById(4));
        }

        [Fact]
        public void AddCat_CatNotNull_CatAddedToList()
        {
            // Arrange -> set up everything to be ready
            var controller = new Controller(initialCats);
            var newCat = new Cat { PetName = "NewCat", Age = 3, Gender = Gender.Male, Breed = Breed.British };

            // Act
            controller.AddCat(newCat);

            // Assert
            Assert.NotNull(initialCats[4]);
            Assert.Equal(newCat.PetName, initialCats[4].PetName);
            Assert.Equal(newCat.Age, initialCats[4].Age);
            Assert.Equal(newCat.Gender, initialCats[4].Gender);
            Assert.Equal(newCat.Breed, initialCats[4].Breed);
        }
    }
}
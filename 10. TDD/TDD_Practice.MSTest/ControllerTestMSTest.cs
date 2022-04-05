using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TDD_Practice.MSTest
{
    [TestClass]
    public class ControllerTestMSTest
    {
        private List<Cat> initialCats = new List<Cat>() {new Cat { PetName = "Ozzy", Age = 2, Gender = Gender.Male, Breed = Breed.British },
                                                     new Cat { PetName = "Sushi", Age = 3, Gender = Gender.Male, Breed = Breed.British },
                                                     new Cat { PetName = "Whiskey", Age = 4, Gender = Gender.Male, Breed = Breed.ScottishFold },
                                                     new Cat { PetName = "Amun", Age = 1, Gender = Gender.Male, Breed = Breed.Sphynx } };

        [TestMethod]
        public void AddCat_CatNull_ThrowsException()
        {
            // Arrange -> set up everything to be ready
            var controller = new Controller(initialCats);

            // Assert + ACT
            Assert.ThrowsException<ArgumentNullException>(() => controller.AddCat(null));
        }

        [TestMethod]
        public void EditCat_IdValid_CatNull_ThrowsException()
        {
            // Arrange -> set up everything to be ready
            var controller = new Controller(initialCats);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => controller.EditCat(0,null));
        }

        [TestMethod]
        public void EditCat_IdNotValid_CatValid_ThrowsException()
        {
            // Arrange -> set up everything to be ready
            var controller = new Controller(initialCats);
            var newCat = new Cat { PetName = "NewCat", Age = 3, Gender = Gender.Male, Breed = Breed.British };

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => controller.EditCat(999, newCat));
        }

        [TestMethod]
        public void EditCat_IdValid_CatValid_CatEditedInList()
        {
            // Arrange -> set up everything to be ready
            var controller = new Controller(initialCats);
            var newCat = new Cat { PetName = "NewCat", Age = 3, Gender = Gender.Male, Breed = Breed.British };

            // Act
            controller.EditCat(0, newCat);

            // Assert
            Assert.IsNotNull(initialCats[0]);
            Assert.AreEqual(newCat.PetName, initialCats[0].PetName);
            Assert.AreEqual(newCat.Age, initialCats[0].Age);
            Assert.AreEqual(newCat.Gender, initialCats[0].Gender);
            Assert.AreEqual(newCat.Breed, initialCats[0].Breed);
        }
    }
}
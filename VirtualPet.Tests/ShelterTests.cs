using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace VirtualPet.Tests
{
    public class ShelterTests
    {
        Shelter testShelter;
        public ShelterTests()
        {
            testShelter = new Shelter();
        }

        [Fact]
        public void GetPetCount_Should_Return_Pet_Count()
        {
            int testCount = testShelter.GetPetCount();

            Assert.Equal(testCount, testShelter.petList.Count);
        }

        [Fact]
        public void AddPet_Should_Increase_Pet_Count_By_One()
        {
            Pet testPet = new Pet();
            testShelter.AddPet(testPet);

            Assert.Equal(1, testShelter.GetPetCount());
        }

        [Fact]
        public void RemovePet_Should_Decrease_Pet_Count_By_One()
        {
            // Arrange
            Pet testPet = new Pet();
            testShelter.AddPet(testPet);

            // Act
            testShelter.RemovePet(testPet);

            // Assert
            Assert.Equal(0, testShelter.GetPetCount());
        }

    }
}

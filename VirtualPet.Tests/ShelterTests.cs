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
            Assert.Equal(4, petList.Count);
        }

        [Fact]
        public void AddPet_Should_Increase_Pet_Count_By_One()
        {
            Pet myPet = new Pet();
            testShelter.AddPet(myPet);
            int petCount = testShelter.getPetCount();
            
            Assert.Equal(1 , petCount);
        }


    }
}

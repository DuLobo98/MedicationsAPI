using MedicationsAPI.Controllers;
using MedicationsAPI.Models;
using MedicationsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MedicationsAPI.Tests
{
    public class MedicationsControllerTests
    {
        private readonly Mock<IMedicationService> _service = new();

        [Fact]
        public async Task GetAllMedicationsAsync_WithExistingMedications_ReturnsExpectedMedications()
        {
            //Arrange
            var expectedMedications = new List<Medication>{
                new Medication(name: "Medication 1",quantity: 50),
                new Medication(name: "Medication 2",quantity: 100),
                new Medication(name: "Medication 3",quantity: 23)
            };

            _service.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(expectedMedications);

            var controller = new MedicationsController(_service.Object);

            //Act
            var actualMedications = await controller.GetAllMedicationsAsync() as OkObjectResult;

            //Assert
            var medications = Assert.IsType<List<Medication>>(actualMedications.Value);
            Assert.Equal(expectedMedications, medications);
        }        
    }
}
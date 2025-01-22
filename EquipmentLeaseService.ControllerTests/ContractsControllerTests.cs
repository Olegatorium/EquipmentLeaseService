using AutoFixture;
using EquipmentLeaseService.API.Controllers;
using EquipmentLeaseService.Core.DTO.Contract;
using EquipmentLeaseService.Core.Enums;
using EquipmentLeaseService.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EquipmentLeaseService.ControllerTests
{
    public class ContractsControllerTests
    {
        private readonly Mock<IContractService> _mockContractService;
        private readonly ContractsController _controller;
        private readonly Fixture _fixture;

        public ContractsControllerTests()
        {
            _mockContractService = new Mock<IContractService>();
            _controller = new ContractsController(_mockContractService.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task CreateContract_ReturnsCreated_WhenSuccess()
        {
            // Arrange
            var request = _fixture.Create<ContractAddRequestDto>();
            var response = new ContractResponseDto { ContractId = Guid.NewGuid() };
            var serviceResult = new CreateContractResultDto
            {
                Status = CreateContractResultStatus.Success,
                Contract = response
            };

            _mockContractService.Setup(s => s.CreateContractWithValidation(request))
                .ReturnsAsync(serviceResult);

            // Act
            var result = await _controller.CreateContract(request);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(ContractsController.GetContract), actionResult.ActionName);
            Assert.Equal(response, actionResult.Value);
        }

        [Fact]
        public async Task CreateContract_ReturnsBadRequest_WhenInvalidRequest()
        {
            // Arrange
            var request = new ContractAddRequestDto();
            var serviceResult = new CreateContractResultDto
            {
                Status = CreateContractResultStatus.InvalidRequest,
                ErrorMessage = "Invalid request"
            };

            _mockContractService.Setup(s => s.CreateContractWithValidation(request))
                .ReturnsAsync(serviceResult);

            // Act
            var result = await _controller.CreateContract(request);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Invalid request", actionResult.Value);
        }

        [Fact]
        public async Task CreateContract_EquipmentTypeNotFound_ReturnsNotFound()
        {
            // Arrange
            var contractRequest = _fixture.Build<ContractAddRequestDto>()
                              .With(x => x.ProcessEquipmentTypeCode, Guid.Empty) 
                              .Create();

            var serviceResult = new CreateContractResultDto
            {
                Status = CreateContractResultStatus.EquipmentTypeNotFound,
                ErrorMessage = "Equipment type not found."
            };

            _mockContractService
                .Setup(service => service.CreateContractWithValidation(contractRequest))
                .ReturnsAsync(serviceResult);

            // Act
            var result = await _controller.CreateContract(contractRequest);

            // Assert
            var actionResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("Equipment type not found.", actionResult.Value);
        }

        [Fact]
        public async Task CreateContract_ProductionFacilityNotFound_ReturnsNotFound()
        {
            // Arrange
            var contractRequest = _fixture.Build<ContractAddRequestDto>()
                                          .With(x => x.ProductionFacilityCode, Guid.Empty) 
                                          .Create();
            var serviceResult = new CreateContractResultDto
            {
                Status = CreateContractResultStatus.ProductionFacilityNotFound,
                ErrorMessage = "Production facility not found."
            };

            _mockContractService
                .Setup(service => service.CreateContractWithValidation(contractRequest))
                .ReturnsAsync(serviceResult);

            // Act
            var result = await _controller.CreateContract(contractRequest);

            // Assert
            var actionResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("Production facility not found.", actionResult.Value);

            _mockContractService.Verify(service => service.CreateContractWithValidation(contractRequest), Times.Once);
        }

        [Fact]
        public async Task GetContract_ReturnsOk_WhenContractExists()
        {
            // Arrange
            var contractId = Guid.NewGuid();
            var response = new ContractResponseDto { ContractId = contractId };

            _mockContractService.Setup(s => s.GetContract(contractId))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.GetContract(contractId);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(response, actionResult.Value);
        }

        [Fact]
        public async Task GetContract_ReturnsNotFound_WhenContractDoesNotExist()
        {
            // Arrange
            var contractId = Guid.NewGuid();

            _mockContractService.Setup(s => s.GetContract(contractId))
                .ReturnsAsync((ContractResponseDto)null);

            // Act
            var result = await _controller.GetContract(contractId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetAllContracts_ReturnsOk_WhenContractsExist()
        {
            // Arrange
            var response = new List<ContractResponseDto>
            {
                new ContractResponseDto { ContractId = Guid.NewGuid() },
                new ContractResponseDto { ContractId = Guid.NewGuid() }
            };

            _mockContractService.Setup(s => s.GetAllContracts())
                .ReturnsAsync(response);

            // Act
            var result = await _controller.GetAllContracts();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(response, actionResult.Value);
        }

        [Fact]
        public async Task GetAllContracts_ReturnsNotFound_WhenNoContractsExist()
        {
            // Arrange
            _mockContractService.Setup(s => s.GetAllContracts())
                .ReturnsAsync(new List<ContractResponseDto>());

            // Act
            var result = await _controller.GetAllContracts();

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}

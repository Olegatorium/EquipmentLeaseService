using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EquipmentLeaseService.API.Controllers;
using EquipmentLeaseService.Core.DTO.ContractUpdateRequest;
using EquipmentLeaseService.Core.Enums;
using EquipmentLeaseService.Core.ServiceContracts;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using AutoFixture;

namespace EquipmentLeaseService.ControllerTests
{
    public class ContractRequestsControllerTests
    {
        private readonly Mock<IContractRequestsService> _mockService;
        private readonly ContractRequestsController _controller;
        private readonly Fixture _fixture;

        public ContractRequestsControllerTests()
        {
            _mockService = new Mock<IContractRequestsService>();
            _controller = new ContractRequestsController(_mockService.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task CreateUpdateRequest_ReturnsOk_WhenSuccess()
        {
            // Arrange
            var request = _fixture.Create<ContractUpdateRequestDto>();

            _mockService.Setup(s => s.CreateUpdateRequest(request))
                .ReturnsAsync(CreateUpdateRequestResult.Success);

            // Act
            var result = await _controller.CreateUpdateRequest(request);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Request for update contract is created", actionResult.Value);
        }

        [Fact]
        public async Task CreateUpdateRequest_ReturnsBadRequest_WhenInvalidQuantity()
        {
            // Arrange
            var request = _fixture.Build<ContractUpdateRequestDto>()
                .With(x => x.EquipmentQuantity, 0) 
                .Create();

            _mockService.Setup(s => s.CreateUpdateRequest(request))
                .ReturnsAsync(CreateUpdateRequestResult.InvalidQuantity);

            // Act
            var result = await _controller.CreateUpdateRequest(request);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Equipment quantity must be greater than zero", actionResult.Value);
        }

        [Fact]
        public async Task GetAllUpdateRequests_ReturnsOk_WhenRequestsExist()
        {
            // Arrange
            var requests = _fixture.Create<List<ContractUpdateResponseDto>>();

            _mockService.Setup(s => s.GetAllUpdateRequests())
                .ReturnsAsync(requests);

            // Act
            var result = await _controller.GetAllUpdateRequests();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(requests, actionResult.Value);
        }

        [Fact]
        public async Task GetAllUpdateRequests_ReturnsNotFound_WhenNoRequestsExist()
        {
            // Arrange
            _mockService.Setup(s => s.GetAllUpdateRequests())
                .ReturnsAsync(new List<ContractUpdateResponseDto>());

            // Act
            var result = await _controller.GetAllUpdateRequests();

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task DeleteUpdateRequest_ReturnsNoContent_WhenSuccessful()
        {
            // Arrange
            var id = Guid.NewGuid();

            _mockService.Setup(s => s.DeleteUpdateRequest(id))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteUpdateRequest(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteUpdateRequest_ReturnsNotFound_WhenDeletionFails()
        {
            // Arrange
            var id = Guid.NewGuid();

            _mockService.Setup(s => s.DeleteUpdateRequest(id))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteUpdateRequest(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}

using EquipmentLeaseService.Core.DTO.Contract;
using EquipmentLeaseService.Core.DTO.ContractUpdateRequest;
using EquipmentLeaseService.Core.Enums;
using EquipmentLeaseService.Core.ServiceContracts;
using EquipmentLeaseService.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentLeaseService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractRequestsController : ControllerBase
    {
        private readonly IContractRequestsService _contractRequestsService;

        public ContractRequestsController(IContractRequestsService contractRequestsService)
        {
            _contractRequestsService = contractRequestsService;
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUpdateRequest([FromBody] ContractUpdateRequestDto contractUpdateRequest)
        {
            if (contractUpdateRequest == null)
            {
                return NotFound();
            }

            var result = await _contractRequestsService.CreateUpdateRequest(contractUpdateRequest);

            return result switch
            {
                CreateUpdateRequestResult.Success => Ok("Request for update contract is created"),
                CreateUpdateRequestResult.InvalidQuantity => BadRequest("Equipment quantity must be greater than zero"),
                CreateUpdateRequestResult.ContractNotFound => BadRequest("Contract with provided ID does not exist"),
                CreateUpdateRequestResult.EquipmentNotFound => BadRequest("Process equipment type with provided code does not exist"),
                CreateUpdateRequestResult.FacilityNotFound => BadRequest("Production facility with provided code does not exist"),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "An unknown error occurred.")
            };
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ContractUpdateResponseDto>>> GetAllUpdateRequests() 
        {
            List<ContractUpdateResponseDto> updateRequests = await _contractRequestsService.GetAllUpdateRequests();

            if (updateRequests.Count == 0)
            {
                return NotFound();
            }

            return Ok(updateRequests);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUpdateRequest([FromRoute] Guid id) 
        {
            bool isDeleted = await _contractRequestsService.DeleteUpdateRequest(id);

            if (!isDeleted) 
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}

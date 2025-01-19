using EquipmentLeaseService.Core.DTO.Contract;
using EquipmentLeaseService.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EquipmentLeaseService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(201, Type = typeof(ContractResponseDto))]
        public async Task<ActionResult<ContractResponseDto>> CreateContract([FromBody] ContractAddRequestDto contractAddRequest)
        {
            if (contractAddRequest == null)
            {
                return BadRequest("Request data is missing.");
            }

            decimal? occupiedEquipmentArea = await _contractService.GetOccupiedEquipmentArea(contractAddRequest.ProcessEquipmentTypeCode);

            if (occupiedEquipmentArea == null) 
            {
                return NotFound($"Process Equipment Type with code {contractAddRequest.ProcessEquipmentTypeCode} not found.");
            }

            bool IsFacilityAreaUpdated = await _contractService.UpdateFacilityArea(
                contractAddRequest.ProductionFacilityCode,
                contractAddRequest.EquipmentQuantity,
                occupiedEquipmentArea);

            if (!IsFacilityAreaUpdated)
            {
                return BadRequest("Not enough space available to place the Process Equipment Type in the specified Production Facility.");
            }

            ContractResponseDto contractResponse = await _contractService.CreateContract(contractAddRequest);

            return CreatedAtAction(nameof(GetContract), new { contractId = contractResponse.ContractId }, contractResponse);
        }

        [HttpGet]
        [Route("[action]/{contractId}")]
        public async Task<ActionResult<ContractResponseDto>> GetContract([FromRoute] Guid contractId) 
        {
            ContractResponseDto contractResponse = await _contractService.GetContract(contractId);

            if (contractResponse == null) 
            {
                return NotFound();
            }

            return Ok(contractResponse);
        }

        [HttpGet]
        [Route("[action]/{contractId}")]
        public async Task<ActionResult<ContractFullResponseDto>> GetFullContract([FromRoute] Guid contractId)
        {
            ContractFullResponseDto contractFullResponse = await _contractService.GetFullContract(contractId);

            if (contractFullResponse == null)
            {
                return NotFound();
            }

            return Ok(contractFullResponse);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<ContractResponseDto>>> GetAllContracts() 
        {
            List<ContractResponseDto>? contractResponses = await _contractService.GetAllContracts();

            if(contractResponses.Count == 0)
            {
                return NotFound();
            }

            return Ok(contractResponses);
        }

    }
}

using EquipmentLeaseService.Core.DTO;
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
        public async Task<ActionResult<ContractResponseDto>> CreateContract([FromBody] ContractAddRequestDto contractAddRequest)
        {
            if (contractAddRequest == null)
            {
                return BadRequest("Request data is missing.");
            }
            
            ContractResponseDto contractResponse = await _contractService.CreateContract(contractAddRequest);

            return CreatedAtAction(nameof(GetContract), new { contractId = contractResponse.ContractId }, contractResponse);
        }

        [HttpGet("{contractId}")]
        public async Task<ActionResult<ContractResponseDto>> GetContract([FromRoute] Guid contractId) 
        {
            ContractResponseDto contractResponse = await _contractService.GetContractById(contractId);

            if (contractResponse == null) 
            {
                return NotFound();
            }

            return Ok(contractResponse);
        }

        [HttpGet]
        public async Task<ActionResult<List<ContractResponseDto>>> GetAllContracts() 
        {
            List<ContractResponseDto>? contractResponses = await _contractService.GetAllContracts();

            if(contractResponses == null)
            {
                return NotFound();
            }

            return Ok(contractResponses);
        }

    }
}

using EquipmentLeaseService.Core.DTO.Contract;
using EquipmentLeaseService.Core.Enums;
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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ContractResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContractResponseDto>> CreateContract([FromBody] ContractAddRequestDto contractAddRequest)
        {
            var result = await _contractService.CreateContractWithValidation(contractAddRequest);

            return result.Status switch
            {
                CreateContractResultStatus.Success => CreatedAtAction(nameof(GetContract), new { contractId = result.Contract!.ContractId }, result.Contract),
                CreateContractResultStatus.InvalidRequest => BadRequest(result.ErrorMessage),
                CreateContractResultStatus.InvalidEquipmentQuantity => BadRequest(result.ErrorMessage),
                CreateContractResultStatus.EquipmentTypeNotFound => NotFound(result.ErrorMessage),
                CreateContractResultStatus.ProductionFacilityNotFound => NotFound(result.ErrorMessage),
                CreateContractResultStatus.InsufficientSpace => BadRequest(result.ErrorMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "An unknown error occurred.")
            };
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ContractResponseDto>>> GetAllContracts() 
        {
            List<ContractResponseDto> contractResponses = await _contractService.GetAllContracts();

            if(contractResponses.Count == 0)
            {
                return NotFound();
            }

            return Ok(contractResponses);
        }

    }
}

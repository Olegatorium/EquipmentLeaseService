using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.DTO.Contract;
using EquipmentLeaseService.Core.DTO.Facility;
using EquipmentLeaseService.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentLeaseService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionFacilitiesController : ControllerBase
    {
        private readonly IProductionFacilityService _productionFacilityService;

        public ProductionFacilitiesController(IProductionFacilityService productionFacilityService)
        {
            _productionFacilityService = productionFacilityService;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<FacilityResponseDto>>> GetAllFacilities()
        {
            List<FacilityResponseDto> facilityResponses = await _productionFacilityService.GetAllFacilities();

            if (facilityResponses.Count == 0)
            {
                return NotFound();
            }

            return Ok(facilityResponses);
        }
    }
}

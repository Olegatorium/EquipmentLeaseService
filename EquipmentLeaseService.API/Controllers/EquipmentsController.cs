using EquipmentLeaseService.Core.DTO.Equipment;
using EquipmentLeaseService.Core.DTO.Facility;
using EquipmentLeaseService.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentLeaseService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        
        public EquipmentsController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<EquipmentResponseDto>>> GetAllEquipments() 
        {
            List<EquipmentResponseDto> equipmentResponses = await _equipmentService.GetAllEquipments();

            if (equipmentResponses.Count == 0)
            {
                return NotFound();
            }

            return Ok(equipmentResponses);
        }
    }
}

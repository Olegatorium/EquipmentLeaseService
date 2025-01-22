using EquipmentLeaseService.Core.DTO.Contract;
using EquipmentLeaseService.Core.DTO.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.ServiceContracts
{
    public interface IProductionFacilityService
    {
        Task<List<FacilityResponseDto>> GetAllFacilities();
    }
}

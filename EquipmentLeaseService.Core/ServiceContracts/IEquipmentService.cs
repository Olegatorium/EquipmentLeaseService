using EquipmentLeaseService.Core.DTO.Equipment;
using EquipmentLeaseService.Core.DTO.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.ServiceContracts
{
    public interface IEquipmentService
    {
        Task<List<EquipmentResponseDto>> GetAllEquipments();
    }
}

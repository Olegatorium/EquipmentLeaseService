using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.DTO.Equipment;
using EquipmentLeaseService.Core.DTO.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.DTO.Contract
{
    public class ContractFullResponseDto
    {
        public Guid ContractId { get; set; }
        public int EquipmentQuantity { get; set; }
        public DateTime ContractDate { get; set; }

        public FacilityResponseDto FacilityResponse { get; set; }
        public EquipmentResponseDto EquipmentResponse { get; set; }
    }
}

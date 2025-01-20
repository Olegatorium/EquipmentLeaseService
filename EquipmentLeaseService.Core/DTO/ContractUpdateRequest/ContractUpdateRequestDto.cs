using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.DTO.ContractUpdateRequest
{
    public class ContractUpdateRequestDto
    {
        [Required]
        public Guid ContractId { get; set; }
        
        [Required]
        public int EquipmentQuantity { get; set; }

        [Required]
        public Guid ProductionFacilityCode { get; set; }

        [Required]
        public Guid ProcessEquipmentTypeCode { get; set; }
    }
}

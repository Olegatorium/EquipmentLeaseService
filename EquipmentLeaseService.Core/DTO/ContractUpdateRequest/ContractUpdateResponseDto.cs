using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.DTO.ContractUpdateRequest
{
    public class ContractUpdateResponseDto
    {
        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        public int EquipmentQuantity { get; set; }
        public Guid ProductionFacilityCode { get; set; }
        public Guid ProcessEquipmentTypeCode { get; set; }
    }
}

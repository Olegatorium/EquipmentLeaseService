using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.DTO
{
    public class ContractResponseDto
    {
        public Guid ContractId { get; set; }
        public int EquipmentQuantity { get; set; }
        public DateTime ContractDate { get; set; }
        public Guid ProductionFacilityCode { get; set; }
        public Guid ProcessEquipmentTypeCode { get; set; }
    }
}

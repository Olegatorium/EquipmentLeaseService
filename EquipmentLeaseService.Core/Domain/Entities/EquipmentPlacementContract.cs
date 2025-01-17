using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.Domain.Entities
{
    public class EquipmentPlacementContract
    {
        [Key]
        public Guid ContractId { get; set; }
        public int EquipmentQuantity { get; set; }
        public DateTime ContractDate { get; set; }

        [ForeignKey("ProductionFacility")]
        public Guid ProductionFacilityCode { get; set; }

        [ForeignKey("ProcessEquipmentType")]
        public Guid ProcessEquipmentTypeCode { get; set; }

        public ProductionFacility ProductionFacility { get; set; }
        public ProcessEquipmentType ProcessEquipmentType { get; set; }
    }
}
    
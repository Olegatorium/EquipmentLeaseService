using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.Domain.Entities
{
    public class ContractUpdateRequest
    {
        [Key]
        public Guid Id { get; set; }
        public int EquipmentQuantity { get; set; }

        [ForeignKey("EquipmentPlacementContract")]
        public Guid ContractId { get; set; }

        public Guid ProductionFacilityCode { get; set; }

        public Guid ProcessEquipmentTypeCode { get; set; }

        public EquipmentPlacementContract EquipmentPlacementContract { get; set; }
    }
}

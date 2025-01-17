using EquipmentLeaseService.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.DTO
{
    public class PlacementContractAddRequestDto
    {
        [Required]
        public int EquipmentQuantity { get; set; }

        [Required]
        public DateTime ContractDate { get; set; }

        [Required]
        public Guid ProductionFacilityCode { get; set; }
       
        [Required]
        public Guid ProcessEquipmentTypeCode { get; set; }
    }
}

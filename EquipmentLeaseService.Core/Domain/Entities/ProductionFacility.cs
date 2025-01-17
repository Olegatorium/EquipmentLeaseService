using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.Domain.Entities
{
    public class ProductionFacility
    {
        [Key]
        public Guid Code { get; set; }
        public string Name { get; set; }
        public decimal StandardAreaForEquipment { get; set; }

        public ICollection<EquipmentPlacementContract> EquipmentPlacementContracts { get; set; }
    }

}

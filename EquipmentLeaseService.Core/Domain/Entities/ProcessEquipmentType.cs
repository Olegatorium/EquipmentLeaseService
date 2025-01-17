using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.Domain.Entities
{
    public class ProcessEquipmentType
    {
        [Key]
        public Guid Code { get; set; }
        public string Name { get; set; }
        public decimal Area { get; set; }

        public ICollection<EquipmentPlacementContract> EquipmentPlacementContracts { get; set; }
    }

}

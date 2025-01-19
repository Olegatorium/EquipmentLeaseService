using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.DTO.Facility
{
    public class FacilityResponseDto
    {
        public Guid Code { get; set; }
        public string Name { get; set; }
        public decimal StandardAreaForEquipment { get; set; }
    }
}

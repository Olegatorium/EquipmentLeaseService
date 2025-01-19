using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.DTO.Equipment
{
    public class EquipmentResponseDto
    {
        public Guid Code { get; set; }
        public string Name { get; set; }
        public decimal Area { get; set; }
    }
}

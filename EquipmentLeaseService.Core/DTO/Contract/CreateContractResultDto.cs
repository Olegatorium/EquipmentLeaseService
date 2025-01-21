using EquipmentLeaseService.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.DTO.Contract
{
    public class CreateContractResultDto
    {
        public CreateContractResultStatus Status { get; set; }
        public ContractResponseDto? Contract { get; set; }
        public string? ErrorMessage { get; set; }
    }

}

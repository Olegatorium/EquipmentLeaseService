using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.Enums
{
    public enum CreateContractResultStatus
    {
        Success,
        InvalidRequest,
        InvalidEquipmentQuantity,
        EquipmentTypeNotFound,
        ProductionFacilityNotFound,
        InsufficientSpace
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.Enums
{
    public enum CreateUpdateRequestResult
    {
        Success,
        ContractNotFound,
        EquipmentNotFound,
        FacilityNotFound,
        InvalidQuantity,
        UnknownError
    }
}

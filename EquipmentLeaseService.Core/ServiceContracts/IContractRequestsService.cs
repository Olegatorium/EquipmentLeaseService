using EquipmentLeaseService.Core.DTO.ContractUpdateRequest;
using EquipmentLeaseService.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.ServiceContracts
{
    public interface IContractRequestsService
    {
        Task<CreateUpdateRequestResult> CreateUpdateRequest(ContractUpdateRequestDto contractUpdateRequest);
        Task<List<ContractUpdateResponseDto>> GetAllUpdateRequests();
        Task<bool> DeleteUpdateRequest(Guid id);
    }
}

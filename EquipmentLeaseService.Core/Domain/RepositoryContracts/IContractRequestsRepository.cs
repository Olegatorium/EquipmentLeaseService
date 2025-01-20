using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.Domain.RepositoryContracts
{
    public interface IContractRequestsRepository
    {
        public Task<CreateUpdateRequestResult> Create(ContractUpdateRequest contractUpdateRequest);
        public Task<List<ContractUpdateRequest>> GetAll();
        Task<bool> Delete(Guid id);
    }
}

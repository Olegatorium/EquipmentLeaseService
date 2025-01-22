using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.Domain.RepositoryContracts
{
    public interface IContractRepository
    {
        Task CreateContract(EquipmentPlacementContract contract);
        Task<List<EquipmentPlacementContract>> GetAllContracts();
        Task<EquipmentPlacementContract?> GetContract(Guid contractId);
        Task<EquipmentPlacementContract?> GetFullContract(Guid contractId);
        Task<ProcessEquipmentType?> GetProcessEquipmentType(Guid processEquipmentTypeCode);
        Task<CreateContractResultStatus> UpdateFacilityArea(Guid productionFacilityCode, decimal? takenArea);
        Task<bool> DeleteContract(Guid id);
    }
}

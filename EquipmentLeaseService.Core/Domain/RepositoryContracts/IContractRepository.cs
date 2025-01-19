using EquipmentLeaseService.Core.Domain.Entities;
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
        Task<bool> UpdateFacilityArea(Guid productionFacilityCode, decimal? takenArea);
    }
}

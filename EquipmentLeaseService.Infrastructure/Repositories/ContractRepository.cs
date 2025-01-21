using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.Domain.RepositoryContracts;
using EquipmentLeaseService.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace EquipmentLeaseService.Infrastructure.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly ApplicationDbContext _db;

        public ContractRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateContract(EquipmentPlacementContract contract)
        {
            await _db.EquipmentPlacementContracts.AddAsync(contract);   

            await _db.SaveChangesAsync();
        }

        public async Task<List<EquipmentPlacementContract>> GetAllContracts()
        {
            return await _db.EquipmentPlacementContracts.ToListAsync();
        }

        public async Task<EquipmentPlacementContract?> GetContract(Guid contractId)
        {
            return await _db.EquipmentPlacementContracts.FirstOrDefaultAsync(x=>x.ContractId == contractId);
        }

        public async Task<EquipmentPlacementContract?> GetFullContract(Guid contractId)
        {
            return await _db.EquipmentPlacementContracts
                .Include(x => x.ProductionFacility)
                .Include(x => x.ProcessEquipmentType)
                .FirstOrDefaultAsync(x => x.ContractId == contractId);
        }

        public async Task<ProcessEquipmentType?> GetProcessEquipmentType(Guid processEquipmentTypeCode)
        {
            return await _db.ProcessEquipmentTypes.FirstOrDefaultAsync(x=>x.Code == processEquipmentTypeCode);
        }

        public async Task<CreateContractResultStatus> UpdateFacilityArea(Guid productionFacilityCode, decimal? takenArea)
        {
            ProductionFacility? productionFacility = await _db.ProductionFacilities
                .FirstOrDefaultAsync(x => x.Code == productionFacilityCode);

            if (productionFacility == null) 
                return CreateContractResultStatus.ProductionFacilityNotFound;

            decimal? remainingArea = productionFacility.StandardAreaForEquipment - takenArea;

            if (remainingArea < 0)
                return CreateContractResultStatus.InsufficientSpace;

            productionFacility.StandardAreaForEquipment = remainingArea ?? 0;

            await _db.SaveChangesAsync();

            return CreateContractResultStatus.Success;
        }
    }
}

using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.Domain.RepositoryContracts;
using EquipmentLeaseService.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Infrastructure.Repositories
{
    public class ContractRequestsRepository : IContractRequestsRepository
    {
        private readonly ApplicationDbContext _db;

        public ContractRequestsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<CreateUpdateRequestResult> Create(ContractUpdateRequest contractUpdateRequest)
        {
            bool isContractExist = await _db.EquipmentPlacementContracts
                .AnyAsync(x => x.ContractId == contractUpdateRequest.ContractId);

            if (!isContractExist)
                return CreateUpdateRequestResult.ContractNotFound;

            bool isEquipmentExist = await _db.ProcessEquipmentTypes
                .AnyAsync(x => x.Code == contractUpdateRequest.ProcessEquipmentTypeCode);

            if (!isEquipmentExist)
                return CreateUpdateRequestResult.EquipmentNotFound;

            bool isFacilityExist = await _db.ProductionFacilities
                .AnyAsync(x => x.Code == contractUpdateRequest.ProductionFacilityCode);

            if (!isFacilityExist)
                return CreateUpdateRequestResult.FacilityNotFound;

            await _db.AddAsync(contractUpdateRequest);
            await _db.SaveChangesAsync();

            return CreateUpdateRequestResult.Success;
        }

        public async Task<List<ContractUpdateRequest>> GetAll()
        {
            return await _db.ContractUpdateRequests.ToListAsync();
        }

        public async Task<bool> Delete(Guid id) 
        {
            ContractUpdateRequest? request = await _db.ContractUpdateRequests.FindAsync(id);
            if (request == null) return false;

            _db.ContractUpdateRequests.Remove(request);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

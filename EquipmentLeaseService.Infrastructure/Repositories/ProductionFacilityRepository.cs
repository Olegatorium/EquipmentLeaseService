using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Infrastructure.Repositories
{
    public class ProductionFacilityRepository : IProductionFacilityRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductionFacilityRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ProductionFacility>> GetAllFacilities()
        {
            return await _db.ProductionFacilities.ToListAsync();
        }
    }
}

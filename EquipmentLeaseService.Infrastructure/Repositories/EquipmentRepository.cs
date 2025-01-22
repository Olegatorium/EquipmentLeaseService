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
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ApplicationDbContext _db;

        public EquipmentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ProcessEquipmentType>> GetAllEquipments()
        {
            return await _db.ProcessEquipmentTypes.ToListAsync();
        }
    }
}

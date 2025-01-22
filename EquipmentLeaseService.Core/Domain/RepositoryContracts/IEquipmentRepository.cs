using EquipmentLeaseService.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.Domain.RepositoryContracts
{
    public interface IEquipmentRepository
    {
        Task<List<ProcessEquipmentType>> GetAllEquipments();
    }
}

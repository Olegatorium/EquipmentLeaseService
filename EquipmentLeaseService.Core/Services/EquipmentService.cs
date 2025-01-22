using AutoMapper;
using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.Domain.RepositoryContracts;
using EquipmentLeaseService.Core.DTO.Equipment;
using EquipmentLeaseService.Core.DTO.Facility;
using EquipmentLeaseService.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IMapper mapper, IEquipmentRepository equipmentRepository)
        {
            _mapper = mapper;
            _equipmentRepository = equipmentRepository;
        }
        public async Task<List<EquipmentResponseDto>> GetAllEquipments()
        {
            List<ProcessEquipmentType> equipments = await _equipmentRepository.GetAllEquipments();

            return _mapper.Map<List<EquipmentResponseDto>>(equipments);
        }
    }
}

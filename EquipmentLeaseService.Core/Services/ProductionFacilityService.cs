using AutoMapper;
using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.Domain.RepositoryContracts;
using EquipmentLeaseService.Core.DTO.Facility;
using EquipmentLeaseService.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.Services
{
    public class ProductionFacilityService : IProductionFacilityService
    {
        private readonly IMapper _mapper;
        private readonly IProductionFacilityRepository _facilityRepository;

        public ProductionFacilityService(IMapper mapper, IProductionFacilityRepository facilityRepository)
        {
            _mapper = mapper;
            _facilityRepository = facilityRepository;
        }

        public async Task<List<FacilityResponseDto>> GetAllFacilities()
        {
            List<ProductionFacility> facilities = await _facilityRepository.GetAllFacilities();

            return _mapper.Map<List<FacilityResponseDto>>(facilities);
        }
    }
}

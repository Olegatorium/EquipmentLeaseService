using AutoMapper;
using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.Domain.RepositoryContracts;
using EquipmentLeaseService.Core.DTO.Contract;
using EquipmentLeaseService.Core.ServiceContracts;
using System.Collections.Generic;

namespace EquipmentLeaseService.Core.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ContractService(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<ContractResponseDto> CreateContract(ContractAddRequestDto contractAddRequest)
        {
            EquipmentPlacementContract contract = _mapper.Map<EquipmentPlacementContract>(contractAddRequest);
            contract.ContractId = Guid.NewGuid();

            await _contractRepository.CreateContract(contract);

            return _mapper.Map<ContractResponseDto>(contract);
        }

        public async Task<bool> UpdateFacilityArea(Guid productionFacilityCode, int equipmentQuantity, decimal? occupiedEquipmentArea)
        {
            decimal? takenArea = equipmentQuantity * occupiedEquipmentArea;

            bool isUpdated = await _contractRepository.UpdateFacilityArea(productionFacilityCode, takenArea);

            return isUpdated;
        }

        public async Task<decimal?> GetOccupiedEquipmentArea(Guid equipmentTypeCode)
        {
            ProcessEquipmentType? equipmentType = await _contractRepository.GetProcessEquipmentType(equipmentTypeCode);

            if (equipmentType == null)
                return null;

            return equipmentType.Area;
        }

        public async Task<ContractFullResponseDto> GetFullContract(Guid contractId) 
        {
            EquipmentPlacementContract? contract = await _contractRepository.GetFullContract(contractId);

            return _mapper.Map<ContractFullResponseDto>(contract);
        }

        public async Task<ContractResponseDto> GetContract(Guid contractId)
        {
            EquipmentPlacementContract? contract = await _contractRepository.GetContract(contractId);

            return _mapper.Map<ContractResponseDto>(contract);
        }

        public async Task<List<ContractResponseDto>> GetAllContracts()
        {
            List<EquipmentPlacementContract> contracts = await _contractRepository.GetAllContracts();

            return _mapper.Map<List<ContractResponseDto>>(contracts);
        }

    }
}

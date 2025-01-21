using AutoMapper;
using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.Domain.RepositoryContracts;
using EquipmentLeaseService.Core.DTO.Contract;
using EquipmentLeaseService.Core.Enums;
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

        public async Task<CreateContractResultDto> CreateContractWithValidation(ContractAddRequestDto contractAddRequest)
        {
            if (contractAddRequest == null)
            {
                return new CreateContractResultDto
                {
                    Status = CreateContractResultStatus.InvalidRequest,
                    ErrorMessage = "Request data is missing."
                };
            }

            if (contractAddRequest.EquipmentQuantity <= 0)
            {
                return new CreateContractResultDto
                {
                    Status = CreateContractResultStatus.InvalidEquipmentQuantity,
                    ErrorMessage = "Equipment Quantity can't be less or equal to 0."
                };
            }

            decimal? occupiedEquipmentArea = await GetOccupiedEquipmentArea(contractAddRequest.ProcessEquipmentTypeCode);

            if (occupiedEquipmentArea == null)
            {
                return new CreateContractResultDto
                {
                    Status = CreateContractResultStatus.EquipmentTypeNotFound,
                    ErrorMessage = $"Process Equipment Type with code {contractAddRequest.ProcessEquipmentTypeCode} not found."
                };
            }

            CreateContractResultStatus isFacilityAreaUpdated = await UpdateFacilityArea(
                contractAddRequest.ProductionFacilityCode,
                contractAddRequest.EquipmentQuantity,
                occupiedEquipmentArea);

            if (isFacilityAreaUpdated == CreateContractResultStatus.ProductionFacilityNotFound)
            {
                return new CreateContractResultDto
                {
                    Status = CreateContractResultStatus.ProductionFacilityNotFound,
                    ErrorMessage = $"Production Facility with code {contractAddRequest.ProductionFacilityCode} not found."
                };
            }
            else if(isFacilityAreaUpdated == CreateContractResultStatus.InsufficientSpace)
            {
                return new CreateContractResultDto
                {
                    Status = CreateContractResultStatus.InsufficientSpace,
                    ErrorMessage = "Not enough space available to place the Process Equipment Type in the specified Production Facility."
                };
            }

            ContractResponseDto contractResponse = await CreateContract(contractAddRequest);

            return new CreateContractResultDto
            {
                Status = CreateContractResultStatus.Success,
                Contract = contractResponse
            };
        }


        public async Task<CreateContractResultStatus> UpdateFacilityArea(Guid productionFacilityCode, int equipmentQuantity, decimal? occupiedEquipmentArea)
        {
            decimal? takenArea = equipmentQuantity * occupiedEquipmentArea;

            CreateContractResultStatus isUpdated = await _contractRepository.UpdateFacilityArea(productionFacilityCode, takenArea);

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

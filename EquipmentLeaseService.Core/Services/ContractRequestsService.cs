using AutoMapper;
using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.Domain.RepositoryContracts;
using EquipmentLeaseService.Core.DTO.Contract;
using EquipmentLeaseService.Core.DTO.ContractUpdateRequest;
using EquipmentLeaseService.Core.Enums;
using EquipmentLeaseService.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.Services
{
    public class ContractRequestsService : IContractRequestsService
    {
        private readonly IMapper _mapper;
        private readonly IContractRequestsRepository _contractRequestsRepository;

        public ContractRequestsService(IMapper mapper, IContractRequestsRepository contractRequestRepository)
        {
           _mapper = mapper;
           _contractRequestsRepository = contractRequestRepository;
        }

        public async Task<CreateUpdateRequestResult> CreateUpdateRequest(ContractUpdateRequestDto contractUpdateRequestDto)
        {
            if (contractUpdateRequestDto.EquipmentQuantity <= 0)
                return CreateUpdateRequestResult.InvalidQuantity;

            ContractUpdateRequest contractUpdateRequest = _mapper.Map<ContractUpdateRequest>(contractUpdateRequestDto);
            contractUpdateRequest.Id = Guid.NewGuid();

            var result = await _contractRequestsRepository.Create(contractUpdateRequest);
            return result;
        }

        public async Task<List<ContractUpdateResponseDto>> GetAllUpdateRequests()
        {
            List<ContractUpdateRequest> updateRequests = await _contractRequestsRepository.GetAll();

            return _mapper.Map<List<ContractUpdateResponseDto>>(updateRequests);
        }

        public async Task<bool> DeleteUpdateRequest(Guid id) 
        {
            bool isDeleted = await _contractRequestsRepository.Delete(id);

            return isDeleted;
        }

    }
}

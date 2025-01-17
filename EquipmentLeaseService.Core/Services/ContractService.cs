using EquipmentLeaseService.Core.Domain.RepositoryContracts;
using EquipmentLeaseService.Core.DTO;
using EquipmentLeaseService.Core.ServiceContracts;

namespace EquipmentLeaseService.Core.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public Task<ContractResponseDto> CreateContract(ContractAddRequestDto contractAddRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContractResponseDto>> GetAllContracts()
        {
            throw new NotImplementedException();
        }

        public Task<ContractResponseDto> GetContractById(Guid contractId)
        {
            throw new NotImplementedException();
        }
    }
}

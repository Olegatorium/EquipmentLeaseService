using EquipmentLeaseService.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.ServiceContracts
{
    public interface IContractService
    {
        Task<ContractResponseDto> CreateContract(ContractAddRequestDto contractAddRequest);
        Task<ContractResponseDto> GetContractById(Guid contractId);
        Task<List<ContractResponseDto>> GetAllContracts();
    }
}

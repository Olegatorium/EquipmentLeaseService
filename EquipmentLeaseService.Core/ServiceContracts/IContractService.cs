using EquipmentLeaseService.Core.DTO.Contract;
using EquipmentLeaseService.Core.DTO.ContractUpdateRequest;
using EquipmentLeaseService.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentLeaseService.Core.ServiceContracts
{
    public interface IContractService
    {
        Task<CreateContractResultDto> CreateContractWithValidation(ContractAddRequestDto contractAddRequest);
        Task<ContractResponseDto> CreateContract(ContractAddRequestDto contractAddRequest);
        Task<ContractResponseDto> GetContract(Guid contractId);
        Task<ContractFullResponseDto> GetFullContract(Guid contractId);
        Task<List<ContractResponseDto>> GetAllContracts();
        Task<CreateContractResultStatus> UpdateFacilityArea(Guid productionFacilityCode, int equipmentQuantity, decimal? occupiedEquipmentArea); 
        Task<decimal?> GetOccupiedEquipmentArea(Guid processEquipmentTypeCode);
    }
}

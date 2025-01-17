using AutoMapper;
using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.DTO;

namespace EquipmentLeaseService.Core.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<EquipmentPlacementContract, PlacementContractAddRequestDto>().ReverseMap();
            CreateMap<EquipmentPlacementContract, PlacementContractResponseDto>().ReverseMap();
        }
    }
}

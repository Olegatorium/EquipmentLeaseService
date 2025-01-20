using AutoMapper;
using EquipmentLeaseService.Core.Domain.Entities;
using EquipmentLeaseService.Core.DTO.Contract;
using EquipmentLeaseService.Core.DTO.ContractUpdateRequest;
using EquipmentLeaseService.Core.DTO.Equipment;
using EquipmentLeaseService.Core.DTO.Facility;

namespace EquipmentLeaseService.Core.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            // Contract
            CreateMap<EquipmentPlacementContract, ContractAddRequestDto>().ReverseMap();
            CreateMap<EquipmentPlacementContract, ContractResponseDto>().ReverseMap();
            CreateMap<EquipmentPlacementContract, ContractFullResponseDto>()
             .ForMember(dest => dest.FacilityResponse, opt => opt.MapFrom(src => src.ProductionFacility))
             .ForMember(dest => dest.EquipmentResponse, opt => opt.MapFrom(src => src.ProcessEquipmentType));

            // ProductionFacility
            CreateMap<ProductionFacility, FacilityResponseDto>().ReverseMap();

            // ProcessEquipmentType
            CreateMap<ProcessEquipmentType, EquipmentResponseDto>().ReverseMap();

            // ContractUpdateRequest
            CreateMap<ContractUpdateRequest, ContractUpdateRequestDto>().ReverseMap();
            CreateMap<ContractUpdateRequest, ContractUpdateResponseDto>().ReverseMap();
        }
    }
}

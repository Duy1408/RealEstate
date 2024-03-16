using AutoMapper;
using BusinessObject.BusinessObject;
using BusinessObject.DTO.Request;
using BusinessObject.DTO.Response;

namespace GroupProject.Mapper
{
    public class RealEstateProfile : Profile
    {
        public RealEstateProfile()
        {

            CreateMap<RealEstateCreateDTO, RealEstate>()

            .ForMember(
                dest => dest.RealEstateName,
                opt => opt.MapFrom(src => src.RealEstateName)
            )
            .ForMember(
                dest => dest.RealEstateAddress,
                opt => opt.MapFrom(src => src.RealEstateAddress)
            )
            .ForMember(
                dest => dest.Estimation,
                opt => opt.MapFrom(src => src.Estimation)
            ).ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
            )
            .ForMember(
                dest => dest.UserID,
                opt => opt.MapFrom(src => src.UserID)
            )
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => src.Status)
            )
            .ForMember(
                dest => dest.Image,
                opt => opt.MapFrom(src => src.Image)
            );

            CreateMap<RealEstate, RealEstateResponseDTO>()
           .ForMember(
               dest => dest.RealEstateID,
               opt => opt.MapFrom(src => src.RealEstateID)
           )
           .ForMember(
               dest => dest.RealEstateName,
               opt => opt.MapFrom(src => src.RealEstateName)
           )
           .ForMember(
               dest => dest.RealEstateAddress,
               opt => opt.MapFrom(src => src.RealEstateAddress)
           )
           .ForMember(
               dest => dest.Estimation,
               opt => opt.MapFrom(src => src.Estimation)
           ).ForMember(
               dest => dest.Description,
               opt => opt.MapFrom(src => src.Description)
           )
           .ForMember(
               dest => dest.Status,
               opt => opt.MapFrom(src => src.Status)
           )
           .ForMember(
               dest => dest.Image,
               opt => opt.MapFrom(src => src.Image)
           );

            CreateMap<RealEstateUpdateDTO, RealEstate>()


         .ForMember(
             dest => dest.Estimation,
             opt => opt.MapFrom(src => src.Estimation)
         ).ForMember(
             dest => dest.Description,
             opt => opt.MapFrom(src => src.Description)
         )
         .ForMember(
             dest => dest.UserID,
             opt => opt.MapFrom(src => src.UserID)
         )
         .ForMember(
             dest => dest.Status,
             opt => opt.MapFrom(src => src.Status)
         )
         .ForMember(
             dest => dest.Image,
             opt => opt.MapFrom(src => src.Image)
         );






        }
    }
}


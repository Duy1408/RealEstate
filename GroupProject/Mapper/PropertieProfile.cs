using AutoMapper;
using BusinessObject.BusinessObject;
using BusinessObject.DTO.Request;
using BusinessObject.DTO.Response;

namespace GroupProject.Mapper
{
    public class PropertieProfile : Profile
    {
        public PropertieProfile()
        {


            CreateMap<PropertiesCreateDTO, Propertie>()

                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description)
                )
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.Price)
                ).ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status)
                )
                .ForMember(
                    dest => dest.RealEstateID,
                    opt => opt.MapFrom(src => src.RealEstateID)
                );

            CreateMap<PropertieUpdateDTO, Propertie>()

                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description)
                )
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.Price)
                ).ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status)
                );

            CreateMap<PropertiResponseDTO, Propertie>()

               .ForMember(
                   dest => dest.Name,
                   opt => opt.MapFrom(src => src.Name)
               )
               .ForMember(
                   dest => dest.Description,
                   opt => opt.MapFrom(src => src.Description)
               )
               .ForMember(
                   dest => dest.Price,
                   opt => opt.MapFrom(src => src.Price)
               ).ForMember(
                   dest => dest.Status,
                   opt => opt.MapFrom(src => src.Status)
               )
               .ForMember(
                   dest => dest.RealEstateID,
                   opt => opt.MapFrom(src => src.RealEstateID)
               );
             








        }
    }
}

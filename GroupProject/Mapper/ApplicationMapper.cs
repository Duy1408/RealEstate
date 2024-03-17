using AutoMapper;
using BusinessObject.BusinessObject;
using BusinessObject.DTO;
using BusinessObject.DTO.Request;
using BusinessObject.DTO.Response;
using BusinessObject.ViewModels;
using System.Security.Principal;

namespace GroupProject.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<UserVM, User>().ReverseMap().ForMember(dest => dest.RoleName,
                                       opt => opt.MapFrom(src => src.Role!.RoleName))
                                                   .ForMember(dest => dest.BidAmount,
                                       opt => opt.MapFrom(src => src.Bid!.BidAmount));
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserCreateDTO, User>().ReverseMap();

            CreateMap<BidVM, Bid>().ReverseMap();
            CreateMap<BidDTO, Bid>().ReverseMap();


            CreateMap<RealEstateUpdateDTO, RealEstate>().ReverseMap();
            CreateMap<RealEstateResponseDTO, RealEstate>().ReverseMap().ForMember(dest => dest.UserName,
                                       opt => opt.MapFrom(src => src.User!.UserName));

            CreateMap<PropertieUpdateDTO, Propertie>().ReverseMap();
            CreateMap<PropertiResponseDTO, Propertie>().ReverseMap().ForMember(dest => dest.RealEstateName,
                                       opt => opt.MapFrom(src => src.RealEstate!.RealEstateName));

            CreateMap<AuctionUpdateDTO, Auction>().ReverseMap();
            CreateMap<AuctionResponseDTO, Auction>().ReverseMap().ForMember(dest => dest.BidAmount,
                                       opt => opt.MapFrom(src => src.Bid!.BidAmount))
                                                                 .ForMember(dest => dest.RealEstateName,
                                       opt => opt.MapFrom(src => src.RealEstate!.RealEstateName));

            CreateMap<CommentVM, Comment>().ReverseMap().ForMember(dest => dest.UserName,
                                       opt => opt.MapFrom(src => src.User!.UserName))
                                                                 .ForMember(dest => dest.RealEstateName,
                                       opt => opt.MapFrom(src => src.RealEstate!.RealEstateName));
            CreateMap<CommentDTO, Comment>().ReverseMap();

        }
    }
}

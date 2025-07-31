
using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using System.Net.NetworkInformation;

namespace eCommerce.Core.Mappers;

public class ApplicationUserMappingProfile: Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>().ForMember(dest=>dest.UserId,opt=>opt.MapFrom(
            src=>src.UserId));
        CreateMap<ApplicationUser, AuthenticationResponse>().ForMember(dest => dest.Email, opt => opt.MapFrom(
            src => src.Email));
        CreateMap<ApplicationUser, AuthenticationResponse>().ForMember(dest => dest.PersonName, opt => opt.MapFrom(
            src => src.PersonName));
        CreateMap<ApplicationUser, AuthenticationResponse>().ForMember(dest => dest.Gender, opt => opt.MapFrom(
            src => src.Gender));
        CreateMap<ApplicationUser, AuthenticationResponse>().ForMember(dest => dest.Success, opt => opt.Ignore());
        CreateMap<ApplicationUser, AuthenticationResponse>().ForMember(dest => dest.Token, opt => opt.Ignore());


        // Map between RegisterRequest DTO to the ApplicationUser entity
        CreateMap<RegisterRequest, ApplicationUser>().ForMember(dest => dest.Email, opt => opt.MapFrom(
            src => src.Email));
        CreateMap<RegisterRequest, ApplicationUser>().ForMember(dest => dest.Password, opt => opt.MapFrom(
            src => src.Password));
        CreateMap<RegisterRequest, ApplicationUser>().ForMember(dest => dest.PersonName, opt => opt.MapFrom(
            src => src.PersonName));
        CreateMap<RegisterRequest, ApplicationUser>().ForMember(dest => dest.Gender, opt => opt.MapFrom(
            src => src.Gender));


    }
}

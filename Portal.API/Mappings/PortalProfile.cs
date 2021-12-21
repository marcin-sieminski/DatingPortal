using AutoMapper;
using Portal.API.Dtos;
using Portal.API.Models;
using Portal.API.Helpers;

namespace Portal.API.Mappings;

public class PortalProfile : Profile
{
    public PortalProfile()
    {
        CreateMap<User, UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
            .ForMember(dest => dest.Age, opt =>
            {
                opt.MapFrom(src => src.DateOfBirth.CalculateAge());
            });
        
        CreateMap<User, UserForDetailedDto>().ForMember(dest => dest.PhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
            .ForMember(dest => dest.Age, opt =>
            {
                opt.MapFrom(src => src.DateOfBirth.CalculateAge());
             });

        CreateMap<Photo, PhotoForDetailedDto>();
    }
}

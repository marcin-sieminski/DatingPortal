using AutoMapper;
using Portal.API.Dtos;
using Portal.API.Models;

namespace Portal.API.Mappings;

public class PortalProfile : Profile
{
    public PortalProfile()
    {
        CreateMap<User, UserForListDto>();
        CreateMap<User, UserForDetailedDto>();
        CreateMap<Photo, PhotoForDetailedDto>();
    }
}

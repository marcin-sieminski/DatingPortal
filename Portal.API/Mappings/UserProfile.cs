using AutoMapper;
using Portal.API.Dtos;
using Portal.API.Models;

namespace Portal.API.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserForListDto>();
        CreateMap<User, UserForDetailedDto>();
    }
}

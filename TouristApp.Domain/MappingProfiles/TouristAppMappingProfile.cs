using AutoMapper;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.PinpointRoute;
using TouristApp.Domain.Models.Role;
using TouristApp.Domain.Models.Route;
using TouristApp.Domain.Models.User;

namespace TouristApp.Domain.MappingProfiles;

public class TouristAppMappingProfile : Profile {
    public TouristAppMappingProfile() {
        CreateMap<Pinpoint, PinpointDTO>();
        CreateMap<Role, RoleDTO>();
        CreateMap<User, UserDTO>();
        CreateMap<Route, RouteDTO>();
        CreateMap<Category, CategoryDTO>();
        CreateMap<PinpointRoute, PinpointRouteDTO>();
    }
}
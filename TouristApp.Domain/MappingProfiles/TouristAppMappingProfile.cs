using AutoMapper;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.CategoryOfPinpoint;
using TouristApp.Domain.Models.CategoryOfRoute;
using TouristApp.Domain.Models.FavouritePinpoint;
using TouristApp.Domain.Models.FavouriteRoute;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.PinpointRoute;
using TouristApp.Domain.Models.Role;
using TouristApp.Domain.Models.Route;
using TouristApp.Domain.Models.User;

namespace TouristApp.Domain.MappingProfiles;

public class TouristAppMappingProfile : Profile {
    public TouristAppMappingProfile() {
        CreateMap<Pinpoint, PinpointDto>();
        CreateMap<Role, RoleDto>();
        CreateMap<User, UserDTO>();
        CreateMap<Route, RouteDto>();
        CreateMap<CategoryOfPinpoint, CategoryOfPinpointDto>();
        CreateMap<PinpointRoute, PinpointRouteDto>();
        CreateMap<FavouriteRoute, FavouriteRouteDto>();
        CreateMap<FavouritePinpoint, FavouritePinpointDto>();
        CreateMap<CategoryOfRoute, CategoryOfRouteDto>();
        CreateMap<CategoryOfPinpoint, CategoryOfPinpointDto>();
    }
}
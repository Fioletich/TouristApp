using MediatR;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.User;

namespace TouristApp.Application.RequestAndHandler.Users.Queries.GetAllUsers;

public record GetAllUsersRequest : IRequest<IEnumerable<User>>;
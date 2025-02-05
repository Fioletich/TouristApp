using MediatR;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.User;

namespace TouristApp.Application.RequestAndHandler.Users.Queries.GetUser;

public record GetUserRequest(Guid Id) : IRequest<User>;
using MediatR;
using TouristApp.Domain.Models.User;

namespace TouristApp.Application.RequestAndHandler.Users.Queries.GetUserByLogin;

public record GetUserByLoginRequest(string Login) : IRequest<User>;
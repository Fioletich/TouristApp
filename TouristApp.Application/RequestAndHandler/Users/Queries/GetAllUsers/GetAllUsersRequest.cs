using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Users.Queries.GetAllUsers;

public class GetAllUsersRequest : IRequest<IEnumerable<User>> {
    
}
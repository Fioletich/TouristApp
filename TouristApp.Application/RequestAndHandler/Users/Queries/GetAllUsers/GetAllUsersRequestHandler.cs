using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.User;

namespace TouristApp.Application.RequestAndHandler.Users.Queries.GetAllUsers;

public class GetAllUsersRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetAllUsersRequest, IEnumerable<User>> {

    public async Task<IEnumerable<User>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken) {
        return await context.Users.ToListAsync(cancellationToken);
    }
}
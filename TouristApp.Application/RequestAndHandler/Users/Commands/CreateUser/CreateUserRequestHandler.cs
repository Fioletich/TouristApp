using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.CreateUser;

public class CreateUserRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<CreateUserRequest, Guid> {
    public async Task<Guid> Handle(CreateUserRequest request, CancellationToken cancellationToken) {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Login = request.Login,
            Password = request.Password,
            PhoneNumber = request.PhoneNumber,
            Bio = request.Bio,
            Country = request.Country,
            City = request.City
        };

        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
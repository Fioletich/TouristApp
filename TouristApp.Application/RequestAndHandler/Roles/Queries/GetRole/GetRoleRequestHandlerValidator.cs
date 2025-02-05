using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Roles.Queries.GetRole;

public class GetRoleRequestHandlerValidator : AbstractValidator<GetRoleRequest>{
    public GetRoleRequestHandlerValidator() {
        RuleFor(r => r.Id)
            .NotEqual(Guid.Empty);
    }
}
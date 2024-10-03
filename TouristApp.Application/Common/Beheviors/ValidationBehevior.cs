﻿using FluentValidation;
using MediatR;

namespace TouristApp.Application.Common.Beheviors;

public class ValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> {
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehevior(IEnumerable<IValidator<TRequest>> validators) {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {
        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(r => r.Errors)
            .Where(f => f is not null)
            .ToList();

        if (failures.Count != 0)
        {
            throw new ValidationException(failures);
        }

        return next();
    }
}
﻿using FluentValidation;

namespace TouristApp.Application.PinpointsCategories.Commands.CreatePinpointCategory;

public class CreatePinpointCategoryRequestValidator : AbstractValidator<CreatePinpointCategoryRequest> {
    public CreatePinpointCategoryRequestValidator() {
        RuleFor(p => p.CategoryId)
            .NotEqual(Guid.Empty);

        RuleFor(p => p.PinpointId)
            .NotEqual(Guid.Empty);
    }
}
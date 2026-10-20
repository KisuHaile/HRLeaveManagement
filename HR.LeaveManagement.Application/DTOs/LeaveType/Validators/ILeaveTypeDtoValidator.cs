using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.DefaultDays)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}

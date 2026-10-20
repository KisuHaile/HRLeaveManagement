using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            //RuleFor(P => P.Name)
            //   .NotEmpty().WithMessage("{PropertyName} is required.")
            //   .NotNull()
            //   .MaximumLength(70).WithMessage("{PropertyName} must not exceed {comparisonValue}characters.");


            //RuleFor(P => P.DefaultDays)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .GreaterThan(1).WithMessage("{PropertyName} must be greater than 1.")
            //    .LessThan(100).WithMessage("{PropertyName} must be less than 100.");

            Include(new ILeaveTypeDtoValidator());
        }
    }
}

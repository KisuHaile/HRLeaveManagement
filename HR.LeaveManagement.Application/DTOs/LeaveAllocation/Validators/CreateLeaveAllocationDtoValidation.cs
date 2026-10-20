using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidation : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocationDtoValidation()
        {
            RuleFor(P => P.NumberOfDays)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.");

            RuleFor(P => P.LeaveTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(P => P.Period)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}
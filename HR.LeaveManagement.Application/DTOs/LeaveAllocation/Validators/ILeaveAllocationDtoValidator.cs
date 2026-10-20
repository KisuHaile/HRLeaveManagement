using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class LeaveAllocationDtoValidator<T> : AbstractValidator<T> where T : ILeaveAllocationDto
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public LeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NumberOfDays)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be the current year or later.");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveType = await _leaveTypeRepository.Get(id);
                    return leaveType != null;
                }).WithMessage("{PropertyName} does not exist.");
        }

    }
}

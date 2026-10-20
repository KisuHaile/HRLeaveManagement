using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new LeaveRequestDtoValidator<CreateLeaveRequestDto>(_leaveTypeRepository));

            //RuleFor(p => p.StartDate)
            //    .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}.");

            //RuleFor(p => p.EndDate)
            //    .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}.");

            //RuleFor(p => p.LeaveTypeId)
            //    .GreaterThan(0)
            //    .MustAsync(async (id, token) =>
            //    {
            //        var leaveType = await _leaveTypeRepository.Get(id);
            //        return leaveType != null;
            //    }).WithMessage("{PropertyName} does not exist.");

        }
    }
}

using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator :AbstractValidator<UpdateLeaveRequestDto>
    {   
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveRequestDtoValidator(ILeaveTypeRepository _leaveTypeRepository)
        {               
            _leaveTypeRepository = _leaveTypeRepository;
            Include(new LeaveRequestDtoValidator<UpdateLeaveRequestDto>(_leaveTypeRepository));

            RuleFor(P => P.Id).NotNull().WithMessage("{PropertyName} must be present");
        }

        internal async Task ValidateAsync(LeaveRequestDto leaverequestDto)
        {
            throw new NotImplementedException();
        }
    }
}

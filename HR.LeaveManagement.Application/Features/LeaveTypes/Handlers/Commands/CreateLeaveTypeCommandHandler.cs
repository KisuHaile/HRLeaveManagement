using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveType.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Responses;

namespace HR.LeaveManagement.Application.Features.LeaveType.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;               

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            
             
            var leaveType = _mapper.Map<HRLeaveManagement.Domain.LeaveType>(request.LeaveTypeDto);
            
            leaveType = await _leaveTypeRepository.Add(leaveType);
            
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveType.Id;
            return response;
        }
    }
}

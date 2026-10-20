using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Queries
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestDto>>
    {

    }
    
}

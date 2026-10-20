using HR.LeaveManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Contracts.Infractracture
{
    public interface IEmailSender
    {
        public Task<bool> SendEmail(Email email)
        {
            throw new NotImplementedException();
        }

        Task<bool> SenderEmail(Email email);
    }
}

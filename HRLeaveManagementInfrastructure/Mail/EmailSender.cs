using HR.LeaveManagement.Application.Contracts.Infractracture;
using HR.LeaveManagement.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings _emailSetting { get; }
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSetting = emailSettings.Value;
        }
        public async Task<bool> SenderEmail(Email email)
        {
            //throw new NotImplementedException("Email sending has not been configured.");
            var client = new SendGridClient(_emailSetting.ApiKey);
            var to = new EmailAddress(email.To);
            var From = new EmailAddress
            {
                Email = _emailSetting.FromAddress,
                Name = _emailSetting.FromNames
            };

            var message = MailHelper.CreateSingleEmail(From, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}

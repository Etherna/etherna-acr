//   Copyright 2021-present Etherna Sagl
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using Etherna.ACR.Helpers;
using Etherna.ACR.Settings;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Etherna.ACR.Services
{
    public class EmailSender : IEmailSender
    {
        // Fields.
        private readonly EmailSettings settings;

        // Constructor.
        public EmailSender(IOptions<EmailSettings> opts)
        {
            ArgumentNullException.ThrowIfNull(opts, nameof(opts));

            settings = opts.Value;
        }

        // Methods.
        public Task SendEmailAsync(string email, string subject, string message)
        {
            if (!EmailHelper.IsValidEmail(email))
                throw new ArgumentException("Email is not valid", nameof(email));

            return settings.CurrentService switch
            {
                EmailSettings.EmailService.Mailtrap => MailtrapSendEmailAsync(email, subject, message),
                EmailSettings.EmailService.Sendgrid => SendgridSendEmailAsync(email, subject, message),
                EmailSettings.EmailService.FakeSender => Task.CompletedTask,
                _ => throw new InvalidOperationException()
            };
        }

        // Helpers.
        private async Task MailtrapSendEmailAsync(string email, string subject, string message)
        {
            using var client = new SmtpClient
            {
                Host = "smtp.mailtrap.io",
                Port = 2525,
                Credentials = new NetworkCredential(settings.ServiceUser, settings.ServiceKey),
                EnableSsl = true,
            };
            using var mail = new MailMessage(
                new MailAddress(settings.SendingAddress, settings.DisplayName),
                new MailAddress(email))
            {
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };

            await client.SendMailAsync(mail);
        }

        private async Task<Response> SendgridSendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(settings.ServiceKey);

            var from = new EmailAddress(settings.SendingAddress, settings.DisplayName);
            var to = new EmailAddress(email);

            var plainTextContent = message;
            var htmlContent = message;

            var mail = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                plainTextContent,
                htmlContent);

            return await client.SendEmailAsync(mail);
        }
    }
}

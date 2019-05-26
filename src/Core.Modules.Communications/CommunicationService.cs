//-----------------------------------------------------------------------
// <copyright file="CommunicationService.cs" company="Code Miners Limited">
//  Copyright (c) 2019 Code Miners Limited
//   
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//  
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see<https://www.gnu.org/licenses/>.
// </copyright>
//-----------------------------------------------------------------------

namespace Core.Modules.Communications.Sendgrid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Models;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using Attachment = Models.Attachment;
    using EmailAddress = SendGrid.Helpers.Mail.EmailAddress;

    /// <summary>
    /// 
    /// </summary>
    public class CommunicationService : ICommunicationService
    {
        /// <summary>
        /// Gets the communication configuration
        /// </summary>
        public ICommunicationConfiguration Configuration { get; }

        /// <summary>
        /// Initialises the communication service
        /// </summary>
        /// <param name="configuration">The configuration</param>
        public CommunicationService(ICommunicationConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public bool SendCommunication(Sender from, Recipient to, Models.EmailAddress[] bcc, string subject, string message, string htmlMessage, Attachment attachment)
        {
            try
            {
                SendGridClient client = new SendGridClient(Configuration.ApiKey);
                SendGridMessage msg = new SendGridMessage
                {
                    From = new EmailAddress(from.Email),
                    Subject = subject
                };

                if (!string.IsNullOrWhiteSpace(from.Name))
                {
                    msg.From.Name = from.Name;
                }

                if (string.IsNullOrWhiteSpace(to.Name))
                {
                    msg.AddTo(to.Email);
                }
                else
                {
                    msg.AddTo(to.Email, to.Name);
                }

                if (!string.IsNullOrWhiteSpace(message))
                {
                    msg.PlainTextContent = message;
                }

                if (!string.IsNullOrWhiteSpace(htmlMessage))
                {
                    msg.HtmlContent = htmlMessage;
                }

                foreach (Models.EmailAddress email in bcc)
                {
                    if (string.IsNullOrWhiteSpace(email))
                    {
                        continue;
                    }

                    msg.AddBcc(email);
                }

                if (attachment != Attachment.Empty)
                {
                    msg.AddAttachment(attachment.Filename, attachment.FileData);
                }

                Response response = client.SendEmailAsync(msg).Result;
                string test = response.Body.ReadAsStringAsync().Result;

                System.Diagnostics.Trace.TraceError("SendGrid response body");
                System.Diagnostics.Trace.TraceError(test);

                bool status = response.StatusCode == HttpStatusCode.Accepted;

                if (!status)
                {
                    // Email failed to send to sendgrid
                    return false;
                }

                // Send grid worked - whether we record it or not!
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public bool SendCommunication(Sender from, Recipient[] to, Models.EmailAddress[] bcc, string subject, string message, string htmlMessage, Attachment attachment)
        {
            try
            {
                SendGridClient client = new SendGridClient(Configuration.ApiKey);
                SendGridMessage msg = new SendGridMessage
                {
                    From = new EmailAddress(from.Email),
                    Subject = subject
                };

                if (!string.IsNullOrWhiteSpace(from.Name))
                {
                    msg.From.Name = from.Name;
                }

                if (!string.IsNullOrWhiteSpace(message))
                {
                    msg.PlainTextContent = message;
                }

                if (!string.IsNullOrWhiteSpace(htmlMessage))
                {
                    msg.HtmlContent = htmlMessage;
                }

                IEnumerable<Recipient> emailAddress = to.Distinct();

                foreach (Recipient recipient in emailAddress)
                {
                    if (string.IsNullOrWhiteSpace(recipient.Name))
                    {
                        msg.AddTo(recipient.Email);
                    }
                    else
                    {
                        msg.AddTo(recipient.Email, recipient.Name);
                    }
                }

                foreach (string email in bcc)
                {
                    if (string.IsNullOrWhiteSpace(email))
                    {
                        continue;
                    }

                    msg.AddBcc(email);
                }

                if (attachment != Attachment.Empty)
                {
                    msg.AddAttachment(attachment.Filename, attachment.FileData);
                }

                Response response = client.SendEmailAsync(msg).Result;
                string test = response.Body.ReadAsStringAsync().Result;

                System.Diagnostics.Trace.TraceError("SendGrid response body");
                System.Diagnostics.Trace.TraceError(test);

                bool status = response.StatusCode == HttpStatusCode.Accepted;

                if (!status)
                {
                    // Email failed to send to sendgrid
                    System.Diagnostics.Trace.TraceError("Unable to send a email via sendgrid");
                    return false;
                }

                // Send grid worked - whether we record it or not!
                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("Unable to send a email via sendgrid");
                System.Diagnostics.Trace.TraceError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public async Task<bool> SendCommunicationAsync(Sender from, Recipient to, Models.EmailAddress[] bcc, string subject, string message, string htmlMessage, Attachment attachment)
        {
            try
            {
                SendGridClient client = new SendGridClient(Configuration.ApiKey);
                SendGridMessage msg = new SendGridMessage
                {
                    From = new EmailAddress(from.Email),
                    Subject = subject
                };

                if (!string.IsNullOrWhiteSpace(from.Name))
                {
                    msg.From.Name = from.Name;
                }

                if (string.IsNullOrWhiteSpace(to.Name))
                {
                    msg.AddTo(to.Email);
                }
                else
                {
                    msg.AddTo(to.Email, to.Name);
                }

                foreach (Models.EmailAddress email in bcc)
                { 
                    if (string.IsNullOrWhiteSpace(email))
                    {
                        continue;
                    }

                    msg.AddBcc(email);
                }

                if (attachment != Attachment.Empty)
                {
                    msg.AddAttachment(attachment.Filename, attachment.FileData);
                }

                Response response = client.SendEmailAsync(msg).Result;
                string test = await response.Body.ReadAsStringAsync();

                System.Diagnostics.Trace.TraceError("SendGrid response body");
                System.Diagnostics.Trace.TraceError(test);

                bool status = response.StatusCode == HttpStatusCode.Accepted;

                if (!status)
                {
                    // Email failed to send to sendgrid
                    return false;
                }

                // Send grid worked - whether we record it or not!
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public async Task<bool> SendCommunicationAsync(Sender from, Recipient[] to, Models.EmailAddress[] bcc, string subject, string message, string htmlMessage, Attachment attachment)
        {
            try
            {
                SendGridClient client = new SendGridClient(Configuration.ApiKey);
                SendGridMessage msg = new SendGridMessage
                {
                    From = new EmailAddress(from.Email),
                    Subject = subject
                };

                if (!string.IsNullOrWhiteSpace(from.Name))
                {
                    msg.From.Name = from.Name;
                }

                if (!string.IsNullOrWhiteSpace(message))
                {
                    msg.PlainTextContent = message;
                }

                if (!string.IsNullOrWhiteSpace(htmlMessage))
                {
                    msg.HtmlContent = htmlMessage;
                }

                IEnumerable<Recipient> emailAddress = to.Distinct();

                foreach (Recipient recipient in emailAddress)
                {
                    if (string.IsNullOrWhiteSpace(recipient.Name))
                    {
                        msg.AddTo(recipient.Email);
                    }
                    else
                    {
                        msg.AddTo(recipient.Email, recipient.Name);
                    }
                }

                foreach (string email in bcc)
                {
                    if (string.IsNullOrWhiteSpace(email))
                    {
                        continue;
                    }

                    msg.AddBcc(email);
                }

                if (attachment != Attachment.Empty)
                {
                    msg.AddAttachment(attachment.Filename, attachment.FileData);
                }

                Response response = await client.SendEmailAsync(msg);
                string test = await response.Body.ReadAsStringAsync();

                System.Diagnostics.Trace.TraceError("SendGrid response body");
                System.Diagnostics.Trace.TraceError(test);

                bool status = response.StatusCode == HttpStatusCode.Accepted;

                if (!status)
                {
                    // Email failed to send to sendgrid
                    System.Diagnostics.Trace.TraceError("Unable to send a email via sendgrid");
                    return false;
                }

                // Send grid worked - whether we record it or not!
                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("Unable to send a email via sendgrid");
                System.Diagnostics.Trace.TraceError(ex.ToString());
                return false;
            }
        }
    }
}
//-----------------------------------------------------------------------
// <copyright file="CommunicationService.cs" company="Code Miners Limited">
//  Copyright (c) 2019 Code Miners Limited
//   
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//  
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU Lesser General Public License for more details.
//  
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.If not, see<https://www.gnu.org/licenses/>.
// </copyright>
//-----------------------------------------------------------------------

namespace Core.Modules.Communications.Sendgrid
{
    using System;
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
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public bool SendCommunication(Sender from, Recipient to, string subject, string message, string htmlMessage, Attachment attachment)
        {
            return SendCommunication(
                from, to, subject, message, htmlMessage, new Recipient[0], new Recipient[0], attachment
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public bool SendCommunication(Sender from, Recipient to, string subject, string message, string htmlMessage, Recipient[] cc, Attachment attachment)
        {
            return SendCommunication(
                from, to, subject, message, htmlMessage, cc, new Recipient[0], attachment
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public bool SendCommunication(Sender from, Recipient to, string subject, string message, string htmlMessage, Recipient[] cc, Recipient[] bcc, Attachment attachment)
        {
            bool result = SendCommunicationAsync(
                from,
                to,
                subject,
                message,
                htmlMessage,
                cc,
                bcc,
                attachment
            ).Result;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public async Task<bool> SendCommunicationAsync(Sender from, Recipient to, string subject, string message, string htmlMessage, Attachment attachment)
        {
            return await SendCommunicationAsync(
                from, to, subject, message, htmlMessage, new Recipient[0], new Recipient[0], attachment
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public async Task<bool> SendCommunicationAsync(Sender from, Recipient to, string subject, string message, string htmlMessage, Recipient[] cc, Attachment attachment)
        {
            return await SendCommunicationAsync(
                from, to, subject, message, htmlMessage, cc, new Recipient[0], attachment
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public async Task<bool> SendCommunicationAsync(Sender from, Recipient to, string subject, string message, string htmlMessage, Recipient[] cc, Recipient[] bcc, Attachment attachment)
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

                AddEmailBody(message, htmlMessage, msg);

                AddCcRecipients(cc, msg);

                AddBccRecipients(bcc, msg);

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

        private static void AddEmailBody(string message, string htmlMessage, SendGridMessage msg)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                msg.PlainTextContent = message;
            }

            if (!string.IsNullOrWhiteSpace(htmlMessage))
            {
                msg.HtmlContent = htmlMessage;
            }
        }

        private static void AddCcRecipients(Recipient[] cc, SendGridMessage msg)
        {
            foreach (Recipient recipient in cc)
            {
                if (string.IsNullOrWhiteSpace(recipient?.Email))
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(recipient.Name))
                {
                    msg.AddCc(recipient.Email);
                }
                else
                {
                    msg.AddCc(recipient.Email, recipient.Name);
                }
            }
        }

        private static void AddBccRecipients(Recipient[] bcc, SendGridMessage msg)
        {
            foreach (Recipient recipient in bcc)
            {
                if (string.IsNullOrWhiteSpace(recipient?.Email))
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(recipient.Name))
                {
                    msg.AddBcc(recipient.Email);
                }
                else
                {
                    msg.AddBcc(recipient.Email, recipient.Name);
                }
            }
        }
    }
}
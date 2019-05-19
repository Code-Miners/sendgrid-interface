//-----------------------------------------------------------------------
// <copyright file="ICommunicationService.cs" company="Code Miners Limited">
//     Copyright (c) 2019
// </copyright>
//-----------------------------------------------------------------------

namespace Core.Modules.Communications.Sendgrid
{
    using System.Threading.Tasks;
    using Models;

    public interface ICommunicationService
    {
        /// <summary>
        /// Sends a communication asynchronously
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        bool SendCommunication(Sender from, Recipient to, EmailAddress[] bcc, string subject, string message, string htmlMessage, Attachment attachment);
        
        /// <summary>
        /// Sends a communication asynchronously
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        bool SendCommunication(Sender from, Recipient[] to, EmailAddress[] bcc, string subject, string message, string htmlMessage, Attachment attachment);
        
        /// <summary>
        /// Sends a communication asynchronously
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        Task<bool> SendCommunicationAsync(Sender from, Recipient to, EmailAddress[] bcc, string subject, string message, string htmlMessage, Attachment attachment);
        
        /// <summary>
        /// Sends a communication asynchronously
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        Task<bool> SendCommunicationAsync(Sender from, Recipient[] to, EmailAddress[] bcc, string subject, string message, string htmlMessage, Attachment attachment);
    }
}

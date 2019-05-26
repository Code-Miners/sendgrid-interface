//-----------------------------------------------------------------------
// <copyright file="ICommunicationService.cs" company="Code Miners Limited">
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
    using System.Threading.Tasks;
    using Models;

    public interface ICommunicationService
    {
        /// <summary>
        /// Sends a communication synchronously
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        bool SendCommunication(Sender from, Recipient to, string subject, string message, string htmlMessage, Attachment attachment);

        /// <summary>
        /// Sends a communication synchronously. Supports cc. 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        bool SendCommunication(Sender from, Recipient to, string subject, string message, string htmlMessage, Recipient[] cc, Attachment attachment);

        /// <summary>
        /// Sends a communication synchronously. Supports cc and bcc. 
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
        bool SendCommunication(Sender from, Recipient to, string subject, string message, string htmlMessage, Recipient[] cc, Recipient[] bcc, Attachment attachment);

        /// <summary>
        /// Sends a communication synchronously
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        Task<bool> SendCommunicationAsync(Sender from, Recipient to, string subject, string message, string htmlMessage, Attachment attachment);

        /// <summary>
        /// Sends a communication synchronously. Supports cc. 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        Task<bool> SendCommunicationAsync(Sender from, Recipient to, string subject, string message, string htmlMessage, Recipient[] cc, Attachment attachment);

        /// <summary>
        /// Sends a communication synchronously. Supports cc and bcc. 
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
        Task<bool> SendCommunicationAsync(Sender from, Recipient to, string subject, string message, string htmlMessage, Recipient[] cc, Recipient[] bcc, Attachment attachment);
    }
}

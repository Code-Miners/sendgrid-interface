//-----------------------------------------------------------------------
// <copyright file="SynchronousEmailTests.cs" company="Code Miners Limited">
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

namespace IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using Core.Modules.Communications.Sendgrid;
    using Core.Modules.Communications.Sendgrid.Models;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SynchronousEmailTests
    {
        [Test]
        [Category("Integration")]
        public void SendSimpleEmailTest()
        {
            ICommunicationService communicationService = new CommunicationService(
                new AppSettingsConfiguration()    
            );

            bool ok = communicationService.SendCommunication(
                new Sender("redacted..."), 
                new Recipient("redacted...", "redacted..."),
                "Test email",
                "Plain text message",
                "<b>Html message</b>",
                Attachment.Empty
            );

            Assert.IsTrue(ok, "The service should have sent an email!");
        }

        [Test]
        [Category("Integration")]
        public void SendSimpleEmailWithCcTest()
        {
            ICommunicationService communicationService = new CommunicationService(
                new AppSettingsConfiguration()
            );

            bool ok = communicationService.SendCommunication(
                new Sender("redacted..."),
                new Recipient("redacted...", "redacted..."),
                "Test email",
                "Plain text message",
                "<b>Html message</b>",
                new[] { new Recipient("redacted...") },
                Attachment.Empty
            );

            Assert.IsTrue(ok, "The service should have sent an email!");
        }

        [Test]
        [Category("Integration")]
        public void SendSimpleEmailWithCcAndBccTest()
        {
            ICommunicationService communicationService = new CommunicationService(
                new AppSettingsConfiguration()
            );

            bool ok = communicationService.SendCommunication(
                new Sender("redacted..."),
                new Recipient("redacted...", "redacted..."),
                "Test email",
                "Plain text message",
                "<b>Html message</b>",
                new[] { new Recipient("redacted...") },
                new[] { new Recipient("redacted...") },
                Attachment.Empty
            );

            Assert.IsTrue(ok, "The service should have sent an email!");
        }
    }
}

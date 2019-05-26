//-----------------------------------------------------------------------
// <copyright file="SenderModelTests.cs" company="Code Miners Limited">
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

namespace LibraryTests
{
    using System.Diagnostics.CodeAnalysis;
    using Core.Modules.Communications.Sendgrid.Models;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SenderModelTests
    {
        [Test]
        public void InitialisationTest()
        {
            Sender sender = new Sender("Firstname", "recipient@example.com");

            Assert.AreEqual("Firstname", sender.Name, "Name property not set properly");
            Assert.AreEqual("recipient@example.com", sender.Email.ToString(), "Email property not set properly");
        }

        [Test]
        public void InitialisationWithNoNameTest()
        {
            Sender sender = new Sender("recipient@example.com");
            Assert.AreEqual("recipient@example.com", sender.Email.ToString(), "Email property not set properly");
        }
    }
}

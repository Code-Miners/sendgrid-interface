//-----------------------------------------------------------------------
// <copyright file="AttachmentModelTests.cs" company="Code Miners Limited">
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
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using Core.Modules.Communications.Sendgrid.Models;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AttachmentModelTests
    {
        [Test]
        public void EmptyModelInitialisationTest()
        {
            Attachment att = Attachment.Empty;

            Attachment att2 = new Attachment(string.Empty, string.Empty);

            Assert.IsTrue(string.IsNullOrWhiteSpace(att.FileData));
            Assert.IsTrue(string.IsNullOrWhiteSpace(att.Filename));
            Assert.AreEqual(att, att2);
        }

        [Test]
        public void EmptyModelEquivalencyTest()
        {
            Attachment att = Attachment.Empty;

            Attachment att2 = Attachment.Empty;

            Assert.AreEqual(att, att2);
        }

        [Test]
        public void IsNullOrEmptyTest()
        {
            Attachment att = Attachment.Empty;
            Attachment att2 = new Attachment(
                "test.txt",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("testdata"))
            );

            Assert.IsTrue(Attachment.IsNullOrEmpty(att));
            Assert.IsFalse(Attachment.IsNullOrEmpty(att2));
        }
    }
}

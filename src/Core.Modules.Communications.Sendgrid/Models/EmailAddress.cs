//-----------------------------------------------------------------------
// <copyright file="EmailAddress.cs" company="Code Miners Limited">
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

namespace Core.Modules.Communications.Sendgrid.Models
{
    using System;

    /// <summary>
    /// Represents an email address as an immutable value 
    /// </summary>
    [Serializable]
    public sealed class EmailAddress : IEquatable<EmailAddress>
    {
        private readonly bool empty;

        /// <summary>
        /// The underlying email address value
        /// </summary>
        private readonly string value;

        /// <summary>
        /// Define EmailAddress.Empty
        /// </summary>
        public static EmailAddress Empty => new EmailAddress();

        /// <summary>
        /// default constructor - sets value to emailaddress.empty
        /// </summary>
        private EmailAddress()
        {
            value = string.Empty;
            empty = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddress"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public EmailAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid value for email address", nameof(value));
            }

            this.value = value;
        }

        /// <summary>
        /// Attempts to build a new emailaddress instance by testing and using the candidate emailaddress. If this
        /// is invalid then the emailaddress instance is Empty and the method returns false
        /// </summary>
        /// <param name="candidate">The candidate email address</param>
        /// <param name="emailAddress">The emailaddress instance</param>
        /// <returns>
        /// Flag indicating successful parse or not
        /// </returns>
        public static bool TryParse(string candidate, out EmailAddress emailAddress)
        {
            if (string.IsNullOrWhiteSpace(candidate))
            {
                emailAddress = Empty;
                return false;
            }

            emailAddress = new EmailAddress(candidate.Trim());
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(EmailAddress emailAddress)
        {
            if (emailAddress == null)
            {
                return true;
            }

            return emailAddress.empty;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="EmailAddress"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="emailAddress">The email address</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator string(EmailAddress emailAddress)
        {
            return emailAddress.value;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>The string representation</returns>
        public override string ToString()
        {
            return value;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(EmailAddress other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return value.Equals(other.value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            EmailAddress b = obj as EmailAddress;
            if (ReferenceEquals(b, null))
            {
                return false;
            }

            return Equals(b);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static bool operator ==(EmailAddress a, EmailAddress b)
        {
            if (ReferenceEquals(a, null))
            {
                return ReferenceEquals(b, null);
            }

            return a.Equals(b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(EmailAddress a, EmailAddress b)
        {
            return !(a == b);
        }
    }
}

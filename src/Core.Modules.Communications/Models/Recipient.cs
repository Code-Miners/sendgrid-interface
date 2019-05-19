//-----------------------------------------------------------------------
// <copyright file="Recipient.cs" company="Code Miners Limited">
//     Copyright (c) 2019
// </copyright>
//-----------------------------------------------------------------------

namespace Core.Modules.Communications.Sendgrid.Models
{
    public class Recipient
    {
        public string Name { get; }

        public EmailAddress Email { get; }

        public Recipient(string email)
        {
            Name = string.Empty;
            Email = new EmailAddress(email);
        }

        public Recipient(string name, string email)
        {
            Name = name;
            Email = new EmailAddress(email);
        }
    }
}
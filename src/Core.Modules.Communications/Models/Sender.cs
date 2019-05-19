//-----------------------------------------------------------------------
// <copyright file="Sender.cs" company="Code Miners Limited">
//     Copyright (c) 2019
// </copyright>
//-----------------------------------------------------------------------

namespace Core.Modules.Communications.Sendgrid.Models
{
    public class Sender
    {
        public string Name { get; }

        public EmailAddress Email { get; }

        public Sender(string email)
        {
            Name = string.Empty;
            Email = new EmailAddress(email);
        }

        public Sender(string name, string email)
        {
            Name = name;
            Email = new EmailAddress(email);
        }
    }
}

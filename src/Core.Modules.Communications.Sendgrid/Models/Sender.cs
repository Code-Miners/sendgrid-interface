//-----------------------------------------------------------------------
// <copyright file="Sender.cs" company="Code Miners Limited">
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

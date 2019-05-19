//-----------------------------------------------------------------------
// <copyright file="CommunicationConfiguration.cs" company="Code Miners Limited">
//     Copyright (c) 2019
// </copyright>
//-----------------------------------------------------------------------

namespace Core.Modules.Communications.Sendgrid
{
    using System.Configuration;

    public class CommunicationConfiguration : ICommunicationConfiguration
    {
        public string ApiKey => ConfigurationManager.AppSettings["CodeMiners:Modules:SendGrid:ApiKey"];
    }
}

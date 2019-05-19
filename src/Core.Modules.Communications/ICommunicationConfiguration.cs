//-----------------------------------------------------------------------
// <copyright file="ICommunicationConfiguration.cs" company="Code Miners Limited">
//     Copyright (c) 2019
// </copyright>
//-----------------------------------------------------------------------

namespace Core.Modules.Communications.Sendgrid
{
    public interface ICommunicationConfiguration
    {
        string ApiKey { get; }
    }
}
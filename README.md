#  Codeminers Libraries: Sendgrid Interface

This library is an interface over Sendgrid that in turn makes use of an open source library for calling their system. 

This library is copyright Code Miners Limited and is provided as an accelerator to existing and new customers 
as part of ongoing project work.

No liability is assumed or implied. All bug fixes are handled internally and are not billable to the client(s).

## Setup and configuration

The module installs as a Nuget package from the company Nuget repo. To configure, the following key needs to be 
added to the application app settings.

> CodeMiners:Modules:SendGrid:ApiKey


If you don't want to use appsettings, then make your own class that implements 

> Core.Modules.Communications.Sendgrid.ICommunicationConfiguration 

and register with the DI container for the project. Customisations like this do not belong in this module unless 
they are sufficiently generic (and are not billable to the client).

:rocket:

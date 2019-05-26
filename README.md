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

## Roadmap

Right now we don't have a .NET Core version of this library but that's in the pipeline. A lot of the work we do use
platforms and systems where .NET Core isn't available. That said, here's what we're thinking about:

* Embedding images
* Better use of immutable types
* .NET Core


## Where this code has come from

In developing our website we were throwing some code together and decided we'd start releasing it in case someone found 
it useful. So we've repackaged our code into 'modules', adding in Sonar settings and tests then released them into
the wild.

If this code is of use to you, great! If not, no problem, there's a fancy search feature top left of this page. Happy 
hunting.

:rocket:

# EmailRep.NET
Small .NET client to access emailrep.io

![.NET Core](https://github.com/WestDiscGolf/EmailRep.NET/workflows/.NET%20Core/badge.svg) 

# Quick Start

## Package Installation
To install the main nuget pacakge from NuGet.

dotnet cli 
```
dotnet add package EmailRep.NET
```

NuGet Package Manager
```
Install-Package EmailRep.NET
```

## Basic Setup
```
var client = new HttpClient();
var settings = new EmailRep.NET.EmailRepClientSettings();
settings.UserAgent = "consoleapp/test";
settings.ApiKey = "**** insert api key here ****";

var emailRepClient = new EmailRep.NET.EmailRepClient(client, settings);
try
{
    var response = await emailRepClient.QueryEmailAsync("bill@microsoft.com");
    Console.WriteLine($"Name: {response.Email} ({response.Reputation}).");
}
catch (EmailRepException e)
{
    Console.WriteLine(e);
}
```

1) Create a new `HttpClient`
   >Recommendation: get access to a HttpClient instance through dependency injection.
2) Create a new settings instance. Set the applicable `UserAgent` and `ApiKey` through settings.
   >Recommendation: use `IConfiguration` and loading the values through configuration in production applications.
3) Create a new `EmailRepClient`.
4) Make a request.
5) Done.

## Basic Setup - Alternative
You can also setup the `HttpClient` manually if you want.

```
var client = new HttpClient();
client.DefaultRequestHeaders.UserAgent.TryParseAdd("consoleapp/test");
client.DefaultRequestHeaders.Add("Key", "****** insert api key here ******");
client.BaseAddress = new Uri("https://emailrep.io/");
var emailRepClient = new EmailRepClient(client);

var response1 = await emailRepClient.QueryEmailAsync("bill@microsoft.com");
```

## ASP.NET Core
To register the client in an ASP.NET Core application the strongly typed, HttpClient based, EmailRep.NET client has to be registered using the `AddHttpClient` extension method in the `ConfigureServices` registration method. The settings are loaded from configuration using then `IConfiguration` loaded.
```
var settings = new EmailRepClientSettings();
configuration.GetSection(sectionName).Bind(settings);
services.AddSingleton(settings);

services.AddHttpClient<IEmailRepClient, EmailRepClient>();
```

## ASP.NET Core - Alternative
You can register and configure the HttpClient settings manually yourself if you want to by registering the strongly typed client using the `AddHttpClient` extension method and configuring the HttpClient instance through the delegate exposed in the registration.
```
var settings = configuration.GetSection(sectionName).Get<EmailRepClientSettings>();

services.AddHttpClient<IEmailRepClient, EmailRepClient>(c =>
{
    c.BaseAddress = new Uri(settings.BaseUrl);
    c.DefaultRequestHeaders.UserAgent.ParseAdd(settings.UserAgent);
    c.DefaultRequestHeaders.Add("Key", settings.ApiKey);
});
```

# EmailRep.NET.Extensions.DependencyInjection

If you want an easier life then there is also an extensions package which will do the above for you. This will configure and register an instance of the `EmailRepClientSettings` class and register the `IEmailRepClient` with the HttpClient factory package.

This can be installed from NuGet.org.

dotnet cli 
```
dotnet add package EmailRep.NET.Extensions.DependencyInjection
```

NuGet Package Manager
```
Install-Package EmailRep.NET.Extensions.DependencyInjection
```


This registration defaults to using the "EmailRepNet" configuration section name however can be overridden on usage.

# Goals of the Library
The few goals I had for this project when I set out.

1. Learn
2. Play
3. Make a clean API which is easy to use
4. Have fun

They continue to be the how decisions will be made moving forward.

Any issues, questions or comments then please log a issue in this repo or contact @WestDiscGolf on twitter.
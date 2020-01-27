# EmailRep.NET
Small .NET client to access emailrep.io

# Quick Start

Reference the nuget package
**todo load in package**


## Console Application
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

1) Create a new `HttpClient`.
2) Create a new settings instance. Set the applicable `UserAgent` and `ApiKey` through settings. I would recommend using `IConfiguration` and loading the values through configuration in production applications.
3) Create a new `EmailRepClient`.
4) Make a request.
5) Done.

## Console Application - Alternative

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

1) File > New WebApplication
2) Register the client in `ConfigureServices`

```
var settings = configuration.GetSection(sectionName).Get<EmailRepClientSettings>();

services.AddHttpClient<IEmailRepClient, EmailRepClient>(c =>
{
    c.BaseAddress = new Uri(settings.BaseUrl);
    c.DefaultRequestHeaders.UserAgent.ParseAdd(settings.UserAgent);
    c.DefaultRequestHeaders.Add("Key", settings.ApiKey);
});
```

## ASP.NET Core - Alternative
```
var settings = new EmailRepClientSettings();
configuration.GetSection(sectionName).Bind(settings);
services.AddSingleton(settings);

services.AddHttpClient<IEmailRepClient, EmailRepClient>();
```

## ASP.NET Core - Alternative #2
**todo packages to load**


# Goals of the Library
The few goals I have for this project.

1. Learn
2. Play
3. Make a clean API which is easy to use
4. Have fun
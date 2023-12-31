# Munch Template Projects

## Features

This is a common template for most .NET Core Projects that may come along

## Components

- ASP.NET Core Identity
- IdentityServer4
- Serilog
- EFCore
- Sendgrid
- CsvHelper

## Startup

1. Right click solution and chose `Set Startup Projects...`
2. Choose option `Multiple Startup Projects`
3. Select `TemplateApi`, `TemplateIdentityServer`, and `TemplateJsClient`
4. In Visual Studio `Start` the application(s)

## Logging In

Admin user is setup automatically, the username is `admin` and password is `ASDFasdf!`

## Postman Setup

Getting a token looks like this:

	POST /connect/token HTTP/1.1
	Host: localhost:44319
	Content-Type: application/x-www-form-urlencoded
	Content-Length: 112

	client_secret=secret&scope=openid%20api1&grant_type=password&username=admin&password=ASDFasdf!&client_id=postman

## Creating Migrations

1. open `Package Manager Console`
2. setup startup project to `TemplateBase` 
3. set default project to `TemplateBase`
4. run `add-migration [Migration Name] -o "Common/Data/Migrations"`
5. double check to make sure the migration is correct


## Executing Migrations

1. open `Package Manager Console`
2. setup startup project to `TemplateBase` 
3. set default project to `TemplateBase`
4. run `update-database` to update your local database

## Basic Rules

1. Services don't reference other services (to avoid circular dependency)
2. Managers can reference as many services as neeeded, and can reference other managers
3. Repositories are generic but can be customized with extension methods
4. Entity classes shouldn't contain any logic unless it's part of a computed column
5. If entity class needs logic, write an extension method
6. Dtos types: ViewModels, Form, Info, etc
7. 2 types of Dto, Basic, Composite
8. Basic typically dtos don't have constructor, have mapping with automapper
9. Use inheritance with AutoMapper using .IncludeAllDerived() between mappings
10. Composite Dtos get hydrated from other basic dtos.
11. Service methods never return entities
12. Entities and Dtos can coordinate properties with interface (See IProvider)



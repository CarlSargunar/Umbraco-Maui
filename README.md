# Umbraco-Maui

This repo is a companion to my talk at the Umbraco UK festival 2023, and shows how to use Umbraco and .NET MAUI together to build a cross-platform app which will load content from the Umbraco content Delivery API.

## Abstract

In this session I'll be using the latest Umbraco Content delivery API with a cross platform app built with .NET MAUI to showcase how content delivered headlessly can be consumed by a mobile app on windows, iOs and MacOs as well as Android.

We'll also look at the key differences between REST vs GraphQL, and some of the strengths and weakenesses of both, like Overfetching/Underfetching, Flexibility vs Complexity and performance considerations.

## Setup

Follow these instructions to set up a site

### Umbraco

To install a new Umbraco site, you can use the following commands in your terminal:

    # Ensure we have the latest Umbraco templates
    dotnet new -i Umbraco.Templates::12.2.0

    dotnet new umbraco --force -n "UmbracoCMS" --friendly-name "Administrator" --email "admin@example.com" --password "1234567890" --development-database-type SQLite

    #Add starter kit
    dotnet add "UmbracoCMS" package Umbraco.TheStarterKit

    dotnet run --project "UmbracoCMS"
    #Running

Once the site is running, you need to stop it and enable the Content Delivery API - more info [here](https://docs.umbraco.com/umbraco-cms/reference/content-delivery-api)


The main change is to add the following section to the appsettings.json file:

    "DeliveryApi": {
            "Enabled": true,
            "PublicAccess": true,
            "RichTextOutputAsJson": false
        }

The API also exposes a Swagger endpoint, which you can use to explore the API and test queries - this can be accessed from the URL /umbraco/swagger/. Don't forget to select the *Umbraco Content Delivery API* from the dropdown. 

## Get Products

To load products from the API, use the following query:

    https://localhost:44356/umbraco/delivery/api/v1/content?filter=contentType%3Aproduct&skip=0&take=10

The "production" (demo) URL iis 

    https://maui.carlcod.es/umbraco/delivery/api/v1/content?filter=contentType%3Aproduct

Note - the filter query needs to be encoded, so `contentType:product` becomes `contentType%3Aproduct`

# References

## Umbraco

- Umbraco Content Delivery API - https://our.umbraco.com/documentation/Umbraco-Net/Headless/Content-Delivery-API/

## .NET MAUI

- https://devblogs.microsoft.com/dotnet/introducing-net-multi-platform-app-ui/
- MVVM Community Toolkit - https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/


## My notes and other gibberish

- https://github.com/lauraneto/Umbraco.Headless.Blazor
- https://www.youtube.com/watch?v=G4czmfYXqIs

- https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/rest
- https://www.moesif.com/blog/technical/graphql/REST-vs-GraphQL-APIs-the-good-the-bad-the-ugly/ 


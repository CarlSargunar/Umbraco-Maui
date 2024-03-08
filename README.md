# Umbraco-Maui

This repo is a companion to my talk at the Umbraco UK festival 2023, and shows how to use Umbraco and .NET MAUI together to build a cross-platform app which will load content from the Umbraco content Delivery API.

Slides are available : [Slides.pptx](Slides.pptx)

## Abstract

In this session I'll be using the latest Umbraco Content delivery API with a cross platform app built with .NET MAUI to showcase how content delivered headlessly can be consumed by a mobile app on windows, iOs and MacOs as well as Android.

We'll also look at the key differences between REST vs GraphQL, and some of the strengths and weakenesses of both, like Overfetching/Underfetching, Flexibility vs Complexity and performance considerations.

## Setup

Follow these instructions to set up a site

### Umbraco

To install a new Umbraco site, you can use the following commands in your terminal:

    # Ensure we have the latest Umbraco templates
    dotnet new install Umbraco.Templates --force

    # Create solution/project
    dotnet new sln --name "MyCMS"
    dotnet new umbraco --force -n "MyCMS" --friendly-name "Administrator" --email "admin@example.com" --password '1234567890' --development-database-type SQLite
    dotnet sln add "MyCMS"

    #Add starter kit
    dotnet add "MyCMS" package Umbraco.TheStarterKit

    dotnet run --project "MyCMS"
    #Running

Once the site is running, you need to stop it and enable the Content Delivery API - more info [here](https://docs.umbraco.com/umbraco-cms/reference/content-delivery-api)


The main change is to add the following section to the appsettings.json file:

    "DeliveryApi": {
            "Enabled": true,
            "PublicAccess": true,
            "RichTextOutputAsJson": false
        }

The API also exposes a Swagger endpoint, which you can use to explore the API and test queries - this can be accessed from the URL /umbraco/swagger/. Don't forget to select the *Umbraco Content Delivery API* from the dropdown. 

## Get Products - Content Delivery API

To load data from the content delivery API, you can use the following queries.

   https://localhost:44331/umbraco/delivery/api/v2/content?filter=contentType%3Aproduct

Note - the filter query needs to be encoded, i.e. `contentType:product` becomes `contentType%3Aproduct`

The content response data structure is generic, shown below

    {
        "name": "string",
        "createDate": "2023-06-23T11:31:07.281Z",
        "updateDate": "2023-06-23T11:31:07.281Z",
        "route": {
            "path": "string",
            "startItem": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "path": "string"
            }
        },
        "id": "11fb598b-5c51-4d1a-8f2e-0c7594361d15",
        "contentType": "string",
        "properties": {
            "property1Alias": "string",
            "property2Alias": 0,
            "property3Alias": true,
            "property4Alias": [],
            "property5Alias": {},
            "property6Alias": null
        },
        "cultures": {
            "cultureIsoCode1": {
            "path": "string",
            "startItem": {
                "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                "path": "string"
            }
            },
            "cultureIsoCode2": {
            "path": "string",
            "startItem": {
                "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                "path": "string"
            }
            }
        }
    }

## Notifications

Notifications are handled using the Plugin.LocalNotification nuget package. For Android, you need to set the following permissions. Open the Platforms/Android/AndroidManifest.xml file and add the following in the manifest node:

    <uses-permission android:name="android.permission.WAKE_LOCK" />

    <!--Required so that the plugin can reschedule notifications upon a reboot-->
    <uses-permission android:name="android.permission.RECEIVE_BOOT_COMPLETED" />
    <uses-permission android:name="android.permission.VIBRATE" />
    <uses-permission android:name="android.permission.POST_NOTIFICATIONS" />

    optional
    <uses-permission android:name="android.permission.USE_EXACT_ALARM" />
    <uses-permission android:name="android.permission.SCHEDULE_EXACT_ALARM" />


# References

## Umbraco

- Umbraco Content Delivery API - https://our.umbraco.com/documentation/Umbraco-Net/Headless/Content-Delivery-API/
- GraphQL package for Umbraco - https://marketplace.umbraco.com/package/our.umbraco.graphql
- GraphQL for Umbraco Heartcore - https://docs.umbraco.com/umbraco-heartcore/tutorials/querying-with-graphql

## .NET MAUI

- https://devblogs.microsoft.com/dotnet/introducing-net-multi-platform-app-ui/
- MVVM Community Toolkit - https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/
- https://www.youtube.com/watch?v=kJ8OHxe1ZNw

## Local Push Notifications

- https://github.com/thudugala/Plugin.LocalNotification
    - https://github.com/thudugala/Plugin.LocalNotification/wiki/1.-Usage-10.0.0--.Net-MAUI



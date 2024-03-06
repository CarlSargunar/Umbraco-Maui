# Umbraco-Maui

This repo is a companion to my talk at the Umbraco Spark 2024, and shows how to use Umbraco and .NET MAUI together to build a cross-platform app which will load content from the Umbraco content Delivery API.

Slides are available : [Slides.pptx](Slides.pptx)

## Abstract

In this session I'll be using the latest Umbraco Content delivery API with a cross platform app built with .NET MAUI to showcase how content delivered headlessly can be consumed by a mobile app on windows, iOs and MacOs as well as Android.

### Umbraco

To run this demo, clone the repo and in a terminal window, run the following from within the src folder

    # Ensure your terminal is in the Src folder
    dotnet run --project "MyCMS"

The main change is to add the following section to the appsettings.json file Under the Umbraco -> CMS section:

    "DeliveryApi": {
            "Enabled": true,
            "PublicAccess": true,
            "RichTextOutputAsJson": false
        }

The API also exposes a Swagger endpoint, which you can use to explore the API and test queries - this can be accessed from the URL /umbraco/swagger/. Don't forget to select the *Umbraco Content Delivery API* from the dropdown. 

## Get Products - Content Delivery API

To load data from the content delivery API, you can use the following queries.

    - Swagger endpoint : https://localhost:44316/umbraco/swagger/index.html?urls.primaryName=Umbraco%20Delivery%20API
    - Articles : https://localhost:44316/umbraco/delivery/api/v2/content?filter=contentType%3Aarticle&skip=0&take=10&fields=properties%5B%24all%5D
    - Podcasts : https://localhost:44316/umbraco/delivery/api/v2/content?filter=contentType%3Apodcast&skip=0&take=10&fields=properties%5B%24all%5D

Note - the filter query needs to be encoded, e.g. `contentType:product` becomes `contentType%3Aproduct`

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


# References

## Umbraco

- Umbraco Content Delivery API - https://our.umbraco.com/documentation/Umbraco-Net/Headless/Content-Delivery-API/
- GraphQL package for Umbraco - https://marketplace.umbraco.com/package/our.umbraco.graphql
- GraphQL for Umbraco Heartcore - https://docs.umbraco.com/umbraco-heartcore/tutorials/querying-with-graphql

## .NET MAUI

- https://devblogs.microsoft.com/dotnet/introducing-net-multi-platform-app-ui/
- MVVM Community Toolkit - https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/

## Push Notifications

https://www.youtube.com/watch?v=7w2q2D6mR7g&list=PLfbOp004UaYXoq9NLvMqdGSyWeEr_w6fu
https://www.youtube.com/watch?v=gBbbctEvbOk



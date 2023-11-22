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

## Get Products - Content Delivery API

To load data from the content delivery API, you can use the following queries.

    https://maui.carlcod.es/umbraco/delivery/api/v1/content?filter=contentType%3Aproduct
    https://maui.carlcod.es/umbraco/delivery/api/v1/content?filter=contentType%3Ablogpost
    https://maui.carlcod.es/umbraco/delivery/api/v1/content?filter=contentType%3Aperson

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

## Get Products - Rest

For specific content types, you can use the following endpoints. Each endpoint has it's own response structure, which is tailored to the specific content type.

    https://maui.carlcod.es/umbraco/api/product/getallproducts
    https://maui.carlcod.es/umbraco/api/person/getallpeople
    https://maui.carlcod.es/umbraco/api/blog/getallblogposts


## Comparing API options

The table below compares GraphQL and REST (both generic and custom implementations) across various features:

| Feature / Aspect                         | GraphQL                                                | Content Delivery API - Generic REST API                                      | Custom REST API                                   |
|-------------------------------------------|--------------------------------------------------------|-------------------------------------------------------|---------------------------------------------------|
| **Data Fetching Efficiency**              | High; retrieves exactly what's needed.                 | Low; can lead to over-fetching or under-fetching.     | Moderate; tailored endpoints reduce over-fetching.|
| **Query Flexibility**                     | Highly flexible; clients can query for exactly what they need. | Limited; relies on endpoints defined by server.       | Moderate; specific needs addressed but less flexible than GraphQL. |
| **Over-fetching and Under-fetching**      | Minimized due to precise data fetching.                | Common in generic implementations.                    | Less common due to customized responses.           |
| **Versioning**                            | Typically versionless; changes managed through deprecations and additions. | Often requires versioning of API.                      | Often requires versioning of API.                  |
| **Learning Curve**                        | Steeper due to unique syntax and concepts.            | Simpler for beginners familiar with HTTP and JSON.    | Similar to generic REST but requires understanding of custom endpoints. |
| **Caching**                               | Complex due to varied queries; requires advanced strategies. | Simpler due to HTTP caching mechanisms.               | Simpler, benefits from HTTP caching.               |
| **API Discovery**                         | Introspective; self-documenting through schema.       | Requires external documentation.                      | Requires external documentation.                   |
| **Performance**                           | Can be optimized for performance but complex queries can be expensive. | Depends on implementation; can be optimized.          | Generally optimized for specific use cases.        |
| **Error Handling**                        | Returns both data and errors in the response.         | HTTP status codes commonly used for indicating errors. | Same as generic REST, uses HTTP status codes.       |
| **Network Requests**                      | Fewer requests due to aggregated queries.             | Multiple requests may be needed for complex data.     | Fewer requests if endpoints are tailored to needs.  |
| **Data Schema**                           | Strongly typed schema is mandatory.                   | Schema-less; structure defined by the backend.       | Schema-less but can follow a structured format for custom endpoints. |
| **Complexity for Multiple Resources**     | Handles complex queries for multiple resources easily. | Can get complicated and require multiple endpoints.   | Requires multiple custom endpoints.                |
| **Standardization**                       | Standardized query language.                          | No strict standard; follows HTTP and JSON conventions. | Custom standards based on the specific implementation. |
| **Security Considerations**               | Requires careful design to avoid exposing sensitive data or costly queries. | Security depends on implementation.                  | Security tailored to specific endpoints and use cases. |

This table gives a broad overview of how GraphQL and REST (both generic and custom) compare across various aspects. However, the actual implementation details can vary significantly depending on the specific use case and the design of the API.



# References

## Umbraco

- Umbraco Content Delivery API - https://our.umbraco.com/documentation/Umbraco-Net/Headless/Content-Delivery-API/
- GraphQL package for Umbraco - https://marketplace.umbraco.com/package/our.umbraco.graphql
- GraphQL for Umbraco Heartcore - https://docs.umbraco.com/umbraco-heartcore/tutorials/querying-with-graphql

## .NET MAUI

- https://devblogs.microsoft.com/dotnet/introducing-net-multi-platform-app-ui/
- MVVM Community Toolkit - https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/


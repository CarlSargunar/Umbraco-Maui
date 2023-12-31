# Comparing API options

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


# Start Project

Build Umbraco

    # Ensure we have the version specific Umbraco templates
    dotnet new install Umbraco.Templates::13.5.2 --force

    # Create solution/project
    dotnet new sln --name "MyWebsite"
    dotnet new umbraco --force -n "MyWebsite" --friendly-name "Administrator" --email "admin@example.com" --password "1234567890" --development-database-type SQLite
    dotnet sln add "MyWebsite"

    #Add starter kit
    dotnet add "MyWebsite" package Umbraco.TheStarterKit --version 13.0.0

    dotnet run --project "MyWebsite"
    #Running

## Enable Content Delivery API

Update the appsettings.json with the following

    "DeliveryApi": {
        "Enabled": true,
        "PublicAccess": true,
        "RichTextOutputAsJson": false
    },

You can then query the swagger at [http://localhost:4458/umbraco/swagger/index.html?urls.primaryName=Umbraco+Delivery+API](http://localhost:4458/umbraco/swagger/index.html?urls.primaryName=Umbraco+Delivery+API)

Example Query : all Products : [http://localhost:4458/umbraco/delivery/api/v2/content?filter=contentType%3Aproduct](http://localhost:4458/umbraco/delivery/api/v2/content?filter=contentType%3Aproduct)


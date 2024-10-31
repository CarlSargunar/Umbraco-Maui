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
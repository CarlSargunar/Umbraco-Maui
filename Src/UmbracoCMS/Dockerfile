# Use the SDK image to build and publish the website
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["UmbracoCMS.csproj", "."]
RUN dotnet restore "UmbracoCMS.csproj"
COPY . .
RUN dotnet publish "UmbracoCMS.csproj" -c Release -o /app/publish

# Copy the published output to the final running image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final 
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "UmbracoCMS.dll"]

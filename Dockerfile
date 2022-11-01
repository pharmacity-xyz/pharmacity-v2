# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
    
# Copy csproj and restore as distinct layers
COPY ./StoreAPI/*.csproj ./
RUN dotnet restore
    
# Copy everything else and build
COPY StoreAPI/. ./StoreAPI/
WORKDIR /source/StoreAPI
RUN dotnet publish -c release -o /app --no-restore
    
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "StoreAPI.dll"]
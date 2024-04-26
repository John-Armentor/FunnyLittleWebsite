# Use the .NET SDK image to build the application code
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy-arm64v8 AS build
WORKDIR /src
COPY ["FunnyLittleWebsite/FunnyLittleWebsite.csproj", "./"]
RUN dotnet restore "FunnyLittleWebsite.csproj"
COPY FunnyLittleWebsite/ .
RUN dotnet build "FunnyLittleWebsite.csproj" -c Release -o /app/build

# Publish the application to a directory for deployment
FROM build AS publish
RUN dotnet publish "FunnyLittleWebsite.csproj" -c Release -o /app/publish

# Use the .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-arm64v8 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FunnyLittleWebsite.dll"]

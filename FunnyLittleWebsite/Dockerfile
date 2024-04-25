# Use the .NET ASP.NET base Docker image for linux-arm64
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET SDK Docker image for linux-arm64
FROM mcr.microsoft.com/dotnet/sdk:8.0-bullseye-slim-arm64v8 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FunnyLittleWebsite/FunnyLittleWebsite.csproj", "FunnyLittleWebsite/"]
RUN dotnet restore "FunnyLittleWebsite/FunnyLittleWebsite.csproj"
COPY . .
WORKDIR "/src/FunnyLittleWebsite"
RUN dotnet build "FunnyLittleWebsite.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FunnyLittleWebsite.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0-bullseye-slim-arm64v8 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FunnyLittleWebsite.dll"]
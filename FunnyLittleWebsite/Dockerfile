# Use the official image as a parent image
FROM --platform=linux/arm64 mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the SDK image to build the code
FROM --platform=linux/arm64 mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FunnyLittleWebsite.csproj", "./"]  # Ensure the project file path matches your structure
RUN dotnet restore "FunnyLittleWebsite.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "FunnyLittleWebsite.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "FunnyLittleWebsite.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Build the final image
FROM --platform=linux/arm64 base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FunnyLittleWebsite.dll"]

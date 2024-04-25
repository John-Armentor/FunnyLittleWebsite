# Use the official image as a parent image, adjusted for a possibly existing ARM64 tag
FROM mcr.microsoft.com/dotnet/aspnet:8.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the SDK image to build the code, adjusted for ARM64
FROM mcr.microsoft.com/dotnet/sdk:8.0-bullseye-slim AS build
WORKDIR /src
COPY ["FunnyLittleWebsite.csproj", "./"]
RUN dotnet restore "FunnyLittleWebsite.csproj"
COPY . .
RUN dotnet build "FunnyLittleWebsite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FunnyLittleWebsite.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Build the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FunnyLittleWebsite.dll"]

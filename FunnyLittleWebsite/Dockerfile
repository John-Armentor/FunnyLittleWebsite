# Use the official ASP.NET Core runtime image from Microsoft Container Registry, ensure it's suitable for ARM64
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-arm64v8 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET Core SDK image to build the code, ensure it's suitable for ARM64
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy-arm64v8 AS build
WORKDIR /src
COPY ["FunnyLittleWebsite.csproj", "./"]
RUN dotnet restore "FunnyLittleWebsite.csproj"
COPY . .
RUN dotnet build "FunnyLittleWebsite.csproj" -c Release -o /app/build

FROM build AS publish
#RUN dotnet publish "FunnyLittleWebsite.csproj" -c Release -o /app/publish /p:UseAppHost=false
RUN dotnet publish "FunnyLittleWebsite.csproj" -c Release -o /app/publish


# Build the final image, using the ASP.NET Core runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FunnyLittleWebsite.dll"]

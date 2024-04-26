# Use the official ASP.NET Core runtime image from Microsoft Container Registry,
# ensure it's suitable for ARM64 if required by specifying platform during build.
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy AS base
WORKDIR /app
# Expose port 443 for HTTPS traffic
EXPOSE 443

# Use the official ASP.NET Core runtime image from Microsoft Container Registry,
# ensure it's suitable for ARM64 if required by specifying platform during build.
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy AS base
WORKDIR /app
# Expose port 443 for HTTPS traffic
EXPOSE 443

# Use the .NET Core SDK image to build the code.
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build
WORKDIR /src
# Ensure the path here accurately reflects the location of the .csproj file relative to the Dockerfile
COPY ["FunnyLittleWebsite/FunnyLittleWebsite.csproj", "./"]
RUN dotnet restore "FunnyLittleWebsite.csproj"
# Ensure all necessary files for the build are copied correctly
COPY FunnyLittleWebsite/ .
RUN dotnet build "FunnyLittleWebsite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FunnyLittleWebsite.csproj" -c Release -o /app/publish

# Build the final image using the ASP.NET Core runtime, with the app built in the previous stages
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Define the PORT environment variable, defaulting to 443 for HTTPS
ENV PORT=443
ENTRYPOINT ["dotnet", "FunnyLittleWebsite.dll"]


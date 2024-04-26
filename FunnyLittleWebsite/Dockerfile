FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy-arm64v8 AS build
WORKDIR /src
COPY ["FunnyLittleWebsite/FunnyLittleWebsite.csproj", "./"]
RUN dotnet restore "FunnyLittleWebsite.csproj" --verbosity normal
# Adding a command to list all files after restore to verify
RUN ls -al
COPY FunnyLittleWebsite/ .
# List contents to ensure all files are copied
RUN ls -al
# Adding detailed logging to the build command
RUN dotnet --info
RUN dotnet build "FunnyLittleWebsite.csproj" -c Release -o /app/build -verbosity detailed

FROM build AS publish
RUN dotnet publish "FunnyLittleWebsite.csproj" -c Release -o /app/publish --verbosity normal

FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-arm64v8 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FunnyLittleWebsite.dll"]

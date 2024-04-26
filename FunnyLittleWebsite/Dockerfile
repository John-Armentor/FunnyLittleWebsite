FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build
WORKDIR /src
COPY ["FunnyLittleWebsite/FunnyLittleWebsite.csproj", "./"]
RUN dotnet restore "FunnyLittleWebsite.csproj"
# Add a command to list all files in the current directory after restore
RUN ls -al
COPY FunnyLittleWebsite/ .
RUN dotnet --info
RUN dotnet build "FunnyLittleWebsite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FunnyLittleWebsite.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FunnyLittleWebsite.dll"]

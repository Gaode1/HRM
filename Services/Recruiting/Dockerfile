FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Recruiting.API/", "Services/Recruiting/Recruiting.API/"]
COPY ["ApplicationCore/", "Services/Recruiting/ApplicationCore/"]
COPY ["Infrastructure/", "Services/Recruiting/Infrastructure/"]
RUN dotnet restore "Services/Recruiting/Recruiting.API/Recruiting.API.csproj"

WORKDIR "/src/Services/Recruiting/Recruiting.API"
RUN dotnet build "Recruiting.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recruiting.API.csproj" -c Release -o /app/publish -r linux-x64 --self-contained false /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV angularURL='http://localhot:4200'
ENTRYPOINT ["dotnet", "Recruiting.API.dll"]

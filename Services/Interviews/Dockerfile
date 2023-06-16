FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim-amd64 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Interview.API/Interview.API.csproj", "Services/Interviews/Interview.API/"]
COPY ["Infrastructure/Infrastructure.csproj", "Services/Interviews/Infrastructure/"]
COPY ["ApplicationCore/ApplicationCore.csproj", "Services/Interviews/ApplicationCore/"]
RUN dotnet restore "Services/Interviews/Interview.API/Interview.API.csproj"
COPY . .
WORKDIR "/src/Services/Interviews/Interview.API"
RUN dotnet build "Interview.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interview.API.csproj" -c Release -o /app/publish -r linux-x64 --self-contained false /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interview.API.dll"]

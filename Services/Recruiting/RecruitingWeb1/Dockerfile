FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Recruiting/RecruitingWeb1/RecruitingWeb1.csproj", "Services/Recruiting/RecruitingWeb1/"]
COPY ["Services/Recruiting/ApplicationCore/ApplicationCore.csproj", "Services/Recruiting/ApplicationCore/"]
COPY ["Services/Recruiting/Infrastructure/Infrastructure.csproj", "Services/Recruiting/Infrastructure/"]
RUN dotnet restore "Services/Recruiting/RecruitingWeb1/RecruitingWeb1.csproj"
COPY . .
WORKDIR "/src/Services/Recruiting/RecruitingWeb1"
RUN dotnet build "RecruitingWeb1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecruitingWeb1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecruitingWeb1.dll"]

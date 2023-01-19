FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AccountManagement.WEB/AccountManagement.WEB.csproj", "AccountManagement.WEB/"]
COPY ["AccountManagement.Infrastructure/AccountManagement.Infrastructure.csproj", "AccountManagement.Infrastructure/"]
RUN dotnet restore "AccountManagement.WEB/AccountManagement.WEB.csproj"
COPY . .
WORKDIR "/src/AccountManagement.WEB"
RUN dotnet build "AccountManagement.WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AccountManagement.WEB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccountManagement.WEB.dll"]

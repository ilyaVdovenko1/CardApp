FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CardApp.Server.Api/CardApp.Server.Api.csproj", "CardApp.Server.Api/"]
COPY ["CardApp.Server.Bll/CardApp.Server.Bll.csproj", "CardApp.Server.Bll/"]
COPY ["CardApp.Server.Dal/CardApp.Server.Dal.csproj", "CardApp.Server.Dal/"]
RUN dotnet restore "CardApp.Server.Api/CardApp.Server.Api.csproj"
COPY . .
WORKDIR "/src/CardApp.Server.Api"
RUN dotnet build "CardApp.Server.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CardApp.Server.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CardApp.Server.Api.dll"]

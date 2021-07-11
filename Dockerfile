
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Alerting.Presentation/Alerting.Presentation.csproj", "Alerting.Presentation/"]
COPY ["Alerting.Infrastructure/Alerting.Infrastructure.csproj", "Alerting.Infrastructure/"]
COPY ["Alerting.DomainModel/Alerting.DomainModel.csproj", "Alerting.DomainModel/"]
COPY ["Alerting.Application/Alerting.Application.csproj", "Alerting.Application/"]
RUN dotnet restore "Alerting.Presentation/Alerting.Presentation.csproj"
COPY . .
WORKDIR "/src/Alerting.Presentation"
RUN dotnet build "Alerting.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Alerting.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Alerting.Presentation.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5103

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/ReverseProxy/MyDDDService.ReverseProxy.csproj ReverseProxy/

RUN dotnet restore "ReverseProxy/MyDDDService.ReverseProxy.csproj"

COPY src/ .

WORKDIR /src/ReverseProxy
RUN dotnet build "MyDDDService.ReverseProxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyDDDService.ReverseProxy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyDDDService.ReverseProxy.dll"]
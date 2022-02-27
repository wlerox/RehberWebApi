#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Rehber.Api/Rehber.API.csproj", "Rehber.Api/"]
COPY ["Rehber.DataAccess/Rehber.DataAccess.csproj", "Rehber.DataAccess/"]
COPY ["Rehber.Entities/Rehber.Entities.csproj", "Rehber.Entities/"]
COPY ["Rehber.Business/Rehber.Business.csproj", "Rehber.Business/"]
RUN dotnet restore "Rehber.Api/Rehber.API.csproj"
COPY . .
WORKDIR "/src/Rehber.Api"
RUN dotnet build "Rehber.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rehber.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rehber.API.dll"]
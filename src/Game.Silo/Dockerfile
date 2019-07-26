FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Game.Silo/Game.Silo.csproj", "Game.Silo/"]
COPY ["Game.Facility.Grains/Game.Facility.Grains.csproj", "Game.Facility.Grains/"]
COPY ["Game.Core.Interface/Game.Core.Interface.csproj", "Game.Core.Interface/"]
COPY ["Game.Facility.Interface/Game.Facility.Interface.csproj", "Game.Facility.Interface/"]
COPY ["Game.Combat.Grains/Game.Combat.Grains.csproj", "Game.Combat.Grains/"]
COPY ["Game.Combat.Interface/Game.Combat.Interface.csproj", "Game.Combat.Interface/"]
COPY ["Game.Core.Grains/Game.Core.Grains.csproj", "Game.Core.Grains/"]
COPY ["Game.MudLib", "/app/game.mudlib"]

RUN dotnet restore "Game.Silo/Game.Silo.csproj"
COPY . .
WORKDIR "/src/Game.Silo"
RUN dotnet build "Game.Silo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Game.Silo.csproj" -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV MudLibPath="/app/game.mudlib/"
ENTRYPOINT ["dotnet", "Game.Silo.dll"]

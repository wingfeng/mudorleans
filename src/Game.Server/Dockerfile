FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Game.Server/Game.Server.csproj", "Game.Server/"]
COPY ["CommandLine/CommandLine.csproj", "CommandLine/"]
COPY ["Game.Combat.Interface/Game.Combat.Interface.csproj", "Game.Combat.Interface/"]
COPY ["Game.Core.Interface/Game.Core.Interface.csproj", "Game.Core.Interface/"]
COPY ["Game.Facility.Interface/Game.Facility.Interface.csproj", "Game.Facility.Interface/"]
RUN dotnet restore "Game.Server/Game.Server.csproj"
COPY . .
WORKDIR "/src/Game.Server"
RUN dotnet build "Game.Server.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Game.Server.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Game.Server.dll"]

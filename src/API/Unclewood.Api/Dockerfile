FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/API/Unclewood.Api/Unclewood.Api.csproj", "src/API/Unclewood.Api/"]
RUN dotnet restore "src/API/Unclewood.Api/Unclewood.Api.csproj"
COPY . .
WORKDIR "/src/src/API/Unclewood.Api"
RUN dotnet build "Unclewood.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Unclewood.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Unclewood.Api.dll"]

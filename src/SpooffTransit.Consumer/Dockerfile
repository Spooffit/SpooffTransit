FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SpooffTransit.Consumer/SpooffTransit.Consumer.csproj", "src/SpooffTransit.Consumer/"]
RUN dotnet restore "src/SpooffTransit.Consumer/SpooffTransit.Consumer.csproj"
COPY . .
WORKDIR "/src/src/SpooffTransit.Consumer"
RUN dotnet build "SpooffTransit.Consumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SpooffTransit.Consumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpooffTransit.Consumer.dll"]

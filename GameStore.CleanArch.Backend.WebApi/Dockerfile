# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8000


# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GameStore.CleanArch.Backend.WebApi/GameStore.CleanArch.Backend.WebApi.csproj", "GameStore.CleanArch.Backend.WebApi/"]
COPY ["GameStore.CleanArch.Backend.Business/GameStore.CleanArch.Backend.Business.csproj", "GameStore.CleanArch.Backend.Business/"]
COPY ["GameStore.CleanArch.Backend.Application/GameStore.CleanArch.Backend.Application.csproj", "GameStore.CleanArch.Backend.Application/"]
COPY ["GameStore.CleanArch.Backend.Domain/GameStore.CleanArch.Backend.Domain.csproj", "GameStore.CleanArch.Backend.Domain/"]
COPY ["GameStore.CleanArch.Backend.Infrastructure/GameStore.CleanArch.Backend.Infrastructure.csproj", "GameStore.CleanArch.Backend.Infrastructure/"]
RUN dotnet restore "./GameStore.CleanArch.Backend.WebApi/GameStore.CleanArch.Backend.WebApi.csproj"
COPY . .
WORKDIR "/src/GameStore.CleanArch.Backend.WebApi"
RUN dotnet build "./GameStore.CleanArch.Backend.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GameStore.CleanArch.Backend.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameStore.CleanArch.Backend.WebApi.dll"]
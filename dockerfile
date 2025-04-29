# Establece la imagen base para la construcción de la aplicación
# 'mcr.microsoft.com/dotnet/aspnet:8.0' es una imagen de ASP.NET Core que incluye solo el entorno de ejecución necesario para ejecutar aplicaciones ASP.NET.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Define el directorio de trabajo dentro del contenedor como '/app'
WORKDIR /app

# Expone el puerto 8080 para tráfico HTTP
EXPOSE 8080
# Expone el puerto 8081 para tráfico HTTPS
EXPOSE 8081

# Inicia una nueva etapa de construcción utilizando una imagen con el SDK de .NET que incluye las herramientas necesarias para construir la aplicación.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define un argumento que se puede pasar a la construcción para determinar la configuración (por defecto será 'Release')
ARG BUILD_CONFIGURATION=Release

# Define el directorio de trabajo en esta etapa como '/src'
WORKDIR /src

# Copia los archivos .csproj (proyectos) de las diferentes capas de la aplicación a sus respectivas carpetas dentro del contenedor
COPY ["GameStore.CleanArch.Backend.Application/GameStore.CleanArch.Backend.Application.csproj", "GameStore.CleanArch.Backend.Application/"]
COPY ["GameStore.CleanArch.Backend.Business/GameStore.CleanArch.Backend.Business.csproj", "GameStore.CleanArch.Backend.Business/"]
COPY ["GameStore.CleanArch.Backend.Domain/GameStore.CleanArch.Backend.Domain.csproj", "GameStore.CleanArch.Backend.Domain/"]
COPY ["GameStore.CleanArch.Backend.Infrastructure/GameStore.CleanArch.Backend.Infrastructure.csproj", "GameStore.CleanArch.Backend.Infrastructure/"]
COPY ["GameStore.CleanArch.Backend.WebApi/GameStore.CleanArch.Backend.WebApi.csproj", "GameStore.CleanArch.Backend.WebApi/"]

# Restaura las dependencias de los proyectos copiados anteriormente. 'dotnet restore' descarga e instala todos los paquetes NuGet necesarios.
RUN dotnet restore "GameStore.CleanArch.Backend.WebApi/GameStore.CleanArch.Backend.WebApi.csproj"

# Copia el resto del código fuente al contenedor
COPY . .

# Establece el directorio de trabajo en el proyecto WebApi para compilarlo.
WORKDIR "/src/GameStore.CleanArch.Backend.WebApi"

# Compila la aplicación utilizando la configuración proporcionada (por defecto 'Release') y coloca los archivos de salida en el directorio '/app/build'
RUN dotnet build "GameStore.CleanArch.Backend.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Inicia una etapa de publicación utilizando los archivos previamente compilados
FROM build AS publish

# Define el mismo argumento de configuración para asegurar la consistencia con la etapa anterior
ARG BUILD_CONFIGURATION=Release

# Publica la aplicación, es decir, genera los archivos necesarios para ejecutar la aplicación, y los coloca en el directorio '/app/publish'
RUN dotnet publish "GameStore.CleanArch.Backend.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# Inicia la etapa final del Dockerfile, donde se prepara la imagen que se utilizará para ejecutar la aplicación.
FROM base AS final

# Establece el directorio de trabajo en '/app' en la etapa final
WORKDIR /app

# Copia los archivos publicados desde la etapa 'publish' a la etapa final
COPY --from=publish /app/publish .

# Define el comando que se ejecutará cuando se inicie el contenedor. En este caso, se ejecutará la aplicación con 'dotnet'.
ENTRYPOINT [ "dotnet", "GameStore.CleanArch.Backend.WebApi.dll"]

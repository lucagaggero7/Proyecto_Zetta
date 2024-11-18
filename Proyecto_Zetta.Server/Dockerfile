# Fase base para la API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7201

# Fase de construcción para el proyecto Server
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Copiar los archivos de los proyectos de la solución
COPY ../Proyecto_Zetta.Server/Proyecto_Zetta.Server.csproj Proyecto_Zetta.Server/
COPY ../Proyecto_Zetta.Client/Proyecto_Zetta.Client.csproj Proyecto_Zetta.Client/
COPY ../Proyecto_Zetta.Shared/Proyecto_Zetta.Shared.csproj Proyecto_Zetta.Shared/
COPY ../Proyecto_Zetta.DB/Proyecto_Zetta.DB.csproj Proyecto_Zetta.DB/

# Restaurar dependencias
RUN dotnet restore Proyecto_Zetta.Server/Proyecto_Zetta.Server.csproj

# Copiar todos los archivos del proyecto al contenedor
COPY ../ .

# Construir el proyecto
WORKDIR /src/Proyecto_Zetta.Server
RUN dotnet build Proyecto_Zetta.Server.csproj -c Release -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish Proyecto_Zetta.Server.csproj -c Release -o /app/publish

# Fase final para el contenedor
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Copiar los archivos estáticos de Blazor WebAssembly
COPY ../Proyecto_Zetta.Client/wwwroot /app/wwwroot

# Establecer el punto de entrada para la aplicación
ENTRYPOINT ["dotnet", "Proyecto_Zetta.Server.dll"]

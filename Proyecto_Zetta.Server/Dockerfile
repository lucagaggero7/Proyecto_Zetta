# Fase de base para la API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7201

# Fase de construcción para el proyecto Server
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Proyecto_Zetta.Server/Proyecto_Zetta.Server.csproj", "Proyecto_Zetta.Server/"]
COPY ["Proyecto_Zetta.Client/Proyecto_Zetta.Client.csproj", "Proyecto_Zetta.Client/"]
COPY ["Proyecto_Zetta.Shared/Proyecto_Zetta.Shared.csproj", "Proyecto_Zetta.Shared/"]

RUN dotnet restore "Proyecto_Zetta.Server/Proyecto_Zetta.Server.csproj"
COPY . .
WORKDIR "/src/Proyecto_Zetta.Server"
RUN dotnet build "Proyecto_Zetta.Server.csproj" -c Release -o /app/build

# Publicación de la aplicación
FROM build AS publish
RUN dotnet publish "Proyecto_Zetta.Server.csproj" -c Release -o /app/publish

# Fase final con API y Blazor
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Copiar los archivos estáticos de Blazor WebAssembly
COPY ["Proyecto_Zetta.Client/wwwroot", "/app/wwwroot"]

# Establecer el punto de entrada para la aplicación
ENTRYPOINT ["dotnet", "Proyecto_Zetta.Server.dll"]

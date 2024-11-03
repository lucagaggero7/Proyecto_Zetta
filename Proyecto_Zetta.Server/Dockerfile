# Usa la imagen base de ASP.NET Core para la app final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Usa el SDK de .NET para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia los archivos de solución y restaura las dependencias
COPY Proyecto_Zetta.sln ./
COPY Proyecto_Zetta.Client/Proyecto_Zetta.Client.csproj Proyecto_Zetta.Client/
COPY Proyecto_Zetta.Server/Proyecto_Zetta.Server.csproj Proyecto_Zetta.Server/
COPY Proyecto_Zetta.Shared/Proyecto_Zetta.Shared.csproj Proyecto_Zetta.Shared/
RUN dotnet restore

# Copia todos los archivos y compila la aplicación
COPY . .
WORKDIR /src/Proyecto_Zetta.Server
RUN dotnet publish -c Release -o /app/out

# Configura la imagen final para ejecutar la aplicación
FROM base AS final
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Proyecto_Zetta.Server.dll"]
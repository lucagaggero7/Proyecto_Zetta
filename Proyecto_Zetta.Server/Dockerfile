

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Proyecto_Zetta.Server/Proyecto_Zetta.Server.csproj", "Proyecto_Zetta.Server/"]
COPY ["Proyecto_Zetta.Client/Proyecto_Zetta.Client.csproj", "Proyecto_Zetta.Client/"]
COPY ["Proyecto_Zetta.DB/Proyecto_Zetta.DB.csproj", "Proyecto_Zetta.DB/"]
COPY ["Proyecto_Zetta.Shared/Proyecto_Zetta.Shared.csproj", "Proyecto_Zetta.Shared/"]
RUN dotnet restore "./Proyecto_Zetta.Server/Proyecto_Zetta.Server.csproj"
COPY . .
WORKDIR "/src/Proyecto_Zetta.Server"
RUN dotnet build "./Proyecto_Zetta.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Proyecto_Zetta.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Proyecto_Zetta.Server.dll"]
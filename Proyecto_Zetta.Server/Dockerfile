# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Configura el directorio de trabajo
WORKDIR /src

# Copia los archivos de los proyectoss
COPY ["Proyecto_Zetta.Server/Proyecto_Zetta.Server.csproj", "Proyecto_Zetta.Server/"]
COPY ["Proyecto_Zetta.Client/Proyecto_Zetta.Client.csproj", "Proyecto_Zetta.Client/"]
COPY ["Proyecto_Zetta.DB/Proyecto_Zetta.DB.csproj", "Proyecto_Zetta.DB/"]
COPY ["Proyecto_Zetta.Shared/Proyecto_Zetta.Shared.csproj", "Proyecto_Zetta.Shared/"]

# Restaura las dependencias
RUN dotnet restore "Proyecto_Zetta.Server/Proyecto_Zetta.Server.csproj"

# Copia el resto de los archivos y compila
COPY . .
RUN dotnet publish "Proyecto_Zetta.Server/Proyecto_Zetta.Server.csproj" -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expone el puerto
EXPOSE 80

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "Proyecto_Zetta.Server.dll"]
# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o arquivo do projeto
COPY dxpert-api/API.csproj ./dxpert-api/
RUN dotnet restore ./dxpert-api/API.csproj

# Copiar todo o c�digo fonte
COPY . .

# Build da aplica��o
WORKDIR /src/dxpert-api
RUN dotnet build API.csproj -c Release -o /app/build

# Etapa de desenvolvimento
FROM build AS development
WORKDIR /src/dxpert-api
CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:8080"]

# Etapa de publica��o
FROM build AS publish
RUN dotnet publish API.csproj -c Release -o /app/publish /p:UseAppHost=false

# Etapa final para produ��o
FROM base AS production
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o arquivo do projeto
COPY dxpert-api/API.csproj ./dxpert-api/
RUN dotnet restore ./dxpert-api/API.csproj

# Copiar todo o c�digo fonte
COPY . .

# Build da aplica��o
WORKDIR /src/dxpert-api
RUN dotnet build API.csproj -c Release -o /app/build

# Etapa de desenvolvimento
FROM build AS development
WORKDIR /src/dxpert-api
CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:8080"]

# Etapa de publica��o
FROM build AS publish
RUN dotnet publish API.csproj -c Release -o /app/publish /p:UseAppHost=false

# Etapa final para produ��o
FROM base AS production
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]

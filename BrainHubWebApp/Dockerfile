# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Build SDK image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files and restore
COPY ["BrainHub/BrainHub.csproj", "BrainHub/"]
COPY ["BrainHub.DomainLayer/BrainHub.DomainLayer.csproj", "BrainHub.DomainLayer/"]
COPY ["BrainHub.RepositoryLayer/BrainHub.RepositoryLayer.csproj", "BrainHub.RepositoryLayer/"]
COPY ["BrainHub.ServiceLayer/BrainHub.ServiceLayer.csproj", "BrainHub.ServiceLayer/"]

RUN dotnet restore "./BrainHub/BrainHub.csproj"

# Copy all files and build
COPY . .
WORKDIR "/src/BrainHub"
RUN dotnet build "./BrainHub.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "./BrainHub.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrainHub.dll"]

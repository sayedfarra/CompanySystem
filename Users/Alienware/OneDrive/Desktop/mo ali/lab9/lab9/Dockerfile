# ======= Build Stage =======
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy all project files first (for layer caching)
COPY CompanySystem.DAL/CompanySystem.DAL.csproj CompanySystem.DAL/
COPY CompanySystem.BLL/CompanySystem.BLL.csproj CompanySystem.BLL/
COPY CompanySystem.PL/CompanySystem.PL.csproj CompanySystem.PL/

# Restore dependencies
RUN dotnet restore CompanySystem.PL/CompanySystem.PL.csproj

# Copy all source code
COPY . .

# Build and publish
RUN dotnet publish CompanySystem.PL/CompanySystem.PL.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# ======= Runtime Stage =======
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "CompanySystem.PL.dll"]

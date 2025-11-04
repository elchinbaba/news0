# Build stage using .NET Core 3.1 SDK
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

# Copy all project files
COPY . .

# Publish only the Web project
RUN dotnet publish News0.Web/News0.Web.csproj -c Release -o /app/out

# Runtime stage using ASP.NET Core 3.1
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS final
WORKDIR /app

COPY --from=build /app/out .

# Railway port binding
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "News0.Web.dll"]

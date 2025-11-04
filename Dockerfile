# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Publish ASP.NET project
RUN dotnet publish News0.Web/News0.Web.csproj -c Release -o /app/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy build artifacts
COPY --from=build /app/out .

# Railway expects app to listen on 0.0.0.0:8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

# Start the app
ENTRYPOINT ["dotnet", "News0.Web.dll"]

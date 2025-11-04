#!/bin/bash
set -e

# Build & publish the web project
dotnet publish News0.Web/News0.Web.csproj -c Release -o out

# Start the app
dotnet out/News0.Web.dll

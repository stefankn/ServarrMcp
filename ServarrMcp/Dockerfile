FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["ServarrMcp.csproj", "./"]
RUN dotnet restore "ServarrMcp.csproj"
COPY . .
RUN dotnet build "ServarrMcp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServarrMcp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServarrMcp.dll"]

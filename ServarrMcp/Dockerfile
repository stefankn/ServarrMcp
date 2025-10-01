FROM mcr.microsoft.com/dotnet/aspnet:9.0-bookworm-slim-arm64v8 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["ServarrMcp.csproj", "./"]
RUN dotnet restore "ServarrMcp.csproj"
COPY . .
RUN dotnet build "ServarrMcp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServarrMcp.csproj" -c Release -o /app/publish -r linux-arm64 --self-contained true /p:PublishSingleFile=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./ServarrMcp"]

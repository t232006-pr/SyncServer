# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["SyncServer.csproj", "."]
RUN dotnet restore "SyncServer.csproj"

COPY . .
RUN dotnet build "SyncServer.csproj" -c Release -o /app/build

RUN dotnet publish "SyncServer.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "SyncServer.dll"]
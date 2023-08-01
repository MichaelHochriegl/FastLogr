FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["example/FastLogr.Example.WorkerService/FastLogr.Example.WorkerService.csproj", "example/FastLogr.Example.WorkerService/"]
RUN dotnet restore "example/FastLogr.Example.WorkerService/FastLogr.Example.WorkerService.csproj"
COPY . .
WORKDIR "/src/example/FastLogr.Example.WorkerService"
RUN dotnet build "FastLogr.Example.WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FastLogr.Example.WorkerService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FastLogr.Example.WorkerService.dll"]

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["N51-Task1/N51-Task1.csproj", "N51-Task1/"]
RUN dotnet restore "N51-Task1/N51-Task1.csproj"
COPY . .
WORKDIR "/src/N51-Task1"
RUN dotnet build "N51-Task1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "N51-Task1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N51-Task1.dll"]

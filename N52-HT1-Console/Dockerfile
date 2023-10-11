FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["N52-HT1-Console/N52-HT1-Console.csproj", "N52-HT1-Console/"]
RUN dotnet restore "N52-HT1-Console/N52-HT1-Console.csproj"
COPY . .
WORKDIR "/src/N52-HT1-Console"
RUN dotnet build "N52-HT1-Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "N52-HT1-Console.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N52-HT1-Console.dll"]

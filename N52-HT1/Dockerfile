FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["N52-HT1/N52-HT1.csproj", "N52-HT1/"]
RUN dotnet restore "N52-HT1/N52-HT1.csproj"
COPY . .
WORKDIR "/src/N52-HT1"
RUN dotnet build "N52-HT1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "N52-HT1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N52-HT1.dll"]

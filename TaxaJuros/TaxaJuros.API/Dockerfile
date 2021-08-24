FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TaxaJuros/TaxaJuros.API/TaxaJuros.csproj", "TaxaJuros.API/"]
RUN dotnet restore "TaxaJuros.API/TaxaJuros.csproj"
COPY . .
WORKDIR "/src/TaxaJuros/TaxaJuros.API"
RUN dotnet build "TaxaJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaxaJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaxaJuros.dll"]
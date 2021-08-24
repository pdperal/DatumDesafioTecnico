FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CalculadoraJuros/CalculadoraJuros.API/CalculadoraJuros.csproj", "CalculadoraJuros.API/"]
RUN dotnet restore "CalculadoraJuros.API/CalculadoraJuros.csproj"
COPY . .
WORKDIR "/src/CalculadoraJuros/CalculadoraJuros.API"
RUN dotnet build "CalculadoraJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculadoraJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculadoraJuros.dll"]
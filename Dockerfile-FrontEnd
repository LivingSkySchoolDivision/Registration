#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["LSSD.Registration.CustomerFrontEnd/LSSD.Registration.CustomerFrontEnd.csproj", "LSSD.Registration.CustomerFrontEnd/"]
COPY ["LSSD.Registration.Model/LSSD.Registration.Model.csproj", "LSSD.Registration.Model/"]
RUN dotnet restore "LSSD.Registration.CustomerFrontEnd/LSSD.Registration.CustomerFrontEnd.csproj"
COPY . .
WORKDIR "/src/LSSD.Registration.CustomerFrontEnd"
RUN dotnet build "LSSD.Registration.CustomerFrontEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LSSD.Registration.CustomerFrontEnd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LSSD.Registration.CustomerFrontEnd.dll"]
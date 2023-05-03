#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BarbecueManager.Application.API/BarbecueManager.Application.API.csproj", "BarbecueManager.Application.API/"]
COPY ["BarbecueManager.Infra.Data/BarbecueManager.Infra.Data.csproj", "BarbecueManager.Infra.Data/"]
COPY ["BarbecueManager.Domain/BarbecueManager.Domain.csproj", "BarbecueManager.Domain/"]
RUN dotnet restore "BarbecueManager.Application.API/BarbecueManager.Application.API.csproj"
COPY . .
WORKDIR "/src/BarbecueManager.Application.API"
RUN dotnet build "BarbecueManager.Application.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BarbecueManager.Application.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BarbecueManager.Application.API.dll"]
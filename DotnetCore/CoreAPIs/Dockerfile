#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ICS.WebAPI/ICS.WebAPI.csproj", "ICS.WebAPI/"]
COPY ["ICS.DAL/ICS.DAL.csproj", "ICS.DAL/"]
COPY ["ICS.Services/ICS.Services.csproj", "ICS.Services/"]
RUN dotnet restore "ICS.WebAPI/ICS.WebAPI.csproj"
COPY . .
WORKDIR "/src/ICS.WebAPI"
RUN dotnet build "ICS.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ICS.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ICS.WebAPI.dll"]
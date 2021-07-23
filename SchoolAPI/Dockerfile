#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

#FROM mcr.microsoft.com/mssql/server:2017-latest AS build
#ENV ACCEPT_EULA=Y
#ENV SA_PASSWORD=R00trootroot
#EXPOSE 1433
#
#WORKDIR /tmp
#
#RUN /opt/mssql/bin/sqlservr --accept-eula 

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["SchoolAPI/SchoolAPI.csproj", "SchoolAPI/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["LoggerService/LoggerManager.csproj", "LoggerService/"]
COPY ["Entities/Entities.csproj", "Entities/"]
RUN dotnet restore "SchoolAPI/SchoolAPI.csproj"
COPY . .
WORKDIR "/src/SchoolAPI"
RUN dotnet build "SchoolAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolAPI.dll"]


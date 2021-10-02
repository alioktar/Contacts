#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Contacts.ApiHost/Contacts.ApiHost.csproj", "src/Contacts.ApiHost/"]
COPY ["src/Contacts.BusinessLogic/Contacts.BusinessLogic.csproj", "src/Contacts.BusinessLogic/"]
COPY ["src/Contacts.DTOs/Contacts.DTOs.csproj", "src/Contacts.DTOs/"]
COPY ["src/Contacts.Constants/Contacts.Constants.csproj", "src/Contacts.Constants/"]
COPY ["src/Contacts.Core/Contacts.Core.csproj", "src/Contacts.Core/"]
COPY ["src/Contacts.DataAccess/Contacts.DataAccess.csproj", "src/Contacts.DataAccess/"]
COPY ["src/Contacts.Entities/Contacts.Entities.csproj", "src/Contacts.Entities/"]
RUN dotnet restore "src/Contacts.ApiHost/Contacts.ApiHost.csproj"
COPY . .
WORKDIR "/src/src/Contacts.ApiHost"
RUN dotnet build "Contacts.ApiHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contacts.ApiHost.csproj" -c Release -o /app/publish

FROM base AS final
ENV TZ=Europe/Istanbul
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contacts.ApiHost.dll"]
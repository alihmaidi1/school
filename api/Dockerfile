FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["schoolmanagment/schoolmanagment.csproj", "schoolmanagment/"]
RUN dotnet restore "schoolmanagment/schoolmanagment.csproj"
COPY . .
WORKDIR "/src/schoolmanagment"
RUN dotnet build "schoolmanagment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "schoolmanagment.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "schoolmanagment.dll"]

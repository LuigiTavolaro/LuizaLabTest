FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["LuizaLabTest/LuizaLabTest.Wishes.csproj", "LuizaLabTest/"]
COPY ["../DTO/LuizaLabTest.DTO/LuizaLabTest.DTO.csproj", "../DTO/LuizaLabTest.DTO/"]
RUN dotnet restore "LuizaLabTest/LuizaLabTest.Wishes.csproj"
COPY . .
WORKDIR "/src/LuizaLabTest"
RUN dotnet build "LuizaLabTest.Wishes.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LuizaLabTest.Wishes.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LuizaLabTest.Wishes.dll"]
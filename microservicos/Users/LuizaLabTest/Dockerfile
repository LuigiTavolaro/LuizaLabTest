FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["LuizaLabTest/LuizaLabTest.Users.csproj", "LuizaLabTest/"]
COPY ["../DTO/LuizaLabTest.DTO/LuizaLabTest.DTO.csproj", "../DTO/LuizaLabTest.DTO/"]
RUN dotnet restore "LuizaLabTest/LuizaLabTest.Users.csproj"
COPY . .
WORKDIR "/src/LuizaLabTest"
RUN dotnet build "LuizaLabTest.Users.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LuizaLabTest.Users.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LuizaLabTest.Users.dll"]
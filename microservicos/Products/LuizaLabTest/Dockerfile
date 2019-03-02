FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["LuizaLabTest/LuizaLabTest.Products.csproj", "LuizaLabTest/"]
COPY ["../DTO/LuizaLabTest.DTO/LuizaLabTest.DTO.csproj", "../DTO/LuizaLabTest.DTO/"]
RUN dotnet restore "LuizaLabTest/LuizaLabTest.Products.csproj"
COPY . .
WORKDIR "/src/LuizaLabTest"
RUN dotnet build "LuizaLabTest.Products.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LuizaLabTest.Products.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LuizaLabTest.Products.dll"]
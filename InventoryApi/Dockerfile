FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /app
COPY *.sln .
COPY InventoryApi/*.csproj ./InventoryApi/
COPY InventoryApi.Test/*.csproj ./InventoryApi.Test/
RUN dotnet restore

COPY . .
RUN find -type d -name bin -prune -exec rm -rf {} \; && find -type d -name obj -prune -exec rm -rf {} \;
RUN dotnet build

FROM build AS test
WORKDIR /app/InventoryApi.Test
RUN dotnet test --logger:trx

FROM build AS publish
WORKDIR /app/InventoryApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:latest AS runtime
WORKDIR /app
COPY --from=publish /app/InventoryApi/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "InventoryApi.dll"]
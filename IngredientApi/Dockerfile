FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /app
COPY *.sln .
COPY IngredientApi/*.csproj ./IngredientApi/
COPY IngredientApi.UnitTest/*.csproj ./IngredientApi.UnitTest/
RUN dotnet restore

COPY . .
RUN dotnet build

FROM build AS test
WORKDIR /app/IngredientApi.UnitTest
RUN dotnet test --logger:trx

FROM build AS publish
WORKDIR /app/IngredientApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:latest AS runtime
WORKDIR /app
COPY --from=publish /app/IngredientApi/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "IngredientApi.dll"]
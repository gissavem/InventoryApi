FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /app
COPY *.sln .
COPY PizzaApi/*.csproj ./PizzaApi/
COPY PizzaApiTest/*.csproj ./PizzaApiTest/
RUN dotnet restore 

COPY . .
RUN dotnet build

FROM build AS test
WORKDIR /app/PizzaApiTest
RUN dotnet test --logger:trx

FROM build AS publish
WORKDIR /app/PizzaApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:latest AS runtime
WORKDIR /app
COPY --from=publish /app/PizzaApi/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "PizzaApi.dll"]
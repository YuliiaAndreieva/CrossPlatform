FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /

COPY ./App.Api/App.Api.csproj ./App.Api/
COPY ./App.SqlServer/App.SqlServer.csproj ./App.SqlServer/
COPY ./App.Models/App.Models.csproj ./App.Models/
COPY ./App.Postgres/App.Postgres.csproj ./App.Postgres/
COPY ./App.SQLite/App.SQLite.csproj ./App.SQLite/
RUN dotnet restore ./App.Api/

COPY ./App.Api/ ./App.Api/
COPY ./App.SqlServer/ ./App.SqlServer/
COPY ./App.Models/ ./App.Models/
COPY ./App.Postgres/ ./App.Postgres/
COPY ./App.SQLite/ ./App.SQLite/
RUN dotnet publish -c Release -o /app/ ./App.Api/

FROM mcr.microsoft.com/dotnet/aspnet:8.0
COPY --from=build /app/ .
WORKDIR /app
ENTRYPOINT ["dotnet", "App.Api.dll"]
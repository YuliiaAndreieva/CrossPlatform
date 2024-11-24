# Lab7
## Опис застосунку
У даній лабораторній було використано клон MVC проекту з 6 лабораторної та додано нові контроллери до REST API. Для кожного з провайдерів створено окремо проекти з міграціями, та окремий проект для DbContext з сутностями.
До HouseholdMembersController було додано версіювання. Також були написані тести для контроллерів
## Запуск застосунку
Для запуску з UI частиною, треба запустити MVC проект та власне REST API

Запуск MVC:

Для запуску треба додати свої credentials в appsettings.json:
```  
"Auth0": {
    "ClientId": "2bIsALcPDhQN6GJ1RG6JHkMS3JftH1W8",
    "Domain": "dev-qyulsuvmi4i083bm.us.auth0.com",
    "ClientSecret": ""
  },
```

Перейдіть у папку застосунку, з цієї папки виконайте:
```bash
cd Lab7/Lab5/App
dotnet run
```

Запуск REST API:

Для запуску треба додати .env файл (в Lab7/App.Api), в якому буде вказано провайдера:

Наприклад:
```
DATABASE_PROVIDER=SQLite
ASPNETCORE_ENVIRONMENT=Development
```

Перейдіть у папку застосунку, з цієї папки виконайте:
```bash
cd Lab7/App.Api
dotnet run
```

## Запуск тестів
Для запуску треба додати .env файл (Lab7/App.Api/tests), в якому буде вказано хост, на якому контролери:

Наприклад:
```
API_URL=http://localhost:3001
```

Також для запуску треба додати свої credentials в getAccessToken.js:
```  
"Auth0": {
    "ClientId": "2bIsALcPDhQN6GJ1RG6JHkMS3JftH1W8",
    "Domain": "dev-qyulsuvmi4i083bm.us.auth0.com",
    "ClientSecret": ""
  },
```

Якщо піднімаєте в докері, то замініть на відповідний 8080.

Перейдіть у папку застосунку, з цієї папки виконайте:
```bash
cd Lab7/App.Api/tests
npm i
npm test
```
## Запуск через Docker 
Для запуску REST API через докер, у папці наявний [докерфайл](App.Api/Dockerfile)

[Для запуску різних субд](docker-compose.yml) 

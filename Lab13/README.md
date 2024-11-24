# Lab13
## Опис застосунку
У даній лабораторній було зроблено UI з Angular для лабораторних робіт 1-3 використовуючи ClassLib проект з лабораторної 4, однак це реалізовано як окреме REST Api. Також додано логін/лог аут.
## Запуск застосунку
Для запуску, треба запустити Angular проект та власне REST API

Запуск Angular:

Для запуску треба додати свої credentials в auth_config.js!! Наприклад:
```  
{
  "domain": "dev-qyulsuvmi4i083bm.us.auth0.com",
  "clientId": "",
  "authorizationParams": {
    "audience": ""
  },
  "apiUri": "http://localhost:3001",
  "appUri": "http://localhost:4200",
  "errorPath": "/error"
}
```

Далі перейдіть у папку застосунку
```bash
cd Lab13/App.WebClient
```
З цієї папки виконайте:
```bash
ng serve
```
Запуск REST API:

Також для запуску треба додати свої credentials в appsettings.json. Наприклад:
```  
"Auth0": {
    "Audience": "",
    "Domain": "",
  },
```
Перейдіть у папку застосунку
```bash
cd Lab13/App.Api
```
З цієї папки виконайте:
```bash
dotnet run
```
Тепер ви маєте апі на порті 3001 та ангуляр застосунок на 4200
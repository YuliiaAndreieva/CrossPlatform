# Lab3
## Запуск застосунку
Виконати команду з даної папки:
```bash
dotnet run --project App
```
Вхідний файл `INPUT.TXT` знаходиться в даній папці

Вихідний файл `OUTPUT.TXT` записується в дану папці

## Запуск тестів
Виконати команду з даної папки:
```bash
dotnet test Tests
```
Для виведення проміжних результатів:
```bash
dotnet test --logger "console;verbosity=detailed" Tests
```

## Щодо Nuget
Для розгортання локального NuGet-репозиторію використовується docker-compose.yml
```bash
cd Lab3
docker-compose up
```
Локальний NuGet-сервер буде доступний за адресою:
```
http://localhost:5555/v3/index.json
```
Спакуйте бібліотеку у NuGet-пакет:
```bash
cd Y_Andreieva
dotnet pack --configuration Release
```
Опублікуйте NuGet-пакет на локальний сервер
```bash
dotnet nuget push ./bin/Release/Y_Andreieva.1.0.0.nupkg -k NUGET-SERVER-API-KEY --source http://localhost:5555/v3/index.json
```
Тепер на порті ```http://localhost:5555``` можна побачити мій пакет
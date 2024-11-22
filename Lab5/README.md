﻿# Lab5
## Запуск застосунку
Перейдіть у папку застосунку:
```bash
cd Lab5/App
```

У файлі `appsettings.json` додайте свої дані для auth0: ClientId, Domain, ClientSecret.
Для прикладу ClientId, Domain вказаний мій, однак ClientSecret не публічний.

Після цього запустіть застосунок:
```bash
dotnet run
```

## Запуск на віртуальній машині
Щоб запустити віртуальну машину, з даної папки виконайте:
```bash
vagrant up
```

Після цього, під'єднайтеся до неї:
```bash
vagrant ssh
```

Перейдіть у папку з застосунком:
```bash
cd /vagrant/App
```

Додайте свої дані для auth0 як з першого пункту
Запустіть застосунок:
```bash
dotnet run
```
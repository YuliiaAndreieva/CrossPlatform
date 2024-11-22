# Lab4
## Запуск застосунку
Перейдіть у папку застосунку (Lab4), з цієї папки виконайте:
```bash
cd Lab4/App
```
Запустіть застосунок:
```bash
dotnet run
```
Команди:
```bash
dotnet run -- run lab{lab_number} -i {input_file_path} -o {output_file_path}
```
```bash
dotnet run -- -h
```
```bash
dotnet run -- set-path -p {path}
```
Запуск Baget
```bash
cd Lab4
docker-compose up
cd App
dotnet pack --configuration Release
dotnet nuget push ./bin/Release/Y_Andreieva.1.0.0.nupkg --source http://localhost:5555/v3/index.json
```
Тепер можна переглянути пакет на http://localhost:5555/

Запуск віртуальних машин:
```bash
vagrant up
```
dotnet restore
dotnet publish -c Release -o out
docker build -t rouletteserver .
docker run -p 8081:80 --name myrouletteserver rouletteserver
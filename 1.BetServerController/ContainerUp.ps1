dotnet restore
dotnet publish -c Release -o out
docker build -t betserver .
docker run -p 8082:80 --name mybetserver betserver
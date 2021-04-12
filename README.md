# Roulette Application

## Starting

_These instructions will allow you to get a copy of the project running on your local machine for development and testing purposes._

See **Local Deployment** to know how to deployment the project locally.


### Pre-requisites 📋

1. Install docker 
```
choco install docker-desktop
```

2. Install dotnet core 3.1
```
choco install dotnetcore
```

### API Documentation

See the documentation in:

* [RouletteServer](http://localhost:8081/swagger) - Swagger for RouletteServer
* [BetServerController](http://localhost:8082/swagger) - Swagger for BetServerCrontroller

Note: Consult after the deployment process

## Tools

_The tools used for this project were:_

* .Net Core 3.1 - Framework used to application
* SQL Server 2019 - Database
* Docker - Containerization
* AWS (RDS service) - Host database
* Powershell - Create scripts to local deployment

## Local Deployment

1. Run script _ContainerUp.ps1_ into BetServerController folder and wait while it completes
2. Run script _ContainerUp.ps1_ into RouletteServer folder and wait while it completes
3. Go to localhost:8081/* and localhost:8082/* to access to apps in a web browser

## Author

Miguel Angel Lara Alvarado


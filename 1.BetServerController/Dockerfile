FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
EXPOSE 80
COPY out/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "1.BetsServerController.dll"]
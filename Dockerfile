from mcr.microsoft.com/dotnet/sdk:6.0 as build

workdir /app

copy storeproject.sln ./
copy StoreprojectApi/*.csproj StoreprojectApi/
copy StoreBL/*.csproj StoreBL/
copy StoreDL/*.csproj StoreDL/
copy StoreprojectModel/*.csproj StoreprojectModel/
copy StoreprojectTest/*.csproj StoreprojectTest/


copy . ./


run dotnet build

run dotnet publish -c Release -o publish

from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime 

workdir /app
copy --from=build /app/publish ./


cmd ["dotnet", "StoreprojectApi.dll"]


expose 80
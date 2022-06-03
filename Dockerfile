
from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime 

workdir /app
copy  /publish ./

entrypoint ["dotnet", "StoreprojectApi.dll"]


expose 5000

env ASPNETCORE_URLS=http://+:5000
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app

COPY TodoTask.sln .
COPY TodosService/TodosService.csproj /app/TodosService/
COPY Repository/DataRepository.csproj /app/Repository/
COPY EndpointTests/EndpointTests.csproj /app/EndpointTests/
COPY ApiGateway/ApiGateway.csproj /app/ApiGateway/
COPY NotificationsService/NotificationsService.csproj /app/NotificationsService/

RUN dotnet restore

COPY . /app

RUN dotnet build
RUN dotnet tool install --global dotnet-ef

RUN chmod +x ./init.sh
CMD /bin/bash ./init.sh
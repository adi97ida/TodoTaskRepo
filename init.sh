#!/bin/bash

set -e
run_cmd="dotnet run --no-build --urls http://0.0.0.0:5000 -v d"

export PATH="$PATH:/root/.dotnet/tools"

until dotnet-ef database update --project "/app/TodosService/TodosService.csproj" --no-build; do
>&2 echo "SQL Server is not yet online"
sleep 1
done

>&2 echo "SQL Server is up - executing command"

dotnet-ef database update --project "/app/TodosService/TodosService.csproj"

>&2 echo "DB Migrations complete, starting app."
>&2 echo "Running': $run_cmd"
cd /app/TodosService
exec $run_cmd
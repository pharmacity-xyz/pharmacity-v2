#! /usr/bin/env bash
set -x
set -eo pipefail

if ! [ -x "$(command -v psql)" ]; then
    echo >&2 "Error psql is not installed."
    echo >&2 "Use:"
    echo >&2 "sudo apt-get install postgresql-client"
    exit 1
fi

if ! [ -x "$(command -v dotnet)" ]; then
    echo >&2 "Error dotnet is not installed."
    echo >&2 "Use:"
    echo >&2 "sudo apt update && sudo apt install dotnet6"
    exit 1
fi

# Check if a custom user has been set, otherwise default to 'postgres'
DB_USER=${POSTGRES_USER:=postgres}
# Check if a custom password has been set, otherwise default to 'password' 
DB_PASSWORD="${POSTGRES_PASSWORD:=password}"
# Check if a custom database name has been set, otherwise default to 'pharmacity-db' 
DB_NAME="${POSTGRES_DB:=pharmacitydb}"
# Check if a custom port has been set, otherwise default to 'pharmacity-db' 
DB_PORT="${POSTGRES_PORT:=5432}"

# Allow to skip Docker if a dockernized Postgres database is already running
if [[ -z "${SKIP_DOCKER}" ]]
then
docker run \
    -e POSTGRES_USER=${DB_USER} \
    -e POSTGRES_PASSWORD=${DB_PASSWORD} \
    -e POSTGRES_DB=${DB_NAME} \
    -p "${DB_PORT}":5432 \
    -d postgres \
    postgres -N 1000
fi

# Keep pinging Posgres until it's ready to accept commands
export PGPASSWORD="${DB_PASSWORD}"
until psql -h "localhost" -U "${DB_USER}" -p "${DB_PORT}" -d "postgres" -c "\q"; do
    >&2 echo "Postgres is still unavailable - sleeping"
    sleep 1
done

>&2 echo "Postgres is up and running on port ${DB_PORT} - running migrations now!"

# export DATABASE_URL=postgres://${DB_USER}:${DB_PASSWORD}@localhost:${DB_PORT}/${DB_NAME}
cd StoreAPI && dotnet ef migrations add first_migration --project StoreAPI.csproj
dotnet ef database update first_migration --project StoreAPI.csproj

>&2 echo "Postgres has been migrated, ready to go!"
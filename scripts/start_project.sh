#! /usr/bin/env bash
set -x
set -eo pipefail

cd StoreAPI

>&2 echo "Start project..."
dotnet run 
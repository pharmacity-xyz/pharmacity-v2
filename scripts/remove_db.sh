#! /usr/bin/env bash
set -x
set -eo pipefail

container_id=$(docker ps -aqf status=running)

echo "Stop docker ${container_id}"
docker stop ${container_id}

echo "Remove docker ${container_id}"
docker container rm ${container_id}

echo "Remove Migrations folder"
rm -rf BusinessObjects/Migrations/

echo "Successfully removed the db"
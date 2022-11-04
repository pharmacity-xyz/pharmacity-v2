# Pharmacity Server Program

## Overview

## Stacks

- [.NET6.0](https://learn.microsoft.com/en-us/dotnet/)
- [ASP.NET](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)
- [Docker](https://www.docker.com/)
- [Stripe API](https://stripe.com/docs/api/authentication?lang=dotnet)
- [Render](https://render.com)

## Getting Started

1. Init docker

```bash
./scripts/init_db.sh
```

If you have not installed docker, please [install](https://www.docker.com/)

2. Run the project

```bash
./scripts/start_project.sh
```

## Stripe CLI

```bash
 stripe listen --forward-to localhost:8000/api/payment
```

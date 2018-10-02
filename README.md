# tournamentAPI
[![Build Status](https://travis-ci.org/nnaricom/tournamentAPI.svg?branch=master)](https://travis-ci.org/nnaricom/tournamentAPI)
> Open-source .NET Core API for saving tournament info

## Table of Contents

1. [About tournamentAPI](#about-tournamentAPI)
2. [Getting started](#getting-started)
  * [Pre-Requisites](#pre-requisites)


## About tournamentAPI
HTTP REST API for storing and viewing Finland's Smash fighting game tournament information.

## Getting Started
```bash
$ dotnet restore
$ dotnet ef migrations add InitialCreate && dotnet ef update database
$ dotnet run```
The API is now running at `localhost:5000/api/tournament`
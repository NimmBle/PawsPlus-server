#!/bin/bash
dotnet ef "$@" -p Zoolandia.Infrastructure -s Zoolandia.Server

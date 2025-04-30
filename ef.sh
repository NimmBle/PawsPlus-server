#!/bin/bash
dotnet ef "$@" -p ./src/PawsPlus.Infrastructure -s ./src/PawsPlus.Startup

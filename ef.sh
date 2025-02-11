#!/bin/bash
dotnet ef "$@" -p PawsPlus.Infrastructure -s PawsPlus.Startup

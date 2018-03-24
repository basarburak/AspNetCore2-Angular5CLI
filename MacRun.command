#!/bin/bash  

echo Api uygulaması çalışıyor..

open -a Terminal "./Backend/Backend.Api"

# /Applications/Google\ Chrome.app/Contents/MacOS/Google\ Chrome --app="http://localhost:5050/"

echo Hosting uygulaması çalışıyor..

open -a Terminal "./NetCoreAngular.Hosting"

# /Applications/Google\ Chrome.app/Contents/MacOS/Google\ Chrome --app="http://localhost:5000/"

echo Angular CLI uygulaması çalışıyor..

open -a Terminal "./NetCoreAngular.Client"

# /Applications/Google\ Chrome.app/Contents/MacOS/Google\ Chrome --app="http://localhost:4200/"

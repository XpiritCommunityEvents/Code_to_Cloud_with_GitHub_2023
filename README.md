# GloboTicket Demo Application

This application is intended to demonstrate how to deploy an ASP.NET Core application to Azure Web Apps from GitHub.
It is the  project for the Visual Studio Live! "Code to Cloud with GitHub" Hands-On Labs by Marcel de Vries, René van Osnabrugge and Roy Cornelissen.

## Globoticket website
The globoticket website looks as follows when used:
![website screenshot](images/website-screenshot.png)

The website offers a way to buy tickets. You can select the quantity and check out.

## Globoticket Architecture
Globoticket uses two additional web api projects that provide an APIfor getting the 
catalog data and for registering the order when the order is completed.
this is shown in this architectural diagram below:

![architectural diagram](images/globoticket-architecture.png)

## Kubernetes deploymens
The book will take a step by step apporach to deploy this application first using containers
on the localhost using docker-compose.
Next the application will be deployed to a local kubernetes cluster running on the development machine
Then we wil deploy it to a cluster running in Azure, using AKS




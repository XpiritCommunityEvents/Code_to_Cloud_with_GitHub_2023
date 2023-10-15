# GloboTicket Demo Application

This application is intended to demonstrate how to deploy an ASP.NET Core application to Azure Web Apps from GitHub.
It is the  project for the Visual Studio Live! "Code to Cloud with GitHub" Hands-On Labs by Marcel de Vries, René van Osnabrugge, and Roy Cornelissen.

## Globoticket website
The globoticket website looks as follows when used:
![website screenshot](images/website-screenshot.png)

The website offers a way to buy tickets. You can select the quantity and check out.

## Globoticket Architecture
Globoticket uses two additional web API projects that provide an API for getting the 
catalog data and for registering the order when the order is completed.
This is shown in this architectural diagram below:

![architectural diagram](images/globoticket-architecture.png)

## Web App deployments
this workshop will take you on a journey where you will make changes to the application using copilot and learn how to make changes to a brownfield application. We will also add action workflows that will deploy the application to azure app services that have been created for you as part of your onboarding in this repo



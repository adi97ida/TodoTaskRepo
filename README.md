# General
This is a solved solution for the Consensus backend position assignment.

**Working features:**
 - CRUD operations on users, lists and list entries;
 - Swagger documentation for the microservices;
 - User post route test;
 - SMS notifications for list subscribed users;
 - Ocelot API gateway configured for the microservices;
 - Docker support for the microservices;

The solution contains the following projects:

 - **ApiGateway** -> The Ocelot API gateway configuration;
 - **DataRepository** -> The EF Core base database context, controllers database contexts and data models;
 - **NotificationsService** -> The service responsible for the SMS notifications;
 - **TodosService** -> The service responsible for the CRUD and the subscription logic;

# Used Frameworks and languages

 - ASP.NET Core (v3.1);
 - Entity Framework Core;
 - Swagger;
 - Serilog;
 - Ocelot API Gateway;
 - PostgreSQL

# How to use
**With docker:**

 - Run **docker-compose build**
 - Run **docker up**

**Without docker:**

 - Install PostgreSQL and adjust the connection string within the **appsetings.json** from the **TodosService** project
 - Run the **ApiGateway**, **NotificationsService** and **TodosService** projects;

# Improvements and refactoring
The solution would benefit a lot from the following actions:

 - Extend the Serilog within all the projects within the solution;
 - Implement scoped database contexts according to the models within the controllers;
 - Store all the sensitive tokens in a secure way (Maybe secure vaults);
 - Refactor and extend the response mechanisms for the endpoints;

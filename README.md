ContactManager Application

# Description

This is a Restfull API application for managing contacts. You can perform CRUD operations by making restful calls to this application. 
I have used Web API to implement restful service, Nunit for wrting testcases. This application uses static class for sample data
operations, However this application can be easily configured to use other data source by providing dependancy. For Dependancy injection
i have used Ninject IoC container.

# Requirements

1) Visual studio 2017
2) IIS Express (built in Visual studio 2017)
3) .Net framework 4.6.1
4) Ninject IoC container 3.3.4
5) Nunit Framework 3.10.1 

# Getting started

To run this application on local machine just clone the master branch on local machine and open the project solution file on 
visual studio 2017 and build the solution. Once the new debugging session is started the restful service 
can be accessed at http://localhost:49680/api/ContactManager .

Please read the API section in main page of application for more information related to perform CRUD operations.
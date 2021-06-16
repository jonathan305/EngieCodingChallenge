# The Solution is divided into 3 projects the A

Powerplant-Coding-Challenge.Api
Powerplant-Coding-Challenge.Dto
Powerplant-Coding-Challenge.Solver

The Dto project contains the strongly typed data transfer objects.  This project can be shared with the Api consumer.

The Solver project contains the algorithm and in theory could be further refactored to define an interface 

The Api project should be hosted on IIS or Azure App Service.

To build the project simply use Visual Studio (or Azure DevOps) to rebuild the solution and run it (F5).  
It will launch your webbrowser and you will see nothing that's because the Api Controller: ProductionPlanController
only has a Post Operation.  So you will need to use a Api Client "simulator" to invoke the Api.  

I used PostMan https://www.postman.com/support/ to invoke the Api using the 3 different example Payload files 
given in the documentation.

## Welcome !


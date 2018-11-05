# Lab19-API

## Web API for a To Do List and To Do Tasks

This is a basic C# Web API Application designed to handle API requests utilizing the CRUD method.

This application uses DOTNET Framework.

## API Endpoints

The deployed site can be found at :

https://todoapicf.azurewebsites.net

The API endpoints following the Home URL is:

\api\ToDo - returns JSON list of all To Do Items
\api\ToDo\{id} - returns JSON specific To Do Item by ID
\api\ToDoList - returns JSON list of all To Do List
\api\ToDoList\{id} - returns JSON specific To Do List by ID

## CRUD Operations

\api\ToDo\{id} 
\api\ToDoList\{id}

A GET request to the aforementioned Endpoint will return a specific item or list
A POST request to  to the aforementioned Endpoint will create the specific action via the following format:

For ToDo

{
  "name": "Example Task",
  "status": boolean true/false,
  "listID": ID of the associated List
}

For ToDoList

{
  "listName": "Example List"
}

A PUT request to the aforementioned Endpoint will update by ID
A DELETE request will delete by ID

## Version

V1.0 - Basic API for To Do List and To Do Item

## Requirements

Visual Studios 2017 or equivalent C# IDE

Entity Framework CORE

Microsoft SQL Database.

.NET Core 2.1 SDK

POSTMAN for CRUD operations

Azure or other online PAAS for hosting.

## Instructions

Clone this repo to local storage and open it up using Visual Studios 2017.

Open the API.sln solution located in the Async-Inn folder.

Run IISExpress to host the webpages locally. The Web Browser should automatically open and redirect you to the Landing Page.

Create associated SQL database.

Use the API endpoints to conduct operations.

Deploy to online web host if desired.


## Testing

Testing was conducted on each CRUD operation for each specific model. See XunitTesting folder.

## Result

V1.0
![Console](Capture.PNG?raw=true "Output")
![Console](Capture2.PNG?raw=true "Output")
![Console](Capture3.PNG?raw=true "Output")
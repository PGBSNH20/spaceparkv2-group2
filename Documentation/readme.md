# Documentation

## Docker Compose
Created a docker-compose.yml file with the api, and the SQL image, along with the volumes to make sure the SQL always starts with tables.
The input string is as follows: 
![image](https://user-images.githubusercontent.com/70092696/117325092-b3343980-ae90-11eb-9f54-366f18b94601.png)

The **spaceparkdb** is grabbed from our docker-compose.yml file and we give it our container port **1433** this is important because we can then when working in visual studio press our *CTRL+F5* or our *Docker compose* play button, and we can interact with the database with postman/Swagger or what-have-you. We ran into an issue with the connection string, because you are talking to the containerport we can talk to it, but visual studio can't talk to it this way, so if we try to *update* the database then it wont let us because it can't find the database, so insted we have to go into the CMD under our SpaceparkModel folder and type in the following string: 
>dotnet ef database update --connection "Server=localhost,41434;Initial Catalog=SpaceParks;User Id=sa;Password=verystrong!pass123;"

This is the only way to update the database. It was also encountered some issues with the NuGet packages of the newest version 5.0.5 and ended up rolling them back to their old format because the database didn't want  to work with the new version, so currently using **5.0.4** 

## DTO's
Added the *DTO*'s in order to specify which information the api gets to view, to make the API more secure these Data Transfer objects are made, so we don't display for example the Id's or if we had credit card information it wouldn't be shown.

## Appsettings.json
This is just a settings file, it is added the apikey here, so it's there, not hard coded in different places. Everything else on this fine is as how it was auto generated.

## Middlewares
Two files were added for this one, APIKeyMiddleware.cs, and APIKeyMiddlewareExtensions.cs, 

## Input Validations
We did this by adding attributes to the tables that would be used by the API for for example the person table on the name got a [Required] and a [StringLength(255)] when the name gets entered into the api it just automatically checks if the char count exceeds 255, (the 255 char I just googled what is normal max length). Because we are using attributes on the tables, in the controllers we added a new file for People where is uses Person's objects and it can use the attributes added there, so if you want to search for a person there.

![image](https://user-images.githubusercontent.com/70092696/117413180-f1c00780-af15-11eb-8f3c-026db46b2821.png)


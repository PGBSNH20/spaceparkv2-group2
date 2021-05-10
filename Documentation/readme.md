# Documentation

## Docker Compose
Created a docker-compose.yml file with the api, and the SQL image, along with the volumes to make sure the SQL always starts with tables.
The input string is as follows: 
![image](https://user-images.githubusercontent.com/70092696/117325092-b3343980-ae90-11eb-9f54-366f18b94601.png)

The **spaceparkdb** is grabbed from our docker-compose.yml file and we give it our container port **1433** this is important because we can then when working in visual studio press our *CTRL+F5* or our *Docker compose* play button, and we can interact with the database with postman/Swagger or what-have-you. We ran into an issue with the connection string, because you are talking to the containerport we can talk to it, but visual studio can't talk to it this way, so if we try to *update* the database then it wont let us because it can't find the database, so insted we have to go into the CMD under our SpaceparkModel folder and type in the following string: 
>dotnet ef database update --connection "Server=localhost,41434;Initial Catalog=SpaceParks;User Id=sa;Password=verystrong!pass123;"

This is the only way to update the database. It was also encountered some issues with the NuGet packages of the newest version 5.0.5 and ended up rolling them back to their old format because the database didn't want  to work with the new version, so currently using **5.0.4**  on **all** NuGet packages.

## DTO's
Added the *DTO*'s in order to specify which information the api gets to view, to make the API more secure these Data Transfer objects are made, so we don't display for example the Id's or if we had credit card information it wouldn't be shown.

## Appsettings.json
This is just a settings file, it is added the apikey here, so it's there, not hard coded in different places. Everything else on this fine is as how it was auto generated.

## Middlewares
Two files were added for this one, APIKeyMiddleware.cs, and APIKeyMiddlewareExtensions.cs, we get our requests for the API and we just make sure that there is an api key, it must be there, and these files just check that there is a api key, if there is the invoke method just deals if there is or not. 
The extension file was added so in the startup.cs it would all look unison, so  app.UseAPIKey(apikey) this is simply to make it easier to read for anyone.

## Input Validation
We did this by adding attributes to the tables that would be used by the API for for example the person table on the name got a [Required] and a [StringLength(255)] when the name gets entered into the api it just automatically checks if the char count exceeds 255, (the 255 char I just googled what is normal max length). Because we are using attributes on the tables, in the controllers we added a new file for People where is uses Person's objects and it can use the attributes added there, so if you want to search for a person there.

![image](https://user-images.githubusercontent.com/70092696/117413180-f1c00780-af15-11eb-8f3c-026db46b2821.png)

## Users
Two type of users were added; Visitors which is for the normal Star Wars people that come and use the SpacePark, and then Admin, who is in change the one Deleting things, and adding new SpaceParks.

A new folder was added to the project called "Authentication" which is where the tables and models are added. 

In the appsettings.json a new section was added for the JSON Web Tokens (JWT) for the user authentication

![image](https://user-images.githubusercontent.com/70092696/117545011-35a13280-b024-11eb-9bf5-ae0649f0f8ea.png)

So now in Swagger we can register a new person, Bobbie but in order to do anything we have to give it the ApiKey(Located in the appsettings.json in this case "CSharpIsFun")

Then we can go to the Login, enter the Apikey, and enter our name, (we didn't add a option to put a password since it wasn't in the instructions) press *Execute* and we will get a response back, in the response body, we will need the token; so we take everything inside the quotation marks 

![image](https://user-images.githubusercontent.com/70092696/117545432-08558400-b026-11eb-95a4-2c6e6115d94f.png)

We then with our copied token, click on the Authorize button all the way on the top-right-corner of our SpaceParkAPI swagger page

![image](https://user-images.githubusercontent.com/70092696/117545483-4488e480-b026-11eb-84a0-6f14891fb2bf.png)

We will be entering: "Bearer *your token here*"

![image](https://user-images.githubusercontent.com/70092696/117545536-7ac66400-b026-11eb-82bb-8f1cc71a69bc.png)

Authorize then close. After that the user should be able to use the other commands in the API with no problem. For example  the *Get* /parking we enter our Apikey and *Execute* and it should look something like this

![image](https://user-images.githubusercontent.com/70092696/117545609-d09b0c00-b026-11eb-8ae3-7f21084cefc2.png)

We also added a Authorization in the controllers, so if you are a Visitor and you try to add a new SpacePark, the visitor user will not be able to do that, it will give out a *403 Error*

![image](https://user-images.githubusercontent.com/70092696/117545784-8fefc280-b027-11eb-80b0-02fb919e58ff.png)

Now if it was a Administrator trying to use the same function it should look something like this: 

![image](https://user-images.githubusercontent.com/70092696/117545898-0b517400-b028-11eb-87c4-846605ccc4d1.png)


# Documentation

## Docker Compose
Created a docker-compose.yml file with the api, and the SQL image, along with the volumes to make sure the SQL always starts with tables.
The input string is as follows: 
![image](https://user-images.githubusercontent.com/70092696/117325092-b3343980-ae90-11eb-9f54-366f18b94601.png)

The **spaceparkdb** is grabbed from our docker-compose.yml file and we give it our container port **1433** this is important because we can then when working in visual studio press our *CTRL+F5* or our *Docker compose* play button, and we can interact with the database with postman/Swagger or what-have-you. We ran into an issue with the connection string, because you are talking to the containerport we can talk to it, but visual studio can't talk to it this way, so if we try to *update* the database then it wont let us because it can't find the database, so insted we have to go into the CMD under our SpaceparkModel folder and type in the following string: 
>dotnet ef database update --connection "Server=localhost,41434;Initial Catalog=SpaceParks;User Id=sa;Password=verystrong!pass123;"

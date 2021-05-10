## Base: /api

### Authenticate
This has been added to have users, in the instructions it is stated to have Visitors (so the star wars people that come to park their spaceships) and also administrators

Request Type | URL | Description
------------ | --- | -----------
| Post | /Authenticate/Login | This lets a user log in to the system. |
| Post | /Authenticate/register | This will register a new user (a visitor) |
| Post | /Authenticate/register-admin | This will register a new admin-user |


### Occupancies 
This is our table on SQL that has the Occupancies of SpaceParks so in the controllers the class is named OccupanciesController, but for api purposes we named it parking.

Request Type | URL | Description
------------ | --- | -----------
| Get | /parking | Give back a list of current parked ships. |
| Post | /parking | Register a parking, with a Occupancy Object, using this to validate the information in the database |
| Get | /parking/{id} | Gives back a specific parked ship according to the Id. |
| Post | /parking/register/{spaceparkid}/{person}/{spaceship} | Parks a spaceship according to the SW name given. **Validates** that it's a SW person, along with a  correct spaceship in the *background* |
| Get | /parking/person/{name} | Searches for parking depending on name given, **validates** after a Star Wars character name in the background. |
| Post | /parking/unpark/{spaceparkid}/{person} | Unparks a person *depending* on the name given, gives back the **amount paid** along with **hours** that they stayed |
| Get | /parking/history | Gives back *all* of the history reconds on the occupancy table |
| Get | /parking/history/{person} | Give back the history of a *specified* person. |

> The **/parking/unpark/{spaceparkid}/{person}** something to note is that unpark is a verb, I could not find another word to use that would make better or easier sense in Nouns, I understand that in Rest-API it is taboo/ a-big-no-no to use verbs, but in this case, it just makes the most sense.

### SpaceParks
Spacepark is a table in SQL that holds the different SpaceParks, each occupancy has a *SpaceParkId* which says which spacepark that occupancy is at, the relationship between the tables are as follows; *One Spacepark can have many Occupancies*

Request Type | URL | Description
------------ | --- | -----------
| Get | /spacepark | Gives back all of the spaceparks |
| Post | /spacepark | Adds a new spacepark |
| Get | /spacepark/{id} | Gets the spacepark according to the id given |
| Delete | /spacepark/{id} | Deletes a spacepark according to the id given |
| Post | /spacepark/register/{name} | Registers a new park |

### People
This controller is not part of the assigment, because the assigment doesn't say to ask to make new people, but I'm leaving them there in order to have the people be validated by char length in the Parking's people are getting validated by the SWApi to make sure they are star wars people, here the validation is just for a char length of 255.

Request Type | URL | Description
------------ | --- | -----------
| Get | /People | Gets the id, and the name of each person if they are in the database |
| Post | /People | You add a new person to the SQL table, with id, and name |
| Get | /People/{id} | Gets the person by the id |
| Delete | /People/{id} | Deletes a person by the id given |

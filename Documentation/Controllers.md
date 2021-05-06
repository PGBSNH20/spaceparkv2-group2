## Base: /api

### Occupancies 
This is our table on SQL that has the Occupancies of SpaceParks so in the controllers the class is named OccupanciesController, but for api purposes we named it parking.

Request Type | URL | Description
------------ | --- | -----------
| Get | /parking | Give back a list of current parked ships. |
| Post | /parking | Register a parking, with a Occupancy Object, using this to validate the information in the database |
| Get | /parking/{id} | Gives back a specific parked ship according to the Id. |
| Post | /parking/register/{spaceparkid}/{person}/{spaceship} | Parks a spaceship according to the SW name given. **Validates** that it's a SW person, along with a  correct spaceship in the *background* |
| Get | /parking/search/{name} | Searches for parking depending on name given, **validates** name in the background. |
| Post | /parking/unpark/{spaceparkid}/{person} | Unparks a person *depending* on the name given, gives back the **amount paid** along with **hours** that they stayed |
| Get | /parking/history | Gives back *all* of the history reconds on the occupancy table |
| Get | /parking/history/{person} | Give back the history of a *specified* person. |

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
This controller is not part of the assigment, because the assigment doesn't say to ask to make new people, but I'm leaving them there in order to have the people be validated if so they choose to.

Request Type | URL | Description
------------ | --- | -----------
| Get | /People | Gets the id, and the name of each person |
| Post | /People | You add a new person to the sql table, with id, and name |
| Get | /People/{id} | Gets the person by the id |
| Delete | /People/{id} | Deletes a person by the id given |

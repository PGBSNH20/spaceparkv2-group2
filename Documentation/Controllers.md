## Base: /api

### Occupancies 
This is our table on SQL that has the Occupancies of SpaceParks

Request Type | URL | Description
------------ | --- | -----------
| Get | /parking | Give back a list of current parked ships. |
| Get | /parking/{id} | Gives back a specific parked ship according to the Id. |
| Patch | /parking/{id} | Changes some of the information on the parking |
| Get | /parking/search/{name} | Searches for parking depending on name given, **validates** name in the background. |
| Post | /parking/register/{spaceparkid}/{person}/{spaceship} | Parks a spaceship according to the SW name given. **Validates** that it's a SW person, along with a  correct spaceship in the *background* |
| Post | /parking/unpark/{spaceparkid}/{person} | Unparks a person *depending* on the name given, gives back the **amount paid** along with **hours** that they stayed |
| Get | /parking/history | Gives back *all* of the history reconds on the occupancy table |
| Get | /parking/history/{person} | Give back the history of a *specified* person. |

### SpaceParks
This is a table that holds the different spaceparks, each occupancy has a *SpaceParkId* which says which space park that occupancy is correlating to

Request Type | URL | Description
------------ | --- | -----------
| Get | /spacepark | Gives back all of the spaceparks

## Base: /api

### Occupancies 
This is our table on SQL that has the Occupancies of SpaceParks

Request Type | URL | Description
------------ | --- | -----------
| Get | /parking | Give back a list of current parked ships. |
| /parking/{id} | Gives back a specific parked ship according to the Id. |
| /parking/search/{name} | Searches for parking depending on name given, **validates** name in the background. |
| /parking/register/{person}/{spaceship} | Parks a spaceship according to the SW name given. **Validates** that it's a SW person, along with a  correct spaceship in the *background* |
| /parking/unpark/{person} | Unparks a person *depending* on the name given, gives back the **amount paid** along with **hours** that they stayed |
| /parking/history | Gives back *all* of the history reconds on the occupancy table |
| /parking/history/{person} | Give back the history of a *specified* person. |

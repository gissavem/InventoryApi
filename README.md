## Design pattern motivations :speech_balloon:	
### Visitor :heavy_check_mark:	

Creating relevant responses while iterating over collections is made easy by utilizing a visitor pattern.
Both when I add the total amount of all ingredients and when getting the current inventory.

### Singleton :x:	

I could have chosen to register the ```IIventoryService```
 as a singleton in Startup and call it a day, but I chose to instead use a scoped instance for the injection of the service. In .NET there is built in methods for these different approcaches when configuring dependency injection. A Singleton is always the same instance across all uses in the application. Scoped objects on the other hand are the same within a request, but different across different requests. 

The reasoning behind this is mostly that there is no real need for a Singleton in this case. 
Dependency injection in .NET makes it so easy to get the service my controller depend on at the right time so I can't motivate for myself a good reason to use a Singleton here.

Furthermore my guess is that scoped instances would be easier to extend for logging and asynchronus use if the application were to evolve, 
but I won't make any strong claims about this.

## Testing :test_tube:
Most of the tests I wrote are using a in memory version of SQLite-DB that enables me to control state before tests and then assert that the changes I intend for the operations actually go through. Even though it may be argued that these tests are less reliable than pure unit tests, I would argue that these tests are a good option to ensure that my application is doing what I want. Especially since the application more or less focuses on keeping track of an inventory. 

I decided to add the test projects of both the existing PizzaApi and the new InventoryApi to respective Dockerfiles to enable testing when building the image of the containers.
This enabled me to make sure that all tests were passing when building all containers for the application with docker-compose.

#### // John Andersson :mage:
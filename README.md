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

### End-to-end testing :left_right_arrow:	

I did not bother to add the e2e-tests to the build pipeline as it felt a bit over the top and I was also uncertain if it is the best practice.

When it comes to making sure the e2e-tests does not actually change 'production' data I decided to run e2e-test in a seperate instance. This testing environment is identical to the production environment in all regards except that it does not import the volume that the application reads and writes from for persistance. 

Instead it creates a new .db-file in the root directory of the container that has the same mannerism as the 'production' .db-file. The real differance is that it is discarded when the container shuts down. This approach lets me avoid creating endpoints and clean-up methods in the application but still being able to use persistance for the e2e-tests.

There is a clear disadvantage with these e2e-tests. If any of the preceeding tests fail, the following tests most likely will fail also. 

## Running the application :runner:

To run the application **in development mode** where the e2e-tests can be executed run the following commands in the root folder of the project.

>1. #### ```docker-compose up -d```
>2. #### ```cypress run``` or ```cypress open```
>3. Done! (note that the container has to be restarted every time you want to run the suite of e2e-tests)

To run the application **in production mode** with 'true' persistance.

>1. #### ```docker-compose -f docker-compose.yml -f docker-compose.prod.yml up -d```
>2. Done!
 
 
Have fun!


#### // John Andersson :mage:

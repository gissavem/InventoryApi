# InventoryApi: a study in integration, Docker, and design patterns by John Andersson

## Design pattern motivation



### Singleton

I could have chosen to register the **IIventoryService** as a singleton in Startup and call it a day, but I chose to instead use a scoped instance for the inection of the service.

Scoped objects are the same within a request, but different across different requests. Singleton objects are the same for every object and every request.

### Singleton

I could have chosen to register the **IIventoryService** as a singleton in Startup and call it a day, but I chose to instead use a scoped instance for the injection of the service.

The reasoning behind this is mostly that there is no real need for a Singleton in this case. 
Dependency injection in .NET makes it so easy to get the service my controller depend on at the right time so I can't motivate for myself a good reason to use a Singleton here.

Furthermore my guess is that scoped instances would be easier to extend for logging and asynchronus use if the application were to evolve, 
but I won't make any strong claims about this.

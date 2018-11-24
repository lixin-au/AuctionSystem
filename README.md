# AuctionSystem
Demo solution for a highly simplified auction system. The sever side is ASP.NET Core. The client side is React.

As a quick implementation done in short time frame, this solution has scalability problems,

- Bidding can only be transacted within a single process.
- As the service and corresponding repository are mocks, no consistency with optimal performance is available for bidding. A lock is being used on each bid to provide basic consistency. Roll-back or compensation is also unavailable.
- Client side polling for getting auction states could be too intensive to the server.

Improvement can be done with the following changes,

- Using a service bus and sagas for bidding.
- Using SignalR and WebSocket to implement server push to the client side app.

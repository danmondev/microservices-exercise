# A short microservices exercise

This repository contains several .NET 7 projects and source files for illustrating a simple implementation of two microservices and communication among them.

## Structure

Here you'll find two microservices in the form of .NET 7 WebApi projects as well as a class library and NuGet Package used for sharing implementations among both services.

### The Common project and NuGet package

This contains logic common to both microservices such as DTO classes, contracts, and service setup logic. From this project, a NuGet Package is generated which in turn is referenced within the microservices projects. To run the code, you might need to set up a local NuGet feed pointing to the folder containing the [Common.1.0.2.nupkg](common/package-output) package. This can be done using the following:

```
> dotnet nuget add source SOURCE_DIR -n SOURCE_NAME
```

Where `SOURCE_DIR` will point to the path in your local filesystem, and `SOURCE_NAME` can be any arbitrary name to identify the source.

You can refer to the [NuGet documentation](https://learn.microsoft.com/en-us/nuget/hosting-packages/local-feeds) for more details on this.

### The Books Service

The source files can be found under [/books-service](/books-service/src/BooksService/). This is a WebApi project that sets up a controller ([BooksController](books-service/src/BooksService/Controllers/BooksController.cs)) exposing a single endpoint that can be reached through an `HTTP GET` request. It will return a JSON response that looks something like this:

```
[
    {
        "id": 1,
        "name": "Book Title 1",
        "description": "Book Description",
        "url": "Optional URL"
    },
    {
        "id": 2,
        "name": "Book Title 2",
        "description": "Book Description"
    }
]
```
The application also sets up MassTransit using a RabbitMQ service bus, as well as registering a consumer instance ([BooksRecommendationsRequestedConsumer](books-service/src/BooksService/Consumers/BooksRecommendationsRequestedConsumer.cs)). This is described in more detail further below.

### The Readers Service

The source files can be found under [/readers-service](/books-service/src/ReadersService/). This is also a WebApi project, it sets up the controller [ReadersController](readers-service/src/ReadersService/Controllers/ReadersController.cs) which exposes a couple of endpoints for communicating with the `BooksService` and requesting a list of books.

## Communication among microservices

For enabling communication among two microservices I've illustrated two approaches in this code.

### REST/HTTP

The first one makes use of an `HttpClient` for directly requesting a resource from one microservice to another (`ReadersService` → `BooksService`). This of course creates a tight coupling between the two microservices as the _client_ microservice needs to be aware of specific details about the _provider_ (such as the host URL).

### MassTransit and RabbitMQ

The second approach removes this coupling by introducing the use of a message broker (RabbitMQ). To enable this, both microservices must connect to a service bus (in this case using _MassTransit_). Here, instead of directly requesting a resource from a microservice, we rely on producing events and having consumers react to said events as they appear in the message bus.

The [BooksRecommendationsRequested](common/Contracts/Contracts.cs) and [BooksRecommendationsProvided](common/Contracts/Contracts.cs) record types serve to represent the two events we will be reacting to.
The [BooksRecommendationsRequestedConsumer](books-service/src/BooksService/Consumers/BooksRecommendationsRequestedConsumer.cs) and [BooksRecommendationsProvidedConsumer](readers-service/src/ReadersService/Consumers/BooksRecommendationsProvidedConsumer.cs) classes respectively represent the consumers that will react to the events.

Using this approach, when we call the `readers/getrecommendationsasync` endpoint the `ReadersService` will start by firing a `BooksRecommendationsRequested` event using the `IPublishEndpoint` instance found in the Controller. The message will get pushed onto the message bus, subsequently the `BooksRecommendationsRequestedConsumer` will pick up said message and respond with an event of its own (`BooksRecommendationsProvided`), containing the expected payload. A consumer called `BooksRecommendationsProvidedConsumer` in the `ReadersService` will collect the event from the bus and log the results accordingly.

### RabbitMQ

I've used a local installation of RabbitMQ for testing this, but you can use a `docker` image for running this sample. I've provided a (`yml` file)[container/docker-compose.yml] for this.

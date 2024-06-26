[![Build status](https://github.com/EasyNetQ/EasyNetQ/workflows/CI/badge.svg)](https://github.com/EasyNetQ/EasyNetQ/actions?query=workflow%3ACI)

[![NuGet Status](https://img.shields.io/nuget/v/EasyNetQ)](https://www.nuget.org/packages/EasyNetQ)
[![Nuget Status](https://img.shields.io/nuget/vpre/EasyNetQ)](https://www.nuget.org/packages/EasyNetQ/absoluteLatest)
[![Nuget Status](https://img.shields.io/nuget/dt/EasyNetQ)](https://www.nuget.org/packages/EasyNetQ)

![Activity](https://img.shields.io/github/commit-activity/w/EasyNetQ/easynetq)
![Activity](https://img.shields.io/github/commit-activity/m/EasyNetQ/easynetq)
![Activity](https://img.shields.io/github/commit-activity/y/EasyNetQ/easynetq)
--

![EasyNetQ Logo](https://github.com/EasyNetQ/EasyNetQ/wiki/images/logo_design_150.png)

A Nice .NET API for RabbitMQ

Initial development was sponsored by travel industry experts [15below](http://15below.com/)

* **[Homepage](http://easynetq.com)**
* **[Documentation](https://github.com/EasyNetQ/EasyNetQ/wiki/Introduction)**
* **[NuGet](http://www.nuget.org/packages/EasyNetQ)**
* **[Discussions](https://github.com/EasyNetQ/EasyNetQ/discussions)**
* **[~Old Discussion Group~](https://groups.google.com/group/easynetq)**

Goals:

### Important Update

With the release of EasyNetQ v8, the method for connecting to a RabbitMQ broker has changed. The rest of the API remains unchanged.

To make working with RabbitMQ on .NET as easy as possible.

To connect to a RabbitMQ broker in v7...
```c#
    var bus = RabbitHutch.CreateBus("host=localhost");
```

To connect to a RabbitMQ broker in v8...
```c#
    var serviceCollection = new ServiceCollection();
    serviceCollection.AddEasyNetQ("host=localhost").UseSystemTextJson();

    using var provider = serviceCollection.BuildServiceProvider();
    var bus = provider.GetRequiredService<IBus>();
```

To publish a message...
```c#
    await bus.PubSub.PublishAsync(message);
```

To publish a message with a 5s delay...
```c#
    await bus.Scheduler.FuturePublishAsync(message, TimeSpan.FromSeconds(5));
```

To subscribe to a message...
```c#
    await bus.PubSub.SubscribeAsync<MyMessage>(
        "my_subscription_id", msg => Console.WriteLine(msg.Text)
    );

```
Remote procedure call...
```c#
    var request = new TestRequestMessage {Text = "Hello from the client! "};
    await bus.Rpc.RequestAsync<TestRequestMessage, TestResponseMessage>(request);
```

RPC server...
```c#
    await bus.Rpc.RespondAsync<TestRequestMessage, TestResponseMessage>(request =>
        new TestResponseMessage{ Text = request.Text + " all done!" }
    );
```

## Getting started

Just open EasyNetQ.sln in your preferred IDE or code editor and build. All the required dependencies for the solution file to build the software are included.

## Contributors

Thanks to all the people who already contributed!

<a href="https://github.com/EasyNetQ/EasyNetQ/graphs/contributors">
  <img src="https://contributors-img.web.app/image?repo=EasyNetQ/EasyNetQ" />
</a>

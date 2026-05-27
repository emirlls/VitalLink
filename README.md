# VitalLink - Enterprise Blood & Life Network Backend

VitalLink is a highly scalable, event-driven enterprise backend application developed to accelerate blood and platelet donation processes. It bridges the gap between donors and those in urgent need by utilizing smart filtering and location-based matching algorithms.

## 🚀 Architectural & Technical Highlights

- **Domain-Driven Design (DDD):** The core business logic is structured entirely around DDD principles (Aggregates, Value Objects, Domain Events) to ensure maintainability, testability, and a loosely coupled architecture.
- **Asynchronous Event-Driven Architecture (Distributed Event Bus):** Implemented a distributed event bus powered by **RabbitMQ**. Critical system events—such as new blood requests or donor matches—are handled asynchronously via robust message queuing.
- **Real-Time Communication (SignalR):** Instant messaging and high-priority notification flows between donors and request owners are delivered in real-time using **SignalR** WebSocket infrastructure.
- **High-Performance Caching (Redis Cache):** Frequently queried data, including location matrices, hospital lists, and suitable donor filters, are cached via **Redis Distributed Cache** to minimize database overhead and guarantee sub-millisecond responses.
- **Smart Matching System:** Advanced endpoints combine user profile data and proximity filters using Redis-backed queries to fetch the most relevant emergency requests instantly.

## 🛠️ Tech Stack & Ecosystem

- **Runtime & Language:** .NET 10 / C# 14
- **Framework:** ABP Framework
- **Architecture:** Domain-Driven Design (DDD) & Layered Architecture
- **Message Broker:** RabbitMQ (Distributed Event Bus)
- **Real-Time Communication:** SignalR
- **Caching:** Redis Distributed Cache
- **ORM & Database:** Entity Framework Core

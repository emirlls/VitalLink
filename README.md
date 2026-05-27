# VitalLink - Enterprise Blood & Life Network Backend

VitalLink is a highly scalable, event-driven enterprise backend application developed to accelerate blood and platelet donation processes. It bridges the gap between donors and those in urgent need by utilizing smart filtering and location-based matching algorithms.

## 🚀 Architectural & Technical Highlights

- **Domain-Driven Design (DDD):** The core business logic is structured entirely around DDD principles (Aggregates, Value Objects, Domain Events) to ensure maintainability, testability, and a loosely coupled architecture.
- **Secure Identity & Access Management (OpenIddict):** Authentication and authorization infrastructure are secured using **OpenIddict**. The system implements OAuth2 and OpenID Connect protocols to issue secure access tokens, managing user sessions and client applications safely.
- **API Rate Limiting & Security:** To protect endpoints from brute-force, scraping, and DDoS attacks, global and endpoint-specific **Rate Limiting** policies are implemented, ensuring high availability and system stability under heavy load.
- **Asynchronous Event-Driven Architecture (Distributed Event Bus):** Implemented a distributed event bus powered by **RabbitMQ**. Critical system events—such as new blood requests or donor matches—are handled asynchronously via robust message queuing.
- **Real-Time Communication (SignalR):** Instant messaging and high-priority notification flows between donors and request owners are delivered in real-time using **SignalR** WebSocket infrastructure.
- **High-Performance Caching (Redis Cache):** Frequently queried data, including location matrices, hospital lists, and suitable donor filters, are cached via **Redis Distributed Cache** to minimize database overhead and guarantee sub-millisecond responses.
- **Smart Matching System:** Advanced endpoints combine user profile data and proximity filters using Redis-backed queries to fetch the most relevant emergency requests instantly.

## 🛠️ Tech Stack & Ecosystem

- **Runtime & Language:** .NET 10 / C# 14
- **Framework:** ABP Framework
- **Identity & OAuth2:** OpenIddict
- **API Security:** .NET Rate Limiting Middleware
- **Architecture:** Domain-Driven Design (DDD) & Layered Architecture
- **Message Broker:** RabbitMQ (Distributed Event Bus)
- **Real-Time Communication:** SignalR
- **Caching:** Redis Distributed Cache
- **ORM & Database:** Entity Framework Core & PostgreSQL



## 📸 Screen Designs / Arayüz Tasarımları

<div flex-direction="row" style="display: flex; gap: 16px; align-items: center; justify-content: center; flex-wrap: wrap;">
  <img width="260" alt="VitalLink Mobile UI" src="https://github.com/user-attachments/assets/b154a6f0-ece1-43af-8546-bf2374081d77" style="border-radius: 12px; border: 1px solid #e1e4e8; shadow: 0px 4px 12px rgba(0,0,0,0.05);" />
  
  <img width="500" alt="VitalLink Web Dashboard" src="https://github.com/user-attachments/assets/7e6fb744-083a-4946-8721-966e90a8d554" style="border-radius: 12px; border: 1px solid #e1e4e8; shadow: 0px 4px 12px rgba(0,0,0,0.05);" />
</div>


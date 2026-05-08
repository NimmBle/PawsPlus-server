# PawsPlus Server

Production backend for [PawsPlus](https://pawsplus.eu/), a platform that connects pet owners with sitters and manages the full lifecycle around listings, pets, bookings, reviews, media, and notifications.

## Overview

Production-grade backend focused on clear architectural boundaries, explicit use-case modelling, and domain-first decomposition across a growing feature set.

Core product areas:

- authentication and account lifecycle
- owner and sitter profiles
- pet management
- sitter listings and service definitions
- booking orchestration and status transitions
- review flows after completed services
- media upload handling
- email and push notification workflows
- scheduled booking automation

## Architecture

```text
src/
  PawsPlus.Startup        Composition root
  PawsPlus.Web            HTTP API layer
  PawsPlus.Application    Commands, queries, handlers, DTOs
  PawsPlus.Domain         Business model, rules, value objects
  PawsPlus.Infrastructure Persistence, identity, external integrations

tests/
  Application.UnitTests
  Domain.UnitTests
  Application.IntegrationTests
  Tests.Common

funtions/
  BookingDeclineAfterAnHour
  BookingComplete
```

The system follows a layered architecture with clear dependency direction:

- `Domain` holds the core model and business rules.
- `Application` expresses behavior as use cases.
- `Infrastructure` isolates persistence and third-party services.
- `Web` stays thin and exposes the API surface.
- `Startup` wires the system together.

This structure keeps feature growth manageable and prevents framework code from swallowing business logic.

## Engineering Approach

### Use-case driven application layer

The application layer is organized around commands and queries instead of broad service classes. Each action is modeled explicitly: creating a booking, approving a booking, completing a booking, approving a sitter post, editing a pet, and so on.

The result is traceable behavior, focused tests, and lower-risk change.

### Domain-first modelling

The domain is more than EF entities. It contains dedicated models, enums, value objects, factories, and validation-focused exception types.

Examples include:

- value objects such as `Age`, `Location`, `HealthStatus`, and `Personality`
- domain models such as `Pet`, `Post`, `Booking`, `Review`, and `Service`
- repository abstractions that keep business logic decoupled from persistence details

Product rules live in the model, not in controllers or SQL-shaped objects.

### Thin transport layer

Controllers are intentionally lightweight. They receive HTTP requests, enforce authorization boundaries, and dispatch application requests. Business logic is pushed downward into the application and domain layers where it belongs.

### Infrastructure kept at the edge

External systems are isolated behind infrastructure implementations:

- SQL Server via EF Core
- ASP.NET Core Identity + JWT
- Cloudinary for media
- SendGrid for transactional email
- Firebase Admin SDK for push notifications

The boundary keeps the core codebase stable while integrations remain replaceable.

### Operational logic beyond request/response

Two Azure Functions handle time-based booking maintenance:

- stale pending bookings are declined automatically
- finished bookings are completed automatically when their end time passes

Operational workflows stay out of the HTTP path and run in dedicated scheduled processes.

## API Surface

Main functional areas:

- `Identity`
- `Profiles`
- `Pets`
- `Posts`
- `Services`
- `Bookings`
- `Reviews`
- `Files`
- `Notifications`
- `Breeds`

The API surface is split by business capability instead of by generic CRUD buckets.

## Technology Stack

- ASP.NET Core 8 Web API
- Entity Framework Core 8
- SQL Server
- ASP.NET Core Identity
- JWT authentication
- MediatR
- FluentValidation
- AutoMapper
- Swagger / OpenAPI
- Cloudinary
- SendGrid
- Firebase Admin SDK
- Azure Functions
- xUnit, Shouldly, NSubstitute

The stack is conventional by design. The strength of the project is in composition, boundaries, and feature modelling rather than novelty.

## Testing Strategy

The test suite is split by responsibility:

- domain unit tests for business rules
- application unit tests for use-case behavior
- integration tests for end-to-end application flow across boundaries

The separation mirrors the architecture and keeps feedback targeted.

## Strengths Of The Codebase

- clear separation between domain, application, infrastructure, and transport
- explicit use-case modelling instead of controller-heavy or service-heavy design
- business concepts represented as domain types rather than raw persistence records
- authorization boundaries aligned with product roles
- real integration points for storage, email, and push notifications
- scheduled automation for operational workflows
- test structure aligned with architectural layers

## Product Context

Live product:

- Website: [https://pawsplus.eu/](https://pawsplus.eu/)

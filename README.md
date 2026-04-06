# Emprevo Carpark Engine

A parking pricing system built for the Emprevo coding challenge. The solution uses a GraphQL API backend with an Angular frontend and an xUnit test suite.

## Architecture

| Component | Tech | Description |
|-----------|------|-------------|
| [Carpark Engine](./CarparkEngine) | ASP.NET 8.0, C#, HotChocolate GraphQL | Backend API that calculates parking ticket prices based on entry/exit times using Early Bird, Night, Weekend, and Standard rate logic |
| [Carpark Engine UI](./CarparkEngineUI) | Angular 18, TypeScript, Apollo GraphQL | Frontend form for submitting parking entry/exit times and viewing calculated prices |
| [Carpark Engine Tests](./CarparkEngine.Tests) | xUnit | Unit tests covering price calculation, query responses, mutation validation, and model behaviour |

## Pricing Rates

| Rate | Price | Condition |
|------|-------|-----------|
| Early Bird | $13.00 | Enter 6:00 AM -- 9:00 AM, exit 3:30 PM -- 11:30 PM (weekdays) |
| Night | $6.50 | Enter 6:00 PM -- midnight, exit before 6:00 AM next day (weekdays) |
| Weekend | $10.00 | Enter Friday midnight -- Sunday, exit before Sunday midnight |
| Standard | $5 -- $20 | Hourly: 0--1h $5, 1--2h $10, 2--3h $15, 3h+ $20/day |

## Getting Started

1. Clone the repository:
   ```
   git clone https://github.com/vinhngogia0906/VinhNgo-Emprevo-Coding-Challenge.git
   ```
2. Follow the setup instructions in the README files for the [backend](./CarparkEngine) and [frontend](./CarparkEngineUI).

## CI

A GitHub Actions workflow builds the .NET solution and runs xUnit tests on every push and pull request to `main`.

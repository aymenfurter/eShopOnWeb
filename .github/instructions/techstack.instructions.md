---
applyTo: '**'
---

# Project Context

This repository is based on **Microsoft eShopOnWeb** with .NET 8 and uses central package version management.  
The tech stack includes:
- ASP.NET Core 8
- Entity Framework Core 8
- MediatR, Ardalis libraries
- Azure resources (App Service, Key Vault, SQL, etc.)
- xUnit, MSTest, Coverlet for testing

# Coding Guidelines

- Use **.NET 8** features (nullable enabled, implicit usings, async/await best practices).  
- Follow **Microsoft .NET coding conventions**:  
  - Consistent naming (PascalCase for classes/methods, camelCase for locals, constants in ALL_CAPS).  
  - Prefer `var` when the type is obvious, explicit types when clarity is needed.  
  - Use `async`/`await` properly with `ConfigureAwait(false)` in library code.  
- Apply **SOLID principles** and separation of concerns.  
- Favor **dependency injection** over static helpers.  
- Ensure **guard clauses** (Ardalis.GuardClauses) for input validation.  
- Always add **unit tests** for new business logic. Prefer xUnit and FluentAssertions.  
- Log important actions using `Microsoft.Extensions.Logging` abstractions.  
- Commit messages should follow **Conventional Commits** style (`feat:`, `fix:`, `chore:`, etc.).  

# How Copilot Should Help

- When suggesting code, respect project structure (ApplicationCore, PublicApi, Web, Tests).  
- When reviewing, check **consistency with conventions, logging, exception handling, test coverage**.  
- When answering questions, provide context-aware answers aligned with this tech stack.  

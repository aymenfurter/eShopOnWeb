---
applyTo: '**/*.bicep'
---

# Infrastructure as Code Guidelines

This project uses **Bicep** for Azure deployments.

- Target scope is usually **subscription** or **resourceGroup**.  
- Follow **azd resource naming conventions** unless explicitly overridden with parameters.  
- Use `param` with `@description`, `@secure()` for secrets, and sensible defaults.  
- Always use **parameterization** (no hardcoded names).  
- Use `loadJsonContent` for abbreviations and consistent naming.  
- Ensure **tags** include `azd-env-name`.  
- Store all secrets in **Azure Key Vault** and reference them from applications.  
- Use `outputs` for connection strings, resource IDs, and endpoints.  
- Prefer **modules** for web apps, databases, key vaults, and plans instead of inline resources.  
- Keep SKUs minimal for dev/test (e.g., `B1` for App Service Plan).  
- Validate that resources reference each other correctly (e.g., web → Key Vault, databases → Key Vault).  

# How Copilot Should Help

- When generating Bicep code, enforce these conventions.  
- When reviewing, highlight hardcoded values, missing descriptions, missing secure annotations, or lack of tags.  
- When answering, prefer **azd-aligned** guidance over generic ARM templates.  

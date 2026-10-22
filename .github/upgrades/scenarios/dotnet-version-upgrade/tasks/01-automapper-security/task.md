# 01-automapper-security: Upgrade AutoMapper and validate the solution

Update the AutoMapper dependency in `HR.LeaveManagement.Application` from the vulnerable 12.0.1 dependency chain to the latest stable version supported by .NET 10. Remove or replace obsolete dependency-injection package references as required by the selected AutoMapper version, while preserving the existing service registration and mapping behavior.

Research the current AutoMapper package layout and the existing `AddAutoMapper` registration before editing. Validate restore/build output for the full solution and confirm that the NU1903 vulnerability warning no longer appears. Run available tests and document any unavailable test projects.

## Research findings

- The solution contains five SDK-style projects targeting `net10.0`; the affected direct package reference is in `HR.LeaveManagement.Application/HR.LeaveManagement.Application.csproj`.
- `get_project_dependencies` confirmed standard (non-CPM) package management and identified `AutoMapper.Extensions.Microsoft.DependencyInjection` 12.0.1 as the direct definition. Its transitive `AutoMapper` 12.0.1 dependency produces NU1903 in the persistence build.
- `get_supported_package_version` resolved stable `AutoMapper` version `16.2.0` for `net10.0`.
- `HR.LeaveManagement.Application/ApplicationServiceRegistration.cs` calls `services.AddAutoMapper(Assembly.GetExecutingAssembly())`; existing mapping profiles derive from `AutoMapper.Profile`. AutoMapper 16 provides the DI registration API in the core package, so the obsolete extension package should be replaced with the core `AutoMapper` reference.
- Validation must include the full solution build, warning inspection, and available test discovery/execution.

**Affected files**: `HR.LeaveManagement.Application/HR.LeaveManagement.Application.csproj`; application service registration is expected to remain unchanged unless compilation proves otherwise.

**Done when**: AutoMapper resolves to a non-vulnerable stable version; the full solution builds with zero errors and zero warnings; the NU1903 warning is absent; existing AutoMapper service registration compiles; available tests pass.

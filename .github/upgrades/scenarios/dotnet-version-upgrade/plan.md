# .NET Version Upgrade Plan

## Overview

**Target**: Remove the high-severity AutoMapper vulnerability reported during the .NET 10 solution build.
**Scope**: One application project with transitive impact on the solution's dependent projects.

## Tasks

### 01-automapper-security: Upgrade AutoMapper and validate the solution

Update the AutoMapper dependency in `HR.LeaveManagement.Application` from the vulnerable 12.0.1 dependency chain to the latest stable version supported by .NET 10. Remove or replace obsolete dependency-injection package references as required by the selected AutoMapper version, while preserving the existing service registration and mapping behavior.

Research the current AutoMapper package layout and the existing `AddAutoMapper` registration before editing. Validate restore/build output for the full solution and confirm that the NU1903 vulnerability warning no longer appears. Run available tests and document any unavailable test projects.

**Done when**: AutoMapper resolves to a non-vulnerable stable version; the full solution builds with zero errors and zero warnings; the NU1903 warning is absent; existing AutoMapper service registration compiles; available tests pass.

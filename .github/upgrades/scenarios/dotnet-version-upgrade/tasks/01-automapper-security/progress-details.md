# Progress Details

## Changes

- Replaced `AutoMapper.Extensions.Microsoft.DependencyInjection` 12.0.1 with `AutoMapper` 16.2.0 in `HR.LeaveManagement.Application/HR.LeaveManagement.Application.csproj`.
- Updated `ApplicationServiceRegistration.ConfigureApplicationServices` to use AutoMapper 16's configuration-delegate overload while scanning the application assembly.
- Added `System.Security.Cryptography.Pkcs` 10.0.13 direct references to the API and persistence projects to resolve the transitive vulnerable 9.0.11 package reported during restore.
- No EF Core migration files were changed; the repository's existing migration-folder instruction remains unrelated to this dependency remediation.

## Validation

- Application project build: passed.
- Full solution build: passed with zero errors and zero warnings.
- `dotnet list HRLeaveManagement.slnx package --vulnerable --include-transitive`: all five projects report no vulnerable packages, including removal of the original AutoMapper NU1903 warning.
- Test-project discovery returned no test projects, so no test run was available.

## Issues resolved

- AutoMapper 12.0.1 high-severity NU1903 vulnerability.
- AutoMapper 16 API compilation issue caused by removal of the assembly-only `AddAutoMapper` overload.
- Transitive `System.Security.Cryptography.Pkcs` 9.0.11 moderate/high vulnerability warnings.

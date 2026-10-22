# .NET Version Upgrade

## Preferences
- **Flow Mode**: Automatic
- **Target Framework**: net10.0
- **Scope**: Entire solution
- **Priority**: Fix current build errors first

## Source Control
- **Source Branch**: master
- **Working Branch**: upgrade-dotnet-10
- **Pending Changes**: Committed before starting the upgrade
- **Commit Strategy**: After Each Task
- **Branch Sync**: Auto (Merge)

## Strategy
- **Selected**: Focused dependency remediation
- **Rationale**: The solution already targets net10.0 and the current blocker is the NU1903 AutoMapper vulnerability.

### Execution Constraints
- Update the dependency before changing application code.
- Preserve the existing AutoMapper registration and mapping profiles.
- Build the full solution and treat all warnings as failures.
- Run available tests before completing the task.

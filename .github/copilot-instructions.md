# Copilot Instructions for ConwaysGameOfLife

## Project Overview
- This is a Blazor WebAssembly project for Conway's Game of Life, with a focus on BDD/TDD and AI-driven development.
- The main user interface is in `ConwaysGameOfLife.WebUI/` (see `App.razor`, `MainLayout.razor`, and `Pages/Index.razor`).
- Core board logic should be implemented in the `ConwaysGameOfLife.Lib/` project for reuse and testability.
- Tests and BDD scenarios are in `ConwaysGameOfLife.Test/`, using `.feature` files and step definitions.
- The [docs/objective.md](../docs/objective.md) file is the canonical specification, containing rules, scenarios, and shape definitions.

## Developer Workflow
- **Test-Driven Development:**
  - Add/modify scenarios in `ConwaysGameOfLife.Test/Features/*.feature`.
  - Implement step definitions in `ConwaysGameOfLife.Test/StepDefinitions/`.
  - Core logic should be implemented or updated in `ConwaysGameOfLife.Lib/`.
  - Run all tests with `dotnet test ConwaysGameOfLife.WebUI.slnx --nologo`.
  - For faster TDD loops, run only relevant scenarios with `dotnet test ConwaysGameOfLife.Test/ConwaysGameOfLife.Test.csproj --nologo --filter "<ScenarioOrFeatureName>"`.
- **UI Development:**
  - UI logic lives in `.razor` and `.razor.cs` files in `ConwaysGameOfLife.WebUI/Pages/`.
  - The UI should reflect the current board/view state and allow loading shapes and advancing generations.
- **Refactoring:**
  - Refactor freely, but ensure all BDD scenarios remain green.

## Key Files & Directories
- `docs/objective.md`: Project spec, rules, and scenarios
- `ConwaysGameOfLife.Lib/`: Core board logic and pure functions
- `ConwaysGameOfLife.WebUI/`: Blazor Web UI
- `ConwaysGameOfLife.Test/Features/`: BDD scenarios
- `ConwaysGameOfLife.Test/StepDefinitions/`: Test step definitions

# Back-end Best Practices

## Scope

- Keep game rules, board state, and generation updates in ConwaysGameOfLife.Lib.
- Keep WebUI focused on presentation and user interaction.
- Keep tests close to the behavior they verify.

## General Guidelines

- Prefer small, pure methods for board transitions and rendering helpers.
- Keep the game engine deterministic and side-effect free where possible.
- Use descriptive names that match the domain: board, cell, generation, pattern, and view.
- Avoid adding abstractions unless they make the algorithm, rendering, or tests simpler.

## Implementation Notes

- Put reusable logic in the library project, not in the page code-behind.
- Keep UI-specific formatting and layout out of the core algorithm.
- When adding a new rule or pattern, add a focused scenario in ConwaysGameOfLife.Test first.

# Conways Game Of Life

This repository exists to help developers learn to use AI more effectively.  The [objective](./docs/objective.md) document provides a solid working spec for having an AI build out [Conway's Game of Life](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life), with an emphasis on BDD and TDD.

## Try the following

1. Attempt to solve the following 3 problems simultaneously with AI Agents, ideally with TDD:
- Create the core algorithm
- Create a view
- Create a UI
2. Once all three are working independently, combine them together to get a UI that can step through states, pan, and zoom.  
3. While working through UI issues in the foreground, in a new background agent try implementing a pattern loader that will show I-heptomino, and Gosper's glider gun.

## Key Branches

- [implementation/dotnet-start-here](https://github.com/lprichar/ConwaysGameOfLife/tree/implementation/dotnet-start-here) - If you're on the .NET stack start with the branch.
- [implementation/dotnet-working](https://github.com/lprichar/ConwaysGameOfLife/tree/implementation/dotnet-working) - This branch shows a minimal working solution

## Contributions Welcome

If you're on a non-dotnet stack we would greatly welcome BDD starting points similar to `implementation/dotnet-start-here`.
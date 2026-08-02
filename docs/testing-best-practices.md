# Testing Best Practices

## Framework

- Use xUnit for automated tests.
- Use Reqnroll for behavior scenarios in .feature files.

## Test File Locations

- Put feature files in ConwaysGameOfLife.Test/Features.
- Put step definitions in ConwaysGameOfLife.Test/StepDefinitions.
- Keep supporting test helpers close to the scenarios that use them.

## Testing Best Practices

- Keep each test or scenario focused on one behavior.
- Prefer simple setup that makes the expected board state easy to see.
- Expose important values directly in the scenario name or assertions.
- Hide unimportant setup details in helpers when it makes the test easier to read.

## Naming Conventions

- Prefer Given...When...Then... scenario names.
- Make the name describe the board state, action, and expected result.

## Assertions

- Assert literal board states, counts, coordinates, or other visible outcomes.
- Keep expected values explicit so the test reads like a specification.
- When verifying a collection, assert on the exact items or resulting shape rather than duplicating the algorithm.

## Helpers

- Use small helper methods for repeated board setup.
- Keep helpers focused on construction, not behavior.
- Prefer named arguments when a helper needs multiple inputs.
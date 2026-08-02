# Testing Checklist

Use this checklist before committing or approving tests. Every item should be answered YES. If not, fix the test or document a justified exception.

## Placement and Scope

- [ ] The scenario or test lives in the correct feature, step definition, or test file for the behavior under test.
- [ ] The test verifies a single behavior or rule.

## Structure

- [ ] Scenario or test naming describes the behavior being checked.
- [ ] Arrange, act, and assert are easy to identify.

## Inputs and Outputs

- [ ] Inputs are explicit and deterministic.
- [ ] Expected board states, coordinates, or counts are asserted directly.

## Readability

- [ ] The test explains the scenario without needing to inspect helpers first.
- [ ] Helper methods, if used, keep setup small and focused.

## Determinism

- [ ] No hidden time, randomness, or external dependencies are required.
- [ ] Any randomness, timers, or external services are stubbed or avoided.

## Final Review

- [ ] The test is green locally.

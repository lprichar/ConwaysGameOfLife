Feature: Game of Life service contract

Phase 0 contract-level checks for API stability and baseline determinism

Scenario: Create and render an empty board
    Given a baseline game of life service
    When an empty board is created
    And the board is rendered at origin 0,0 with width 3 and height 2
    Then the rendered board has 2 rows and each row has 3 cells
    And all rendered cells are dead

Scenario: Loading a shape is deterministic
    Given a baseline game of life service
    When the shape "I-heptomino" is loaded twice
    Then both loaded boards have the same live-cell set

Scenario: Next generation is deterministic and structurally valid
    Given a baseline game of life service
    And the shape "I-heptomino" is loaded as the current board
    When next generation is computed twice from the current board
    Then both next-generation boards have the same live-cell set
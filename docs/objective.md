# Objective

This application allows users to play Conway's Game of Life in a web page.

## Rules

The universe of the Game of Life is an infinite, two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, live or dead (or populated and unpopulated, respectively). Every cell interacts with its eight neighbours, which are the cells that are horizontally, vertically, or diagonally adjacent. At each step in time, the following transitions occur:

- Any live cell with fewer than two live neighbours dies, as if by underpopulation.
- Any live cell with two or three live neighbours lives on to the next generation.
- Any live cell with more than three live neighbours dies, as if by overpopulation.
- Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

## Initial Pattern

The initial pattern constitutes the seed of the system. The first generation is created by applying the above rules simultaneously to every cell in the seed, live or dead; births and deaths occur simultaneously, and the discrete moment at which this happens is sometimes called a tick. 

## Ticks

Each generation is a pure function of the preceding generation. The rules continue to be applied repeatedly to create further generations.

## Core Algorithm

### Under-Population
Scenario: When cells have zero live neighbors then they die from under-population
    Given The board state
        | 0 | 1 | 2 |
        | . | . | . |
        | . | O | . |
        | . | . | . |
    When The algorithm runs
    Then The board state becomes
        | 0 | 1 | 2 |
        | . | . | . |
        | . | . | . |
        | . | . | . |

### Survival
Scenario: When a live cell has two live neighbors then it lives on to the next generation
    Given The board state
        | 0 | 1 | 2 |
        | O | . | . |
        | O | O | . |
        | . | . | . |
    When The algorithm runs
    Then The board state becomes
        | 0 | 1 | 2 |
        | O | . | . |
        | O | O | . |
        | . | . | . |

Scenario: When a live cell has three live neighbors then it lives on to the next generation
    Given The board state
        | 0 | 1 | 2 |
        | O | O | . |
        | O | O | . |
        | . | . | . |
    When The algorithm runs
    Then The board state becomes
        | 0 | 1 | 2 |
        | O | O | . |
        | O | O | . |
        | . | . | . |

### Over-Population
Scenario: When a live cell has more than three live neighbors then it dies from over-population
    Given The board state
        | 0 | 1 | 2 |
        | O | O | O |
        | O | O | . |
        | . | . | . |
    When The algorithm runs
    Then The board state becomes
        | 0 | 1 | 2 |
        | O | . | O |
        | O | . | O |
        | . | . | . |

### Reproduction
Scenario: When a dead cell has exactly three live neighbors then it becomes a live cell
    Given The board state
        | 0 | 1 | 2 |
        | O | O | . |
        | O | . | . |
        | . | . | . |
    When The algorithm runs
    Then The board state becomes
        | 0 | 1 | 2 |
        | O | O | . |
        | O | O | . |
        | . | . | . |

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

## Other scenarios

Scenario: A three-cell blinker oscillates
    Given The board state
        | 0 | 1 | 2 |
        | . | O | . |
        | . | O | . |
        | . | O | . |
    When The algorithm runs
    Then The board state becomes
        | 0 | 1 | 2 |
        | . | . | . |
        | O | O | O |
        | . | . | . |
    When The algorithm runs  
    Then The board state becomes  
        | 0 | 1 | 2 |  
        | . | O | . |  
        | . | O | . |  
        | . | O | . |  

## Views

- A board is a set of xy tuples representing live cells in an infinite grid.  
- Any coordinate not present in the tuple set is dead.
- A view defines a rectangular window into the board, specified by origin, width, and height.
- The origin is the top-left of the view. x increases to the right and y increases downward.

Scenario: Two tuples will render in a view with x increasing to the right and y increasing downward
    Given An initial board state of tuples like
        | x | y |
        | 0 | 0 |
        | 1 | 1 |
    Given the initial view is (0,0), width = 2, height = 2
    When The board is rendered
    Then the rendered view becomes
        | 0 | 1 |
        | O | . |
        | . | O |

Scenario: Zooming out reveals more of the world
    Given An initial board state of tuples like
        | x | y |
        | 0 | 0 |
        | 1 | 1 |
    Given the initial view is (0,0), width = 3, height = 2
    When The view is set to (0,0), width = 5, height = 4
    Then the rendered view becomes
        | 0 | 1 | 2 | 3 | 4 |
        | O | . | . | . | . |
        | . | O | . | . | . |
        | . | . | . | . | . |
        | . | . | . | . | . |

Scenario: Pan right will move nodes out of view
    Given An initial board state of tuples like
        | x | y |
        | 0 | 0 |
        | 1 | 1 |
    When The view is set to (-1,0), width = 3, height = 2
    Then the rendered view becomes
        | -1 | 0 | 1 |
        | . | O | . |
        | . | . | O |

## Pre-loaded shapes

User can load the following shapes.

### I-heptomino

Scenario: User loads the "I-heptomino" pattern
    When The user loads the "I-heptomino" pattern
    Then The board state becomes
        | x | y |
        | 0 | 0 |
        | 1 | 0 |
        | 1 | 1 |
        | 1 | 2 |
        | 2 | 2 |
        | 2 | 3 |
        | 3 | 3 |
    Given the view is (0,0), width = 4, height = 4
    Then the rendered view becomes
        | 0 | 1 | 2 | 3 |
        | O | O | . | . |
        | . | O | . | . |
        | . | O | O | . |
        | . | . | O | O |

### Gosper's glider gun

Scenario: User loads the "Gosper's glider gun" pattern
    When The user loads the "Gosper's glider gun" pattern
    Then The board state becomes
        | x  | y |
        | 24 | 0 |
        | 22 | 1 |
        | 24 | 1 |
        | 12 | 2 |
        | 13 | 2 |
        | 20 | 2 |
        | 21 | 2 |
        | 34 | 2 |
        | 35 | 2 |
        | 11 | 3 |
        | 15 | 3 |
        | 20 | 3 |
        | 21 | 3 |
        | 34 | 3 |
        | 35 | 3 |
        | 0  | 4 |
        | 1  | 4 |
        | 10 | 4 |
        | 16 | 4 |
        | 20 | 4 |
        | 21 | 4 |
        | 0  | 5 |
        | 1  | 5 |
        | 10 | 5 |
        | 14 | 5 |
        | 16 | 5 |
        | 17 | 5 |
        | 22 | 5 |
        | 24 | 5 |
        | 10 | 6 |
        | 16 | 6 |
        | 24 | 6 |
        | 11 | 7 |
        | 15 | 7 |
        | 12 | 8 |
        | 13 | 8 |
    Given the view is (0,0), width = 36, height = 9
    Then the rendered view becomes
        | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15 | 16 | 17 | 18 | 19 | 20 | 21 | 22 | 23 | 24 | 25 | 26 | 27 | 28 | 29 | 30 | 31 | 32 | 33 | 34 | 35 |
        | . | . | . | . | . | . | . | . | . | . | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | O  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  |
        | . | . | . | . | . | . | . | . | . | . | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | O  | .  | O  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  |
        | . | . | . | . | . | . | . | . | . | . | .  | .  | O  | O  | .  | .  | .  | .  | .  | .  | O  | O  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | O  | O  |
        | . | . | . | . | . | . | . | . | . | . | .  | O  | .  | .  | .  | O  | .  | .  | .  | .  | O  | O  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | O  | O  |
        | O | O | . | . | . | . | . | . | . | . | O  | .  | .  | .  | .  | .  | O  | .  | .  | .  | O  | O  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  |
        | O | O | . | . | . | . | . | . | . | . | O  | .  | .  | .  | O  | .  | O  | O  | .  | .  | .  | .  | O  | .  | O  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  |
        | . | . | . | . | . | . | . | . | . | . | O  | .  | .  | .  | .  | .  | O  | .  | .  | .  | .  | .  | .  | .  | O  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  |
        | . | . | . | . | . | . | . | . | . | . | .  | O  | .  | .  | .  | O  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  |
        | . | . | . | . | . | . | . | . | . | . | .  | .  | O  | O  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  | .  |

Feature: Core Algorithm

Core rules for Conway's Game of Life transitions.

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

Scenario: When a live cell has two live neighbors then it lives on to the next generation
    Given The board state
        | 0 | 1 | 2 |
        | O | . | . |
        | O | O | . |
        | . | . | . |
    When The algorithm runs
    Then The board state becomes
        | 0 | 1 | 2 |
        | O | O | . |
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

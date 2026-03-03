Feature: View

Rendering a tuple-based board through a rectangular view window

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
        | .  | O | . |
        | .  | . | O |

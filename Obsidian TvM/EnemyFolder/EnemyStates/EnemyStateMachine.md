[[Enemy]]

- **Purpose**: Manages the current enemy state and state transitions.
- **Components/Classes**:
    - `currentEnemyState`: Reference to the current enemy state.
- **Methods/Functions**:
    - `Initialize(EnemyState startingState)`: Initializes the state machine with a starting state.
    - `ChangeState(EnemyState newState)`: Changes the current state to a new state.
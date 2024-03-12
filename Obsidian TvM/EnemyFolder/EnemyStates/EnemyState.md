[[EnemyStateMachine]]

- **Purpose**: Base class for enemy states, handling state transitions and behavior.
- **Components/Classes**:
    - `enemy`: Reference to the enemy object.
    - `enemyStateMachine`: Reference to the state machine controlling enemy states.
- **Methods/Functions**:
    - `EnterState()`: Called when entering a new state.
    - `ExitState()`: Called when exiting the current state.
    - `FrameUpdate()`: Called every frame for state-specific updates.
    - `AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)`: Handles animation trigger events.
    - `OnCollisionEnter(Collision other)`: Handles collision events.
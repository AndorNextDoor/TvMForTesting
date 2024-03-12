[[TowerStateMachine]]

- **Purpose**: Represents a state of the tower, managing its behavior and transitions.
- **Components/Fields**:
    - `tower`: Reference to the tower script.
    - `towerStateMachine`: Reference to the tower's state machine.
- **Methods/Functions**:
    - `EnterState()`: Executes when entering the state.
    - `ExitState()`: Executes when exiting the state.
    - `FrameUpdate()`: Executes per frame.
    - `AnimationTriggerEvent(Tower.AnimationTowerTriggerType triggerType)`: Handles animation trigger events.
    - `OnCollisionEnter(Collision other)`: Handles collision events.
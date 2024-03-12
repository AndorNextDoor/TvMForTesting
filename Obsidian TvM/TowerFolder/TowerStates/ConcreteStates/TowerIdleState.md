[[TowerState]]
- **Purpose**: Represents the tower's idle state, managing idle behavior.
- **Components/Fields**: Inherits from `TowerState`.
- **Methods/Functions**:
    - `AnimationTriggerEvent(Tower.AnimationTowerTriggerType triggerType)`: Handles animation trigger events.
    - `EnterState()`, `ExitState()`, `FrameUpdate()`: Overrides base methods to execute idle-specific logic.
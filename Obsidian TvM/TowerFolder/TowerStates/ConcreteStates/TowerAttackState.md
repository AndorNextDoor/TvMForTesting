[[TowerState]]
- **Purpose**: Represents the tower's attack state, managing attack behavior.
- **Components/Fields**: Inherits from `TowerState`.
- **Methods/Functions**:
    - `AnimationTriggerEvent(Tower.AnimationTowerTriggerType triggerType)`: Handles animation trigger events.
    - `EnterState()`, `ExitState()`, `FrameUpdate()`: Overrides base methods to execute attack-specific logic.
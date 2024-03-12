[[TowerIdleState]]
- **Purpose**: Base class for tower idle behavior Scriptable Objects.
- **Components/Fields**:
    - `tower`: Reference to the tower script.
- **Methods/Functions**:
    - `Initialize(GameObject _gameObject, Tower _tower)`: Initializes the Scriptable Object with the tower reference.
    - `DoEnterLogic()`, `DoExitLogic()`, `DoFrameUpdateLogic()`: Methods to define idle behavior.
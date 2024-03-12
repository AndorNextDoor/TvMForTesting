[[TowerIdleSOBase]]

The `SpeedUpTower` class represents an idle tower that accelerates the round timer.

#### Properties:

- `timeSpeedMultiplier`: Multiplier for speeding up the round timer.

#### Methods:

- `DoAnimationTriggerEventLogic(Tower.AnimationTowerTriggerType triggerType)`: Handles animation trigger events.
- `DoEnterLogic()`: Executes logic when entering the idle state.
- `Initialize(GameObject _gameObject, Tower _tower)`: Initializes the tower instance.
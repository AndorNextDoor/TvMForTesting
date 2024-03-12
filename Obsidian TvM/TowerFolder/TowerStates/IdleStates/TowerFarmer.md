[[TowerIdleSOBase]]
The `TowerFarmer` class represents an idle tower with the ability to generate currency over time.

#### Properties:

- `currencyAmount`: Amount of currency generated each time.
- `timeToGetCurrency`: Time interval for generating currency.
- `_timer`: Timer for currency generation.

#### Methods:

- `DoAnimationTriggerEventLogic(Tower.AnimationTowerTriggerType triggerType)`: Handles animation trigger events.
- `DoEnterLogic()`: Executes logic when entering the idle state.
- `DoExitLogic()`: Executes logic when exiting the idle state.
- `DoFrameUpdateLogic()`: Executes frame update logic.
- `Initialize(GameObject _gameObject, Tower _tower)`: Initializes the tower instance.
- `GetCurrency()`: Generates currency and adds it to the player's current amount.
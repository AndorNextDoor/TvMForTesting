[[Tower]]
The `TowerTrigger` class detects enemy presence within the tower's range and triggers tower actions accordingly.

#### Properties:

- `timeToSpotEnemy`: Time interval for detecting enemies.
- `_timer`: Timer for enemy detection.

#### Methods:

- `Start()`: Initializes the enemy detection timer.
- `OnTriggerEnter(Collider collision)`: Handles actions when an enemy enters the tower's range.
- `OnTriggerStay(Collider collision)`: Continuously detects enemy presence within the tower's range.
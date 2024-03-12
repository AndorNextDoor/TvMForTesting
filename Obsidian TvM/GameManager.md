[[WaveSpawner]][[Enemy]][[Tower]]

-The `GameManager` class manages various game-related functionalities and interactions.

#### Properties:

- - **Instance**: Static instance of the GameManager, ensuring only one instance exists throughout the game.
- **uiManager**: Reference to the UiManager responsible for updating UI elements.
- **startingCurrency**: Initial amount of currency the player possesses at the beginning of the game.
- **currentCurrency**: Current amount of currency the player has.
- **gameOverScreen**: GameObject representing the screen displayed when the game ends.
- **levelCompleteScreen**: GameObject representing the screen displayed when the level is completed.
- **lives**: Number of lives the player has.
- **enemiesAmount**: Number of remaining enemies in the level.

**Methods**:

- **Awake()**: Initializes the GameManager instance.
- **Start()**: Initializes the GameManager's properties, such as the current currency and UI elements.
- **SetEnemiesAmount(int amount)**: Sets the total number of enemies in the level.
- **TakeDamage(int damage)**: Reduces player lives by the specified damage amount and updates the UI.
- **OnEnemyDestroyed()**: Decrements the enemy count when an enemy is destroyed.
- **DecreaseEnemies()**: Helper method to decrease the enemy count.
- **OnLevelCompletion()**: Activates the level completion screen and adjusts time scale.
- **OnGameOver()**: Activates the game over screen and adjusts time scale.
- **RestartScene()**: Reloads the current scene.
- **LoadNextLevel()**: Loads the next scene in the build order.
- **QuitToMenu()**: Returns to the main menu scene.
- **GetCurrency(int amount)**: Increases the player's currency by the specified amount and updates the UI.
- **SpendCurrency(int amount)**: Decreases the player's currency by the specified amount and updates the UI.
- **HaveEnoughCurrency(int cost)**: Checks if the player has enough currency to make a purchase and triggers a UI animation if not.
- **PauseGame()**: Pauses the game by setting the time scale to 0.
- **ResumeGame()**: Resumes the game by setting the time scale to 1.
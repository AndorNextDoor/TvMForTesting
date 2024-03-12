The `UiManager` class is responsible for managing the user interface elements in the game.

#### Properties:

- `instance`: Static reference to the singleton instance of the `UiManager`.
- `livesText`: TextMeshProUGUI element for displaying the current player lives.
- `waveTimerText`: TextMeshProUGUI element for displaying the countdown timer for waves.
- `currencyText`: TextMeshProUGUI element for displaying the current player currency.
- `currencyTextAnimator`: Animator component for animating currency text.
- `roundTimerSlider`: Slider element for visualizing the countdown timer for rounds.
- `timeSpeed`: Speed multiplier for the UI timer.
- `needToUpdateSlider`: Boolean flag indicating whether the round timer slider needs to be updated.

#### Methods:

- `Awake()`: Initializes the singleton instance.
- `Update()`: Updates the round timer slider based on the `timeSpeed`.
- `SetLivesText(int amount)`: Sets the text of the lives display.
- `SetWaveTimer(int time)`: Sets the text of the wave timer display.
- `SetCurrencyText(int currency)`: Sets the text of the currency display.
- `NotEnoughCurrencyAnimation()`: Triggers the animation for indicating insufficient currency.
- `SetRoundSliderInitialValue(float maxValue)`: Initializes and updates the round timer slider.
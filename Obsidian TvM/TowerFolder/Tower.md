[[IDamagable]]

### Tower

- **Purpose**: Represents a tower in the game, handling health, attack, and state transitions.
- **Components/Fields**:
    - `maxHealth`, `currentHealth`: Health properties of the tower.
    - `firepoint`: Transform where projectiles are spawned.
    - `attackTrigger`: Flag to trigger attack state.
    - `currentEnemy`: Reference to the current enemy target.
    - `animator`: Animator component for controlling animations.
    - '`attackSound`: The enum of the AudioSounds to play when the tower attacks
- **Methods/Functions**:
    - `Awake()`, `Start()`, `Update()`: Lifecycle methods for initialization and updating tower state.
    - `AnimationTriggerEvent(AnimationTowerTriggerType triggerType)`: Handles animation trigger events.
    - `Damage(float damageAmount)`, `Die()`: Methods to handle tower damage and destruction.
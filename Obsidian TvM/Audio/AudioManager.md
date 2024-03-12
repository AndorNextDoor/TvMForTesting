[[Sound]][[Enemy]][[Tower]][[AudioSounds]]
### Description:

The AudioManager class is responsible for managing audio playback in the game. It allows for the easy playing of sound effects through the use of an enum-based system.

#### Fields:

- **objectToAddSounds**: The GameObject to which AudioSource components will be added for playing audio clips.
- **sounds**: An array of Sound objects representing the different audio clips and their associated settings.
- **Instance**: Static instance of the AudioManager, ensuring only one instance exists throughout the game.
- **AudioSounds enum**: An enumeration of available sound options, providing compile-time safety and easy selection of sound names in the Unity editor.

#### Methods:

- **Awake()**: Initializes the AudioManager instance and ensures it persists between scenes. Adds AudioSource components to the specified GameObject for each sound in the sounds array.
- **PlaySound(AudioSounds name)**: Plays the audio clip associated with the specified AudioSounds enum value.
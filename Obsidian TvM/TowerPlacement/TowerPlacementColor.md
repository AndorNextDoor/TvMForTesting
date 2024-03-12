[[Tower]][[TowerPlacementController]]

- **Purpose**: Manages changing the material/color of the tower placement indicator based on whether the placement is valid or not.
- **Components/Fields**:
    - `materialsToChange`: Array of game objects whose material will be changed.
    - `Materials`: Array of materials to apply to the `materialsToChange`.
- **Methods/Functions**:
    - `SetMaterial(int materialID)`: Sets the material of each object in `materialsToChange` to the material at index `materialID` in `Materials`.
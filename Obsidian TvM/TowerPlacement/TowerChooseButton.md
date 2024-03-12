[[TowerPlacementController]]

- **Purpose**: Handles selecting a tower from the UI and informing the `TowerPlacementController` about the selected tower.
- **Components/Fields**:
    - `placementController`: Reference to the `TowerPlacementController`.
    - `towerIndex`: Index of the tower to be selected.
- **Methods/Functions**:
    - `OnPointerDown(PointerEventData data)`: Implemented from `IPointerDownHandler`. Called when a pointer is pressed down on the UI element.
        - Calls `SetTowerIndex()` on the `placementController` with the `towerIndex` as an argument.
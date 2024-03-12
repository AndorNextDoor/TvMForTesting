[[Enemy]]

- **Purpose**: Detects collisions with towers to trigger attack behavior and adjusts enemy position if too close to a tower.
- **Components/Fields**:
    - `enemy`: Reference to the enemy script.
    - `teleportDistance`: Distance to teleport the enemy away from a tower.
    - `teleportMinDistance`: Minimum distance to maintain from the tower.
- **Methods/Functions**:
    - `OnCollisionEnter(Collision collision)`: Handles collision with towers to initiate attack or adjust position.
    - `OnCollisionExit(Collision collision)`: Resets attack state when leaving the tower's collision area.
    - `CheckDistance(Collision collision)`: Adjusts enemy position to maintain a minimum distance from the tower.

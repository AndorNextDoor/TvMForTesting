using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] private float teleportMinDistance = 3.5f;


    private void OnCollisionEnter(Collision collision)
    {
        if (enemy.currentTowerToAttack != null) return;

        if (collision.transform.CompareTag("Tower"))
        {
            enemy.isInAttackRange = true;
            enemy.currentTowerToAttack = collision.transform.GetComponent<Tower>();
        }

    }

    private void DebugDistance(Collision collision)
    {
        Vector3 towerPos = new Vector3(0, 0, collision.transform.position.z);
        Vector3 transformPos = new Vector3(0, 0, transform.parent.position.z);
        float distanceToTower = Vector3.Distance(towerPos, transformPos);
        Debug.Log(distanceToTower);
    }

    private void CheckDistance(Collision collision)
    {
        // Desired distance on the z-axis
        

        // Get the tower's position and the current position of the enemy
        Vector3 towerPosition = collision.transform.position;
        Vector3 currentPosition = transform.parent.position;

        // Calculate the direction from the tower to the enemy
        Vector3 directionToEnemy = currentPosition - towerPosition;

        // Calculate the distance between the tower and the enemy on the z-axis
        float currentDistance = Mathf.Abs(directionToEnemy.z);

        // If the current distance is greater than the desired distance, move the enemy closer to the tower
        if (currentDistance < teleportMinDistance)
        {
            // Calculate the new z position with a negative offset to move closer to the tower
            float newZ = towerPosition.z - teleportMinDistance;

            // Create a new position vector with the same x and y coordinates as the tower, but with the new z coordinate
            Vector3 newPosition = new Vector3(transform.parent.position.x, transform.parent.position.y, newZ);

            // Update the enemy's position
            transform.parent.position = newPosition;
        }
    }
}

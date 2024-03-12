using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger : MonoBehaviour
{
    [SerializeField] private Tower tower;

    private void OnTriggerEnter(Collider other)
    {
        tower.attackTrigger = true;
        tower.currentEnemy = other.GetComponent<Enemy>();
    }
}

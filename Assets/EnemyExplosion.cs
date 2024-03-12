using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, explosion.transform.rotation);
    }
}

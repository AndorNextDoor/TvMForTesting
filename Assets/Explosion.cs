using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float timeToExplode;
    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        timeToExplode -= Time.deltaTime;
        if (timeToExplode <= 0)
        {
            GetComponent<Collider>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Tower"))
        {
            collision.transform.GetComponent<Tower>().Damage(damage);
        }
    }
}

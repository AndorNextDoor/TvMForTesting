using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 25;
    public float speed = 10f;
    [SerializeField] private string enemyTag;
    [SerializeField] private string laneEndTag;
    [SerializeField] private float lifeTimer = 5f;

    private void Update()
    {
        MoveStraight();
    }

    private void MoveStraight()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(enemyTag))
        {
            collision.transform.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag(laneEndTag))
        {
            Destroy(gameObject);
        }
    }
}
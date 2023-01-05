using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    void Update()
    {
        if (rb.position.x < -10 || rb.position.x > 10 || rb.position.y > 6 || rb.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyScript>().Damage();
            Destroy(gameObject);
        }
    }
}

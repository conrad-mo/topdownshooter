using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float followspeed = 3f;
    public GameObject player;
    public GameObject enemy;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 playerPos;
    // Update is called once per frame
    void Start()
    {
       // Instantiate(enemy, new Vector3(2, 2), transform.rotation);
    }
    void Update()
    {
        playerPos = player.transform.position;
    }
    void FixedUpdate()
    {
        rb.velocity = transform.up * followspeed;
        Vector2 lookDir = playerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

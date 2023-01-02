using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float followspeed = 0.1f;
    public GameObject player;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 playerPos;
    // Update is called once per frame
    void Start()
    {
        
    }
    void Update()
    {
        playerPos = player.transform.position;
    }
    void FixedUpdate()
    {
        rb.velocity = Vector2.up * followspeed;
        Vector2 lookDir = playerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}

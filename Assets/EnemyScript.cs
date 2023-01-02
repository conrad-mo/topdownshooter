using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float followspeed = 10f;
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
        Vector2 lookDir = playerPos - rb.position;
        rb.velocity = movement * followspeed;
    }
}

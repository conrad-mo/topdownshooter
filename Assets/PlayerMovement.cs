using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 100f;
    public Rigidbody2D rb;
    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        movement.x = 0;
        movement.y = 0;
        if (Input.GetKeyDown(KeyCode.A))
        {
            movement.x = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement.x = 1;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            movement.y = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movement.y = -1;
        }
    }
    void FixedUpdate()
    {
        rb.velocity =  movement * moveSpeed;
        //movement.x = 0 * Time.fixedDeltaTime;
        //movement.y = 0 * Time.fixedDeltaTime;
    }
}

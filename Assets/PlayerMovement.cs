using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 100f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    // Update is called once per frame
    void Update()
    {
        movement.x = 0;
        movement.y = 0;
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1;
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        rb.velocity =  movement * moveSpeed;
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }
}

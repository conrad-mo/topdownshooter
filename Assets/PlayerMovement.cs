using System;
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
    public LogicScript logic;
    public bool life = true;
    // Update is called once per frame
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Update()
    {
        movement.x = 0;
        movement.y = 0;
        if (life)
        {
            if (Input.GetKey(KeyCode.A) && rb.position.x > -9)
            {
                movement.x = -1;
            }
            if (Input.GetKey(KeyCode.D) && rb.position.x < 9)
            {
                movement.x = 1;
            }
            if (Input.GetKey(KeyCode.W) && rb.position.y < 5)
            {
                movement.y = 1;
            }
            if (Input.GetKey(KeyCode.S) && rb.position.y > -5)
            {
                movement.y = -1;
            }
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            logic.gameOver();
            life = false;
        }
    }
}

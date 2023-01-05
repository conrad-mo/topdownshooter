using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 100f;
    public Rigidbody2D rb;
    public Camera cam;
    private Vector2 _movement;
    private Vector2 _mousePos;

    private LogicScript Logic => LogicScript.instance;
    // Update is called once per frame
    void Update()
    {
        _movement.x = 0;
        _movement.y = 0;
        if (!LogicScript.instance.GameIsOver)
        {
            if (Input.GetKey(KeyCode.A))
            {
                _movement.x = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _movement.x = 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                _movement.y = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _movement.y = -1;
            }
        }
        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.velocity = _movement * moveSpeed;
        Vector2 lookDir = _mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Logic.GameOver();
        }
    }
}

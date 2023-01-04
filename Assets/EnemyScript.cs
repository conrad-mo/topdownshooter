using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float followspeed = 3f;
    public GameObject player;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 playerPos;
    public PlayerMovement playerscript;
    // Update is called once per frame
    void Start()
    {
        playerscript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        playerPos = player.transform.position;
    }
    void FixedUpdate()
    {
        if (playerscript.life)
        {
            rb.velocity = transform.up * followspeed;
            Vector2 lookDir = playerPos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

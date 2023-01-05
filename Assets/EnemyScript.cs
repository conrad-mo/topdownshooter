using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private const float FollowSpeed = 3f;
    public GameObject player;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;
    private Vector2 PlayerPos => player.transform.position;

    private LogicScript _logic;

    // Update is called once per frame
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        _logic = FindObjectOfType<LogicScript>();
    }
    void FixedUpdate()
    {
        if (!_logic.GameIsOver)
        {
            _rigidbody2D.velocity = transform.up * FollowSpeed;
            Vector2 lookDir = PlayerPos - _rigidbody2D.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            _rigidbody2D.rotation = angle;
        }
    }
    public void Damage()
    {
        _logic.AddScore();
        Destroy(gameObject);
    }
}

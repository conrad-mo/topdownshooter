using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public float spawnRate = 1;
    private float timer = 0;
    //private float playerdistance = 1;
    private Vector3 spawnCord;
    Vector3 playerPos;
    public PlayerMovement playerscript;
    // Start is called before the first frame update
    void Start()
    {
        playerscript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else if (playerscript.life)
        {
            spawnEnemy();
            timer = 0;
        }
    }
    void spawnEnemy()
    {
        spawnCord = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4));
        Debug.Log(playerPos);
        while (Vector3.Distance(spawnCord, playerPos) < 3)
        {
            Debug.Log("Need new cords");
            Debug.Log(Vector3.Distance(spawnCord, playerPos));
            Debug.Log("Sent new cords already");
            spawnCord = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4));
        }
        Debug.Log("This one ok");
        Debug.Log(Vector3.Distance(spawnCord, playerPos));
        Instantiate(enemy, spawnCord, transform.rotation);
    }
}

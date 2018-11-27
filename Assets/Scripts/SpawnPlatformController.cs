using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatformController : MonoBehaviour {

    public float respawnTimeMax = 1.0f;
    private float respawnTime;
    public GameObject enemyPrefab;
    public Transform spawnPosition;
    public GameObject player;
    public GameObject enemy;

	// Use this for initialization
	void Start ()
    {
        enemy = Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        Health health = player.GetComponent<Health>();
        if (health && health.GetHealth() <= 0)
            return;
        if (!enemy.gameObject)
        {
            if (respawnTime > 0)
                respawnTime -= Time.deltaTime;
            else
            {
                respawnTime = respawnTimeMax;
                // respawn mob
                enemy = Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
            }
        }
    }
}

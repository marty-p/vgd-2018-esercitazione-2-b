using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatformController : MonoBehaviour {

    public float respawnTimeMax = 3.0f;
    private float respawnTime;
    public GameObject enemyPrefab;
    public Transform spawnPosition;
    public GameObject player;

	// Use this for initialization
	void Start () {
        respawnTime = respawnTimeMax;
    }
	
	// Update is called once per frame
	void Update () {
        Health health = player.GetComponent<Health>();
        if (health && health.GetHealth() <= 0)
            return;
        if (respawnTime > 0)
            respawnTime -= Time.deltaTime;
        else
        {
            respawnTime = respawnTimeMax;
            // respawn mob
            Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
        }

    }
}

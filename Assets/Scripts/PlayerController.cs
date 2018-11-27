using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float cooldownTime = 0.5f;
    private float nextFire;
    // movement
    public float speedMove = 1.0f;

    void Start () {
		
	}
	
	void Update ()
    {
        // movement
        Health health = this.GetComponent<Health>();
        if (health && health.GetHealth() <= 0)
            return;
        float movementH = Input.GetAxis("Horizontal");
        float movementV = Input.GetAxis("Vertical");
        transform.position = new Vector3(transform.position.x + movementH, transform.position.y, transform.position.z + movementV) * speedMove;

        // bullet spawn
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + cooldownTime;
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // bullet
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float cooldownTimeMax = 1f;
    public float cooldownTime;

    // rotation
    public float rotationSpeed = 2.0f;
    public int rotationFactor = 3;

    private CharacterController cc;

	void Start () {
        cc = GetComponent<CharacterController>();
        cooldownTime = cooldownTimeMax;
    }
	
	void Update () {
        // rotation
        float randomFactorY = Random.Range(-rotationFactor, rotationFactor + 1) * rotationSpeed;
        cc.transform.Rotate(0, randomFactorY, 0);

        if (cooldownTime <= 0)
        {
            cooldownTime = cooldownTimeMax;
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
        else
            cooldownTime -= Time.deltaTime;
    }
}

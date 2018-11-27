using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // movement
    public float moveSpeed = 5.0f;
    public int moveFactor = 3;
    // raycast
    public float rcLength = 10f;
    public float rcTimeMax = 2.0f;
    private float rcTime;

	void Start () {
        rcTime = rcTimeMax;
    }
	
	void Update () {
        // movement
        float randomFactorX = transform.position.x + Random.Range(-moveFactor, moveFactor + 1) * moveSpeed * Time.deltaTime;
        float randomFactorZ = transform.position.z + Random.Range(-moveFactor, moveFactor + 1) * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(randomFactorX, transform.position.y, randomFactorZ);

        // raycast
        if (rcTime > 0)
            rcTime -= Time.deltaTime;
        else
        {
            rcTime = rcTimeMax;
            // shoot rc
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * rcLength, Color.red);
            if (Physics.Raycast(transform.position, transform.forward, out hit, rcLength))
            {
                Health health = hit.collider.gameObject.GetComponent<Health>();
                if (health != null)
                    health.LoseHealth(1f);
            }
            // Debug.Log("shoot!");
        }
	}
}

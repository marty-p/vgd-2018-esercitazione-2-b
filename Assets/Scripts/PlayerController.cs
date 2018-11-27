using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // raycast
    public float cooldownTime = 1f;
    private float nextFire;
    public float rcLength = 10f;
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
            // shoot rc
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * rcLength, Color.red);
            if (Physics.Raycast(transform.position, transform.forward, out hit, rcLength))
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                    Destroy(hit.collider.gameObject);
            }
        }
    }
}

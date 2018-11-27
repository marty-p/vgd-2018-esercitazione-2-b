using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private Rigidbody rb;
    public float bulletForce = 5;
    public float lifeTime = 5;
    public float fireTime;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        Vector3 bulletDirection = transform.forward;

        fireTime = Time.time;

        rb.AddForce(bulletDirection * bulletForce, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lifeTime + fireTime)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player2"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
                health.LoseHealth(1f);
        }
        Destroy(this.gameObject);
    }
}

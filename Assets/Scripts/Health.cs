using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 3f;
    public float GetHealth() { return health; }
	public void LoseHealth(float value) {
        health -= value;
        Debug.Log("health is now " + health);
	}
}

using UnityEngine;
using System.Collections;

public class BaseController : MonoBehaviour {
    private int baseHealth;

	// Use this for initialization
	void Start () {
        baseHealth = 5;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    int takeDamage(int damageTaken) {
        int newHealth = this.baseHealth - damageTaken;
        return newHealth;
    }
}

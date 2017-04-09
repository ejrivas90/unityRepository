using UnityEngine;
using System.Collections;

public class BaseController : AbstractSoldier
{
    public int baseHealth;

	// Use this for initialization
	void Start () {
        baseHealth = 5;
        setCurrentHealth(5);
        setCurrentState(TurnState.BASE);
	}
	
	// Update is called once per frame
	void Update () {
        if(getCurrentHealth() < 1)
        {
            Destroy(this.gameObject);
        }
	}

    public override void takeDamage() {
        setCurrentHealth(getCurrentHealth() - 1);
    }
    
}

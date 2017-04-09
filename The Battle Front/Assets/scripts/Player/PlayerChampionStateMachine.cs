using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerChampionStateMachine : AbstractSoldier
{
    private bool hasDiceBeenRolled;
    private GameObject champTileLocation;

    void Start()
    {
        Debug.Log("Player Champ State Machine Initiated");
        setAtkRange(2);
    }

    public override void init()
    {
        setName("playerChampion");
        setSoldierType("Champion");
        champTileLocation = (GameObject)GameObject.Find("square: 7,14");
        setSoldierVector(GameObject.Find("square: 7,14").transform.position);
        Vector3 champVector = getSoldierVector();
        transform.position = new Vector3(champVector.x, 0.5f, champVector.z);
        setCurrentHealth(100);
        setAttackPower(50);
        setAtkDie(6);
        setCurrentStamina(4);
        Debug.Log("champ is at " + champTileLocation);
    }

    void Update()
    {
        //Debug.Log("champ vector: " + this.transform.position.x + ", " + this.transform.position.y + ", " + this.transform.position.z);
        setSoldierVector(this.transform.position);
        if (getCurrentHealth() < 1)
        {
            Destroy(this.gameObject);
        }
    }

    public void beginTurn(GameObject playerObject)
    {
        Debug.Log("Players turn has just begun");
        Debug.Log("Champ is at " + champTileLocation);
        setCurrentState(TurnState.ACTIVE);
        hasDiceBeenRolled = false;
        setCurrentStamina(0);
    }

    public void endTurn()
    {
        setCurrentState(TurnState.WAIT);
    }

    public override void rollDie()
    {
        if (!hasDiceBeenRolled)
        {
            setCurrentState(TurnState.MOVE);
            setCurrentStamina(Utilities.rollDie());
            Debug.Log("Champ has " + getCurrentStamina() + " movement points");
            hasDiceBeenRolled = true;
        }
    }

    public GameObject getChampTileLocation()
    {
        return champTileLocation;
    }
    public override int atkRoll()
    {
        return Utilities.roll6Die();
    }
}
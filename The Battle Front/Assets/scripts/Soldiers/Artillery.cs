using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Artillery : AbstractSoldier
{
    private bool hasDiceBeenRolled;
    private GameObject soldierTileLocation;

    void Start()
    {
        Debug.Log("Artillery State Machine Initiated");
        setAtkRange(4);
    }

    public override void init(string currentPlayer)
    {
        setName(currentPlayer + "Artillery");
        setSoldierType("Artillery");
        setSoldierVector(this.transform.position);
        Vector3 soldierVector = getSoldierVector();
        transform.position = new Vector3(soldierVector.x, 0.5f, soldierVector.z);
        setCurrentHealth(100);
        setAttackPower(40);
        setCurrentStamina(2);
        setAtkDie(10);
        setCurrentState(TurnState.WAIT);
        Debug.Log("Artillery is at " + soldierTileLocation);
    }

    void Update()
    {
        setSoldierVector(this.transform.position);
        if (getCurrentHealth() < 1)
        {
            Destroy(this);
        }
    }

    public void beginTurn(GameObject playerObject)
    {
        Debug.Log("Artillery turn has just begun");
        Debug.Log("Artillery is at " + soldierTileLocation);
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
            Debug.Log("Artillery has " + getCurrentStamina() + " movement points");
            hasDiceBeenRolled = true;
        }
    }

    public GameObject getChampTileLocation()
    {
        return soldierTileLocation;
    }

    public override int atkRoll()
    {
        return Utilities.roll10Die();
    }
}
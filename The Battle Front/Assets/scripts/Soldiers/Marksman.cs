using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Marksman : AbstractSoldier
{
    private bool hasDiceBeenRolled;
    private DiceRoll diceRoll;
    private GameObject soldierTileLocation;

    void Start()
    {
        Debug.Log("Marksman State Machine Initiated");
        diceRoll = new DiceRoll();
        setAtkRange(2);
    }

    public override void init(string currentPlayer)
    {
        setName(currentPlayer + "Marksman");
        setSoldierType("Marksman");
        setSoldierVector(this.transform.position);
        Vector3 soldierVector = getSoldierVector();
        transform.position = new Vector3(soldierVector.x, 0.5f, soldierVector.z);
        setCurrentHealth(100);
        setAttackPower(20);
        setCurrentStamina(1);
        setCurrentState(TurnState.WAIT);
        Debug.Log("Tank is at " + soldierTileLocation);
    }

    void Update()
    {
        setSoldierVector(this.transform.position);
    }

    public void beginTurn(GameObject playerObject)
    {
        Debug.Log("Tank turn has just begun");
        Debug.Log("Marksman is at " + soldierTileLocation);
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
            setCurrentStamina(diceRoll.clicked());
            Debug.Log("Marksman has " + getCurrentStamina() + " movement points");
            hasDiceBeenRolled = true;
        }
    }

    public GameObject getChampTileLocation()
    {
        return soldierTileLocation;
    }
}
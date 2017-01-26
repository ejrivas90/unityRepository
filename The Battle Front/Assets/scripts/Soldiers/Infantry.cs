using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Infantry : AbstractSoldier
{
    private bool hasDiceBeenRolled;
    private DiceRoll diceRoll;
    private Vector3 soldierVector;
    private GameObject soldierTileLocation;

    void Start()
    {
        Debug.Log("Infantry State Machine Initiated");
        diceRoll = new DiceRoll();
    }

    public override void init(string currentPlayer)
    {
        setName(currentPlayer + "Infantry");
        setSoldierType("Infantry");
        soldierVector = this.transform.position;
        transform.position = new Vector3(soldierVector.x, 0.5f, soldierVector.z);
        setCurrentHealth(100);
        setAttackPower(10);
        setCurrentStamina(1);
        setCurrentState(TurnState.WAIT);
        Debug.Log("Infantry is at " + soldierTileLocation);
    }

    void Update()
    {
        soldierVector = this.transform.position;
    }

    public void beginTurn(GameObject playerObject)
    {
        Debug.Log("Infantry turn has just begun");
        Debug.Log("Infantry is at " + soldierTileLocation);
        setCurrentState(TurnState.ACTIVE);
        hasDiceBeenRolled = false;
        setCurrentStamina(0);
    }

    public void endTurn()
    {
        setCurrentState(TurnState.WAIT);
    }

    public void rollDie()
    {
        if (!hasDiceBeenRolled)
        {
            setCurrentState(TurnState.MOVE);
            setCurrentStamina(diceRoll.clicked());
            Debug.Log("Infantry has " + getCurrentStamina() + " movement points");
            hasDiceBeenRolled = true;
        }
    }

    public void setChampVector(Vector3 champVector)
    {
        this.soldierVector = champVector;
    }

    public Vector3 getChampVector()
    {
        return soldierVector;
    }

    public GameObject getChampTileLocation()
    {
        return soldierTileLocation;
    }
}
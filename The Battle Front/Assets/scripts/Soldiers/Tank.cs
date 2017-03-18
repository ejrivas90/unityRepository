﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tank : AbstractSoldier
{
    private bool hasDiceBeenRolled;
    private DiceRoll diceRoll;
    private GameObject soldierTileLocation;

    void Start()
    {
        Debug.Log("Tank State Machine Initiated");
        diceRoll = new DiceRoll();
        setAtkRange(3);
    }

    public override void init(string currentPlayer)
    {
        setName(currentPlayer + "Tank");
        setSoldierType("Tank");
        setSoldierVector(this.transform.position);
        Vector3 soldierVector = getSoldierVector();
        transform.position = new Vector3(soldierVector.x, 0.5f, soldierVector.z);
        setCurrentHealth(100);
        setAttackPower(30);
        setCurrentStamina(2);
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
        Debug.Log("Tank is at " + soldierTileLocation);
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
            Debug.Log("Tank has " + getCurrentStamina() + " movement points");
            hasDiceBeenRolled = true;
        }
    }

    public GameObject getChampTileLocation()
    {
        return soldierTileLocation;
    }
}
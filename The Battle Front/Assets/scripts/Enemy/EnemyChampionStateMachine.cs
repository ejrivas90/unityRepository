﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyChampionStateMachine : AbstractSoldier
{
    private bool hasDiceBeenRolled;
    private DiceRoll diceRoll;
    private GameObject champTileLocation;

    void Start()
    {
        Debug.Log("Enemy Champ State Machine Initiated");
        diceRoll = new DiceRoll();
    }

    public override void init()
    {
        setName("enemyChampion");
        setSoldierType("Champion");
        champTileLocation = (GameObject)GameObject.Find("square: 6,1");
        setSoldierVector(GameObject.Find("square: 6,1").transform.position);
        Vector3 champVector = getSoldierVector();
        transform.position = new Vector3(champVector.x, 0.5f, champVector.z);
        setCurrentHealth(100);
        setAttackPower(50);
        setCurrentStamina(4);
        Debug.Log("champ is at " + champTileLocation);
    }

    void Update()
    {
        //Debug.Log("champ vector: " + this.transform.position.x + ", " + this.transform.position.y + ", " + this.transform.position.z);
        setSoldierVector(this.transform.position);
    }

    public void beginTurn(GameObject enemyObject)
    {
        Debug.Log("Enemy turn has just begun");
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
            setCurrentStamina(diceRoll.clicked());
            Debug.Log("Champ has " + getCurrentStamina() + " movement points");
            hasDiceBeenRolled = true;
        }
    }

    public GameObject getChampTileLocation()
    {
        return champTileLocation;
    }
}